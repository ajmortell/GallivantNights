using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject menu_canvas;
    private bool canOpen = true;

    void Awake () {
        menu_canvas.SetActive(false);
	}

    void Update() {
        // MAKE SURE WE ARE IN DRIVER SCENE
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 2) {
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
