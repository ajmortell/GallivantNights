using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponMenu : MonoBehaviour {

    public GameObject weapons_menu_canvas;
    public GameObject weapons_menu_panel;
    public GameObject upgrades_menu_panel;

    private Button[] weapon_category_buttons = null;
    private Button[] weapon_upgrade_buttons = null;

    void Awake () {

        weapon_category_buttons = weapons_menu_panel.GetComponentsInChildren<Button>();
        weapon_upgrade_buttons = upgrades_menu_panel.GetComponentsInChildren<Button>();

        for (int i = 0; i < weapon_category_buttons.Length; i++) {
            Debug.Log("WEAPON CATEGORIES AVAILABLE:  " + weapon_category_buttons[i]);
        }

        for (int i = 0; i < weapon_upgrade_buttons.Length; i++) {
            Debug.Log("UPGRADES AVAILABLE:  " + weapon_upgrade_buttons[i]);
        }
	}
}
