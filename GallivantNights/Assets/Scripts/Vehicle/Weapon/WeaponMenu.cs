using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject menu_canvas;
    public GameObject weapons_menu_panel;
    public GameObject upgrades_menu_panel;

    private Button[] weapon_category_buttons = null;
    private Button[] weapon_upgrade_buttons = null;

    private bool canOpen = true;

    void Awake () {
        menu_canvas.SetActive(false);
        weapon_category_buttons = weapons_menu_panel.GetComponentsInChildren<Button>();
        weapon_upgrade_buttons = upgrades_menu_panel.GetComponentsInChildren<Button>();

        for (int i = 0; i < weapon_category_buttons.Length; i++) {
            Debug.Log("WEAPON CATEGORIES AVAILABLE:  " + weapon_category_buttons[i]);
        }

        for (int i = 0; i < weapon_upgrade_buttons.Length; i++) {
            Debug.Log("UPGRADES AVAILABLE:  " + weapon_upgrade_buttons[i]);
        }
	}

    void Update() {
        // MAKE SURE WE ARE IN DRIVER SCENE
        if (SceneManager.GetActiveScene().buildIndex == 3) {
            if (Input.GetKeyDown("m")) {
                Debug.Log("PRESSED 'WEAPON MENU' BUTTON ");
                if (canOpen == true) {
                    canOpen = false;
         
                    menu_canvas.SetActive(true);
                } else {
                    canOpen = true;
      
                    menu_canvas.SetActive(false);
                }
            }
        }
    }
}
