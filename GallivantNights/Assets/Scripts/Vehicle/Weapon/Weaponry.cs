using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponry : MonoBehaviour {

    public List<GameObject> weapons; // ALL POSSIBLE GAME WEAPONS ATTACHED TO VEHICLE OBJ
    private GameObject current_weapon; // THE CURRENTLY ACTIVE WEAPON ON VEHICLE OBJ 
    private GameObject previous_weapon; // PREVIOUS WEAPON

    void Awake () {
		for(int i=0; i<weapons.Count; i++) {
            bool active = weapons[i].activeInHierarchy;
            if (active == true) {
                current_weapon = weapons[i];
                previous_weapon = current_weapon;
                Debug.Log("INITIAL WEAPONRY ACTIVE: "+current_weapon.name);
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

    private void CheckWeapon() {
        Debug.Log("CURRENT WEAPON:  "+current_weapon);
        if (current_weapon.name != previous_weapon.name) {
            Debug.Log("** Weapon Has Changed :: CURRENT:  " + current_weapon + " PREVIOUS: " + previous_weapon);
            previous_weapon = current_weapon;
            Debug.Log("NEW WEAPON ACTIVE: " + current_weapon.name + "PREVIOUS:" + previous_weapon);

        }
    }

    void Update () {
        CheckWeapon();
    }
}