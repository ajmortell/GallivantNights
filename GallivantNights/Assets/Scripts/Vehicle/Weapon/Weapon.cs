using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : MonoBehaviour {

    public Transform fire_point;
    public GameObject bullet_prefab;
    
    public Weaponry weaponry;

    public Sprite[] weapon_up, weapon_diag, weapon_side, weapon_active;
    
    [SerializeField]
    private float weapon_damage;
    
    private int ammo;
    [SerializeField]
    private int max_ammo;
    [SerializeField]
    private float fire_rate = 0.5f;
    [SerializeField]
    private float reload_speed;
    [SerializeField]
    private bool is_locked = true;
    private float next_fire;
    private Bullet bullet;
    
    private void Awake() {

        ammo = max_ammo;
    }

    void Fire() {

        ammo--;
        Debug.Log("Shooting Gun:  " + weapon_active);
        Debug.Log("TRANSFORM DIRECTION:  " + bullet_prefab.GetComponent<Bullet>().transform_direction);
        GameObject bullet_ = Instantiate(bullet_prefab, fire_point.position, fire_point.rotation);
        bullet_.SetActive(false);
        bullet = bullet_.GetComponent<Bullet>();
        weapon_damage += bullet.bullet_damage_mod;
        bullet.ChangeBulletDirection(transform.up);
        bullet_.SetActive(true);
        next_fire = Time.time + fire_rate;
    }

    void FixedUpdate() {
        Debug.Log("AMMO:  "+ammo);
       if(Input.GetButtonDown("Fire1") && Time.time > next_fire && ammo!=0) {
            Fire();
        }
    }


}
