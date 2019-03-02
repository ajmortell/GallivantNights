using Yarn.Unity;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;
using System.Collections.Generic;

public class AnimatedEntity : MonoBehaviour {

    public enum EntityType { SCENE, NPC, PLAYER };   
    public enum EntityState { STOP, PLAY, IDLE, TALK };

    [System.Serializable]
    public struct EntityInfo {
        public string entity_name;
        public EntityType entity_type;
        public EntityState entity_state;
        //[FormerlySerializedAs("startNode")]
        //public string talk_to_node;
        //public TextAsset script_to_load;
        public Color32 speaker_color;
    }
    public EntityInfo entity_info;
   
    //void Start() {
    //    if (entity_info.script_to_load != null) {
    //        FindObjectOfType<Yarn.Unity.DialogueRunner>().AddScript(entity_info.script_to_load);
    //    }
    //}
}
