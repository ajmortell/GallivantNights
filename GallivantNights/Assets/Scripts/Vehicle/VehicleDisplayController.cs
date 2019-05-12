using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDisplayController : MonoBehaviour {

    public Sprite[] up, diag, side, active;
    
    private bool moving = false;
    private bool flipX = false;
    private bool flipY = false;
    private bool flip_weapon_X = false;
    private bool flip_weapon_Y = false;
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
        Debug.Log("CURRENT WEAPON: " + weaponry_object.name);

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

        vehicle_renderer.flipX = flipX;
        weapon_renderer.flipX = flip_weapon_X;

        vehicle_renderer.flipY = flipY;
        weapon_renderer.flipY = flip_weapon_Y;

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
        flipX = false;
        flipY = false;
        flip_weapon_X = false;
        flip_weapon_Y = false;
    }
    public void Down() {
        active = up;
        weapon.weapon_active = weapon.weapon_up;
        flipX = false;
        flipY = true;
        flip_weapon_X = false;
        flip_weapon_Y = true;
    }
    public void Left() {
        active = side;
        weapon.weapon_active = weapon.weapon_side;
        flipX = true;
        flipY = false;
        flip_weapon_X = true;
        flip_weapon_Y = false;
    }
    public void Right() {
        active = side;
        weapon.weapon_active = weapon.weapon_side;
        flipX = false;
        flipY = false;
        flip_weapon_X = false;
        flip_weapon_Y = false;
    } 
    public void RightUp() {
        active = diag;
        weapon.weapon_active = weapon.weapon_diag;
        flipX = false;
        flipY = false;
        flip_weapon_X = false;
        flip_weapon_Y = false;
    }
    public void LeftUp() {
        active = diag;
        weapon.weapon_active = weapon.weapon_diag;
        flipX = true;
        flipY = false;
        flip_weapon_X = true;
        flip_weapon_Y = false;
    }
    public void LeftDown() {
        active = diag;
        weapon.weapon_active = weapon.weapon_diag;
        flipX = true;
        flipY = true;
        flip_weapon_X = true;
        flip_weapon_Y = true;
    }
    public void RightDown() {
        active = diag;
        weapon.weapon_active = weapon.weapon_diag;
        flipX = false;
        flipY = true;
        flip_weapon_X = false;
        flip_weapon_Y = true;
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