using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDisplayController : MonoBehaviour {

    public Sprite[] up, right, down, left, up_right, up_left, down_right, down_left, active;
    
    private bool moving = false;

    private SpriteRenderer vehicle_renderer = null;
    private SpriteRenderer weapon_renderer = null;
    
    public GameObject weaponry_object = null;
    private Weaponry weaponry;

    private GameObject weapon_object;
    private Weapon weapon;

    private float animTimer = 0.4f;
    private float animResetVal = 0.4f;
    private int animCount = 0;
    
    void Awake() {

        weaponry = weaponry_object.GetComponent<Weaponry>();//
        weaponry_object = weaponry.GetCurrentWeapon();
        //Debug.Log("CURRENT WEAPON: " + weaponry_object.name);

        weapon_renderer = weaponry_object.GetComponent<SpriteRenderer>();
        vehicle_renderer = this.GetComponent<SpriteRenderer>();

        weapon_object = weaponry.GetCurrentWeapon();
        weapon = weapon_object.GetComponent<Weapon>();

        active = up;// TODO: set to previous facing direction 
        weapon.weapon_active = weapon.weapon_up;
    }

    private void AnimateVehicle() {
        vehicle_renderer.sprite = active[animCount];

        weapon_object = weaponry.GetCurrentWeapon();
        weapon = weapon_object.GetComponent<Weapon>();
        weapon_renderer.sprite = weapon.weapon_active[animCount];

        animTimer -= Time.deltaTime;
        if (animTimer <= 0) {
            if (animCount <= active.Length - 1) {
                animCount++;
            }  else {
                animCount = 0;
            }
            animTimer = animResetVal;
        }
        if (animCount > active.Length - 1) {
            ResetAnimationCount();
        }
    }

    public void SetAnimationTimerReset(float val) {
        animResetVal = val;
    }

    public void SetMovingTrue() {
        moving = true;
    }

    public void SetMovingFalse() {
        moving = false;
    }

    public void Up() {
        active = up;
        weapon.weapon_active = weapon.weapon_up;
      
    }
    public void Down() {
        active = down;
        weapon.weapon_active = weapon.weapon_down;

    }
    public void Left() {
        active = left;
        weapon.weapon_active = weapon.weapon_left;
   
    }
    public void Right() {
        active = right;
        weapon.weapon_active = weapon.weapon_right;

    } 
    public void UpRight() {
        active = up_right;
        weapon.weapon_active = weapon.weapon_up_right;

    }
    public void UpLeft() {
        active = up_left;
        weapon.weapon_active = weapon.weapon_up_left;

    }
    public void DownLeft() {
        active = down_left;
        weapon.weapon_active = weapon.weapon_down_left;

    }
    public void DownRight() {
        active = down_right;
        weapon.weapon_active = weapon.weapon_down_right;

    }
    
    public void ResetAnimationCount() {
        animCount = 0;
    }

    void Update() {
        if (moving == true) {
            AnimateVehicle();
        } else {
            ResetAnimationCount();
        }
    }
}