using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponry : MonoBehaviour {

    public List<GameObject> weapons; // ALL POSSIBLE GAME WEAPONS ATTACHED TO VEHICLE/WEAPONRY OBJ
    private GameObject current_weapon; // THE CURRENTLY ACTIVE WEAPON ON VEHICLE OBJ 
    private GameObject previous_weapon; // PREVIOUS WEAPON

    private int weapon_index = 0;

    void Awake () {
        current_weapon = weapons[GameStateMaster.Instance.GetLastWeapon()];

        for (int i=0; i<weapons.Count; i++) {
            bool active = weapons[i].activeInHierarchy;
            if (active == true) {
                current_weapon = weapons[i];
                previous_weapon = current_weapon;
            }
        }
	}

    public GameObject GetCurrentWeapon() {
        GameObject obj_ = current_weapon;
        return obj_;
    }

    public GameObject GetPrevioustWeapon() {
        GameObject obj_ = previous_weapon;
        return obj_;
    }

    public void ChangeWeapon(GameObject new_weapon) {
        current_weapon = new_weapon;
    }

    private void ChangeWeapon() {  
        if (current_weapon.name != previous_weapon.name) {
            previous_weapon = current_weapon;
        }
    }

    void Update () {      
    }
}