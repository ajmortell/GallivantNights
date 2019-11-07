using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private PlayerData player_data;
    private const string path = "Assets/Resources/XML/Data/Player/PlayerData.xml";
    private int last_weapon_index;
    private string progress;
    private List<BulletData> bullets;

    void Awake() {
        player_data = PlayerData.LoadPlayerData(path);// loads XML
        bullets = player_data.Bullets;
        //Debug.Log("BULLET COUNT: "+bullets.Count);
        for (int i = 0; i < bullets.Count; i++) {
            //Debug.Log("BULLET " + bullets.Count + " DATA: " + bullets[i].BulletName);
        }
    }
}
