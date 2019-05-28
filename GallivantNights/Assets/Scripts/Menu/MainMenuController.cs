using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public GameObject MainPanel;
    public GameObject FilePanel;
    public GameObject PlayerPanel;
    public GameObject VehiclePanel;
    public GameObject WeaponsPanel;
    public GameObject OptionsPanel;

    public Button FileBtn;
    public Button PlayerBtn;
    public Button VehicleBtn;
    public Button WeaponsBtn;
    public Button OptionsBtn;

    public void ResetPanels(params GameObject[] panels) {
        foreach (GameObject panel in panels) {
            panel.SetActive(false);
        }
    }

    void Start() {
        ResetPanels(FilePanel, PlayerPanel, VehiclePanel, WeaponsPanel, OptionsPanel);
    }

    public void FileButtonPress() {
        ResetPanels(FilePanel, PlayerPanel, VehiclePanel, WeaponsPanel, OptionsPanel);
        FilePanel.SetActive(true);
    }

    public void PlayerButtonPress() {
        ResetPanels(FilePanel, PlayerPanel, VehiclePanel, WeaponsPanel, OptionsPanel);
        PlayerPanel.SetActive(true);
    }

    public void VehicleButtonPress() {
        ResetPanels(FilePanel, PlayerPanel, VehiclePanel, WeaponsPanel, OptionsPanel);
        VehiclePanel.SetActive(true);
    }

    public void WeaponsButtonPress() {
        ResetPanels(FilePanel, PlayerPanel, VehiclePanel, WeaponsPanel, OptionsPanel);
        WeaponsPanel.SetActive(true);
    }

    public void OptionsButtonPress() {
        ResetPanels(FilePanel, PlayerPanel, VehiclePanel, WeaponsPanel, OptionsPanel);
        OptionsPanel.SetActive(true);
    }

    void Update() {

    }
}
