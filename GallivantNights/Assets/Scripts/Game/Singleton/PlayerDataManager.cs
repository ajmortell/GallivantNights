using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class PlayerDataManager : Singleton<PlayerDataManager> {

    //SAVE DATA

    #region Player
    #endregion

    private int level = 1;
    private int curent_exp = 0;
    private int next_exp = 1000;
    private int money = 0;
    private int hp = 50;
    private int hp_max = 50;
    private string progress = "0.0.0.0"; // uses value to signify progress ie example: 2.15.4.17 would be act 2 scene 15 4 covos in line 17

    #region Weapon
    #endregion

    private int last_weapon_index = 0;
    private int last_scene = 0;
    private int singlegun_bullets = 0;
    private int doublegun_bullets = 0;
    private int burstgun_bullets = 0;
    private int heavygun_bullets = 0;
    private int mortargun_bullets = 0;
    private int beamgun_bullets = 0;

    private bool has_singlegun = false;
    private bool has_doublegun = false;
    private bool has_burstgun = false;
    private bool has_heavygun = false;
    private bool has_mortargun = false;
    private bool has_beamgun = false;

    public void SetLastWeapon(int idx) {
        last_weapon_index = idx;
    }
    public int GetLastWeapon() {
        int idx = last_weapon_index;
        return idx;
    }
    public void SetLastScene(int scene_) {
        last_scene = scene_;
    }
    public int GetLastScene() {
        int scene_ = last_scene;
        return scene_;
    }

    public void Save() {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerSaveData.dat");

        PlayerData data = new PlayerData();
        data.LastWeaponIndex = last_weapon_index;
        //data.SinglegunBullets = singlegun_bullets;
        //data.DoublegunBullets = doublegun_bullets;
        //data.BurstgunBullets = burstgun_bullets;
        //data.HeavygunBullets = heavygun_bullets;
        //data.MortargunBullets = mortargun_bullets;
        //data.BeamgunBullets = beamgun_bullets;

        formatter.Serialize(file, data);
        file.Close();
    }

    public void Load() {
        if (File.Exists(Application.persistentDataPath + "/playerSaveData.dat")) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerSaveData.dat", FileMode.Open);
            PlayerData data = (PlayerData)formatter.Deserialize(file);
            file.Close();
            last_weapon_index = data.LastWeaponIndex;
            //singlegun_bullets = data.SinglegunBullets;
            //doublegun_bullets = data.DoublegunBullets;
            //burstgun_bullets = data.BurstgunBullets;
            //heavygun_bullets = data.HeavygunBullets;
            //mortargun_bullets = data.MortargunBullets;
            //beamgun_bullets = data.BeamgunBullets;
        }
    }

}
