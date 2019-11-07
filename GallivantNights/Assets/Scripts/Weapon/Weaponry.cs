using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponry : MonoBehaviour {

    public List<GameObject> weapons; // ALL POSSIBLE GAME WEAPONS ATTACHED TO VEHICLE/WEAPONRY OBJ
    private GameObject current_weapon; // THE CURRENTLY ACTIVE WEAPON ON VEHICLE OBJ 
    private GameObject previous_weapon; // PREVIOUS WEAPON

    private int weapon_index = 0;

    void Awake () {
        //current_weapon = weapons[PlayerDataManager.Instance.GetLastWeapon()];

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

        for (int i = 0; i < weapons.Count; i++) {
            bool active = weapons[i].activeInHierarchy;
            if (active == true) {
                //Debug.Log("WEAPON ACTIVE: " + weapons[i].name);
                weapons[i].SetActive(false);
            }
        }
        current_weapon = new_weapon;
        current_weapon.SetActive(true);
    }

    void WeapnSwitchInput() {
        if (Input.GetKey(KeyCode.Alpha0)) {
            ChangeWeapon(weapons[0]);
        } if (Input.GetKey(KeyCode.Alpha1)) {
            ChangeWeapon(weapons[1]);
        }
        else if (Input.GetKey(KeyCode.Alpha2)) {
            ChangeWeapon(weapons[2]);
        }
        else if (Input.GetKey(KeyCode.Alpha3)) {
            ChangeWeapon(weapons[3]);
        }
        else if (Input.GetKey(KeyCode.Alpha4)) {
            ChangeWeapon(weapons[4]);
        }
        else {          
            return;
        }
    }

    void Update () {
        WeapnSwitchInput();
    }
}