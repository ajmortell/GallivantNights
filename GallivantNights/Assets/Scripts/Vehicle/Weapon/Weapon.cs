using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : MonoBehaviour {

    public Sprite[] weapon_up, weapon_diag, weapon_side, weapon_active;
    private GameObject weapon;
    private Rigidbody2D weapon_body;
    [SerializeField]
    private float damage = 0.0f;
    private int ammo = 0;
    [SerializeField]
    private int max_ammo = 1;
    [SerializeField]
    private float reload_speed;
    [SerializeField]
    private string firetype = "";
    private bool isLocked = true;
    private string current_ammo_type = "";
    private Bullet bullet;

    private void AmmoChanged() {
        switch (weapon.name) {
            case "singleshot":
                break;
            case "doubleshot":
                break;
            case "burstshot":
                break;
        }
    }

    void SwitchFireType() {
        switch(firetype) {
            case "singleshot":
                break;
            case "doubleshot":
                break;
            case "burstshot":
                break;

            default:
                break;
        }
    }

    private void Awake() {
        weapon = gameObject;
        weapon_body = weapon.GetComponent<Rigidbody2D>(); 
    }

    void FixedUpdate() {
       
    }
}
