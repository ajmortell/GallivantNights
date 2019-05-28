using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/*
 ___                        [|]                        ___
[   ]                    [|]| |[|]                    [   ]
 [/][ ][_][ ][=][=][=][=][=][ ][=][=][=][=][=][ ][_][ ][\]
 [\]                                      aw             [/]
 [/]  Displays dialogue lines to the player, and       [\]
 [\]  sends user choices back to the dialogue system.  [/]
 [/]                                                   [\]
 [\][ ][_][ ][=][=][=][=][=][ ][=][=][=][=][=][ ][_][ ][/]    
[___]                    [|]| |[|]                    [___]
                            [|]
*/

namespace Yarn.Unity.DialogueSystem {

    public class DialogueManager : Yarn.Unity.DialogueUIBehaviour {

        public GameObject dialogue_scene_panel;
        public GameObject dialogue_container;// Contains dialogue & options
        public GameObject continue_prompt;
        public GameObject speaker_label;
        public GameObject animated_panel;      
        public Text line_text;
        public List<Button> option_buttons;
        private AnimatedEntity current_entity;
        private Animator current_entity_animator=null;
        private Yarn.OptionChooser SetSelectedOption;// Yarn delegate. Tells user what option was selected
        private readonly float textSpeed = 0.05f;
        private bool is_finished_talking = true;       
        private int char_counter = 0;

        void Awake() {
            /* Hide the container, line and options */
            if (dialogue_container != null) {
                dialogue_container.SetActive(false);
                line_text.gameObject.SetActive(false);
                foreach (var button in option_buttons) {
                    button.gameObject.SetActive(false);
                }
            }            
            if (continue_prompt != null) { 
                continue_prompt.SetActive(false); /* Hide continue prompt */
            }
        }

        [YarnCommand("GoToScene")]
        public void GoToScene(string scene) {
            GameStateMaster.Instance.ChangeState(ParseStringValue(scene));
        }

        [YarnCommand("ChangeEntityState")]
        public void ChangeEntityState(string _value) {
            current_entity_animator = animated_panel.GetComponent<Animator>();
            switch (_value){
                case "true":
                    current_entity_animator.SetBool("isFinishedTalking", true);
                    break;
                case "false":
                    current_entity_animator.SetBool("isFinishedTalking", false);
                    break;
            }         
            Debug.Log("IS FINISHED TALKING: "+current_entity_animator.GetBool("isFinishedTalking"));
        }

        [YarnCommand("ChangeEntityType")]
        public void ChangeEntityType(string entity_) {
            switch(entity_) {
                case "NPC":
                    current_entity.entity_info.entity_type = AnimatedEntity.EntityType.NPC;
                    break;
                case "PLAYER":
                    current_entity.entity_info.entity_type = AnimatedEntity.EntityType.PLAYER;
                    break;
                case "SCENE":
                    current_entity.entity_info.entity_type = AnimatedEntity.EntityType.SCENE;
                    break;
            }          
        }

        /// <summary>
        /// Create an animated panel loaded from yarn script
        /// </summary>
        /// <param name="_file"></param>
        /// <param name="_type"></param>
        [YarnCommand("CreateEntity")]
        public void CreateEntity(string _file, string _speaker, string _id) {
            speaker_label.GetComponent<Text>().text = _speaker;
            
            GameObject animated_fab_ = Resources.Load<GameObject>("Prefabs/Animations/" + _file);
            animated_panel = Instantiate(animated_fab_);
            animated_panel.name = animated_fab_.name+"_"+_id;
            animated_panel.transform.SetParent(dialogue_scene_panel.transform, true);
            Transform[] panels_ = GetScenePanelChildren(dialogue_scene_panel.transform);
            for (int i = 0; i < panels_.Length; i++) {
                if (panels_[i].name != animated_panel.name) {
                    Destroy(panels_[i].gameObject);// destroys panel after it is no longer needed
                }
            }
            current_entity = animated_panel.GetComponent<AnimatedEntity>();
            current_entity_animator = animated_panel.GetComponent<Animator>();
            AnimatedEntity.EntityType entity_type_ = current_entity.entity_info.entity_type;
            speaker_label.GetComponent<Text>().color = current_entity.entity_info.speaker_color;           
            
     
        }

