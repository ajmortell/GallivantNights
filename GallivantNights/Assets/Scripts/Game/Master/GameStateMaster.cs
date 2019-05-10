using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

#region Script Details
/*
 0. STARTUP - serves as a load point for game initialization. Autoloads Title screen
 1. TITLE - Contains splash animation and start screen. Press start to transition to next stage of game states
 2. GAME - This is where animation and dialogue take place
 3. DRIVE - This is when the player has an encounter with his vehicle
 4. MENU - Pause game when entering menu. Unpause on exit.
 5. QUIT - Bring up a menu asking if play wants to quit. Selecting yes exits application
*/
#endregion

public class GameStateMaster : Singleton<GameStateMaster> {
    private enum GameState { STARTUP = 0, TITLE = 1, DIALOGUE = 2, DRIVE = 3, MENU = 4, QUIT = 5 };
    private GameState game_state;
    private GameState current_game_state;
    private int menu_counter = 0;
    private int last_scene = 0;
    private bool can_open_menu = true;

    public override void Awake() {
        base.Awake();
        game_state = GameState.STARTUP;
        current_game_state = game_state;
        StartCoroutine(Startup());
    }

    // STATE METHODS //////////////////////////////////////////////////////////

    IEnumerator Startup() {
        yield return new WaitForSeconds(3.5f);
        game_state = GameState.STARTUP;
        StartCoroutine(Title());
    }

    IEnumerator Title() {
        yield return new WaitForSeconds(1.5f);
        game_state = GameState.TITLE;
        StartCoroutine(TransitionScene(1));
    }

    IEnumerator Dialogue() {
        yield return null;
        StartCoroutine(TransitionScene(2));
    }
    
    IEnumerator Drive() {
        yield return null;
        StartCoroutine(TransitionScene(3));
    }

    IEnumerator Menu() {
        yield return null;
        StartCoroutine(TransitionScene(4));
    }

    IEnumerator Quit() {
        yield return new WaitForSeconds(1.5f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    /////////////////////////////////////////////////////////////////////////

    public void QuitGame() {
        game_state = GameState.QUIT;
    }

    /////////////////////////////////////////////////////////////////////////

    IEnumerator TransitionScene(int scene) {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(scene);
    }

    private void GameStateChanged() {
        switch (game_state) {
            case GameState.STARTUP:
                break;
            case GameState.TITLE:
                break;
            case GameState.DIALOGUE:
                StartCoroutine(Dialogue());
                break;
            case GameState.DRIVE:
                StartCoroutine(Drive());
                break;
            case GameState.MENU:
                StartCoroutine(Menu());
                break;
            case GameState.QUIT:
                StartCoroutine(Quit());
                break;
        }
    }

    public void ChangeState(int state) {
        switch (state) {
            case 0:
                game_state = GameState.STARTUP;
                break;
            case 1:
                game_state = GameState.TITLE;
                break;
            case 2:
                game_state = GameState.DIALOGUE;
                break;
            case 3:
                game_state = GameState.DRIVE;
                break;
            case 4:
                game_state = GameState.MENU;
                break;
            case 5:
                game_state = GameState.QUIT;
                break;
        }
    }

    private void CheckState() {
        if (current_game_state != game_state) {
            Debug.Log("Game State Has Changed :: Previous:  " + current_game_state + " Current: " + game_state);
            current_game_state = game_state;
            GameStateChanged();
        }
    }

    public void Save() {
        //BinaryFormatter formatter = new BinaryFormatter();
        //FileStream file = File.Create(Application.persistentDataPath + "/playerSaveData.dat");

        //SceneData data = new SceneData();
        //data.SceneId = lastScene;

        //formatter.Serialize(file, data);
        //file.Close();
    }

    public void Load() {
        // if (File.Exists(Application.persistentDataPath + "/playerSaveData.dat")) {
        //BinaryFormatter formatter = new BinaryFormatter();
        //FileStream file = File.Open(Application.persistentDataPath + "/playerSaveData.dat", FileMode.Open);
        //SceneData data = (SceneData)formatter.Deserialize(file);
        //file.Close();
        //lastScene = data.SceneId;
        //}
    }

    public void CheckMenu() {
        if (Input.GetKeyDown("m")) {

            if (can_open_menu == true) {
                can_open_menu = true;
                Debug.Log("MENU OPEN");

            } else {
                can_open_menu = true;
                Debug.Log("MENU CLOSED");
            }
        }

    }

    void FixedUpdate() {
        CheckMenu();
    }

    void Update() {
        CheckState();
    }
}
