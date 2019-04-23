using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponry : MonoBehaviour {

    public List<GameObject> weapons; // ALL POSSIBLE GAME WEAPONS ATTACHED TO VEHICLE OBJ
    private GameObject current_weapon; // THE CURRENTLY ACTIVE WEAPON ON VEHICLE OBJ 
    private GameObject weapon; // THE INITIAL ACTIVE WEAPON

    void Awake () {
		for(int i=0; i<weapons.Count; i++) {
            bool active = weapons[i].activeInHierarchy;
            if (active == true) {
                weapon = weapons[i];
                current_weapon = weapon;
                Debug.Log("INITIAL WEAPONRY ACTIVE: "+current_weapon.name);
            }
        }
	}

    public GameObject GetCurrentWeapon() {
        GameObject obj_ = current_weapon;
        return obj_;
    }

    private void WeaponChanged() {
        switch (weapon.name) {
            case "singlegun":
                break;
            case "doublegun":
                break;
            case "burstgun":
                break;
        }
    }

    private void CheckWeapon() {
        if (current_weapon.name != weapon.name) {
            Debug.Log("Game State Has Changed :: Previous:  " + current_weapon + " Current: " + weapon);
            for (int i = 0; i < weapons.Count; i++) {
                bool active = weapons[i].activeInHierarchy;
                if (active == true) {
                    current_weapon = weapons[i];
                    Debug.Log("NEW WEAPON ACTIVE: " + current_weapon.name);
                }
            }
            WeaponChanged();
        }
    }

    void Update () {
        CheckWeapon();
    }
}