        /// <summary>
        /// Show a line of dialogue, gradually
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public override IEnumerator RunLine(Yarn.Line line) {
            line_text.gameObject.SetActive(true); /* Show text object */
            char_counter = 0; /* count all chars in line(s) */

            if (current_entity_animator != null && current_entity.entity_info.entity_type == AnimatedEntity.EntityType.NPC) {
                Debug.Log("TALKING...");
                current_entity_animator.SetBool("isFinishedTalking", false);
            }

            if (textSpeed > 0.0f) {             
                var string_builder_ = new System.Text.StringBuilder();
                // Display text one char at a time
                foreach (char c in line.text) {
                    char_counter++;
                    
                    yield return new WaitForSeconds(0.05f);
                    if (c == '.' || c == '?' || c == '!') {
                        string_builder_.Append(c);
                        line_text.text = string_builder_.ToString();
                        yield return new WaitForSeconds(0.5f);
                    }
                    else if (c == ',') {
                        string_builder_.Append(c);
                        line_text.text = string_builder_.ToString();
                        yield return new WaitForSeconds(0.25f);
                    } else {
                        string_builder_.Append(c);
                        line_text.text = string_builder_.ToString();
                        yield return new WaitForSeconds(textSpeed);
                    }
                    
                }
            } else {
                // Display line immediately if textSpeed == 0
                line_text.text = line.text;
            }
          
            // Show the 'press any key' prompt when done, if we have one
            if (continue_prompt != null && line_text.text.Length == char_counter) {
                continue_prompt.SetActive(true);
                if (current_entity_animator != null && current_entity.entity_info.entity_type == AnimatedEntity.EntityType.NPC)
                {
                    Debug.Log("STOP TALKING (again)...");
                    current_entity_animator.SetBool("isFinishedTalking", true);
                }
            }

            // Wait for any user input
            while (Input.anyKeyDown == false) {
                yield return null;
            }
            // Hide the text and prompt
            line_text.gameObject.SetActive(false);
            line_text.text = "";
            if (continue_prompt != null)
                continue_prompt.SetActive(false);
        }

        /// <summary>
        /// Change name of speaker durring dialogue
        /// </summary>
        /// <param name="_speaker"></param>
        [YarnCommand("ChangeSpeaker")]
        public void ChangeSpeaker(string _speaker, string _color) {
            Coloring coloring=GetComponent<Coloring>();
            speaker_label.GetComponent<Text>().text = _speaker;
            speaker_label.GetComponent<Text>().color = coloring.SelectColor(_color);
        }

        /// <summary>
        /// Run an internal command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public override IEnumerator RunCommand(Yarn.Command command) {
            yield break;
        }

        /// <summary>
        /// Show a list of options, and wait for the player to make a selection.
        /// </summary>
        /// <param name="optionsCollection"></param>
        /// <param name="optionChooser"></param>
        /// <returns></returns>
        public override IEnumerator RunOptions(Yarn.Options optionsCollection, Yarn.OptionChooser optionChooser) {
            if (optionsCollection.options.Count > option_buttons.Count) {
                Debug.LogWarning("There are more options to present than there are" +
                                 "buttons to present them in. This will cause problems.");
            }
            // Display each option button
            int i = 0;
            foreach (var optionString in optionsCollection.options) {
                option_buttons[i].gameObject.SetActive(true);
                option_buttons[i].GetComponentInChildren<Text>().text = optionString;
                i++;
            }
            SetSelectedOption = optionChooser;// Record that we're using it
            // Wait until the chooser has been used and then removed (see SetOption below)
            while (SetSelectedOption != null) {
                yield return null;
            }
            // Hide all the buttons
            foreach (var button in option_buttons) {
                button.gameObject.SetActive(false);
            }
        }
   
        /// <summary>
        /// Called by buttons to make a selection
        /// </summary>
        /// <param name="selectedOption"></param>
        public void SetOption(int selectedOption) {
            SetSelectedOption(selectedOption);// Call delegate. Tell dialogue system option was selected.            
            SetSelectedOption = null;// Remove delegate exiting 'RunOptions' loop
        }

        /// <summary>
        /// Called when dialogue system starts
        /// </summary>
        /// <returns></returns>
        public override IEnumerator DialogueStarted() {
            // Enable dialogue controls.
            if (dialogue_container != null)
                dialogue_container.SetActive(true);
            // Hide the game controls.
            //if (gameControlsContainer != null)
            //{
            //    gameControlsContainer.gameObject.SetActive(false);
            //}
            yield break;
        }

        /// <summary>
        /// Called when the dialogue system has finished running.
        /// </summary>
        /// <returns></returns>
        public override IEnumerator DialogueComplete() {
            //Debug.Log("DIALOGUE SCENE COMPLETE!");
            // Hide the dialogue interface.
            if (dialogue_container != null)
                dialogue_container.SetActive(false);
            // Show the game controls.
            //if (gameControlsContainer != null) {
            //    gameControlsContainer.gameObject.SetActive(true);
            //}
            yield break;
        }

        /// <summary>
        /// Returns an integer from a string value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int ParseStringValue(string value) {
            int parsed = System.Int32.Parse(value);
            return parsed;
        }

        /// <summary>
        /// Get all the children attached to a parent object
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public Transform[] GetScenePanelChildren(Transform parent) {
            Transform[] children = parent.GetComponentsInChildren<Transform>();
            Transform[] firstChildren = new Transform[parent.childCount];
            int index = 0;
            foreach (Transform child in children) {
                if (child.parent == parent) {
                    firstChildren[index] = child;
                    index++;
                }
            }
            return firstChildren;
        }

    }
}