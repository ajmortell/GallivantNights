using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : MonoBehaviour {

    public Transform bullet_spawn;
    //public Transform bullet_right_spawn;
    //public Transform bullet_diag_spawn;

    public GameObject bullet_prefab;
    
    public Weaponry weaponry;
    //public Sprite[] weapon_up, weapon_right, weapon_down, weapon_left, weapon_up_right, weapon_up_left, weapon_down_right, weapon_down_left, weapon_active;
    [SerializeField]
    private float weapon_damage;
    
    private int ammo;
    [SerializeField]
    private int max_ammo;
    [SerializeField]
    private int bullets;
    [SerializeField]
    private float fire_rate = 0.5f;
    [SerializeField]
    private float reload_speed;
    [SerializeField]
    private bool is_locked = true;
    private float next_fire;
    private Bullet bullet;
    private string weapon_prefix = "";

    //public Vector3 weapon_facing_direction;
    //private const string up = "weapon_up_1";
    //private const string down = "weapon_down_1";// Y FLIPPED
    //private const string right = "weapon_right_1";
    //private const string left = "weapon_left_1";// X FLIPPED
    //private const string up_right = "weapon_up_right_1";
    //private const string down_right = "weapon_down_right_1";// Y FLIPPED 
    //private const string up_left = "weapon_up_left_1";// X FLIPPED
    //private const string down_left = "weapon_down_left_1";// Y FLIPPED // X FLIPPED

    //public void CheckActiveWeapon() {
        
    //    Sprite active_sprite = weapon_active[0];
    //    Debug.Log("WEAPON DIRECTION.NAME:  " + active_sprite.name);
    //    switch (active_sprite.name) {
    //        // DIRECTIONAL
    //        case up:
    //            weapon_facing_direction = transform.up;
    //            Debug.Log("WEAPON FACING UP");
    //            break;
    //        case down:
    //            weapon_facing_direction = -transform.up;
    //            Debug.Log("WEAPON FACING DOWN");
    //            break;
    //        case right:
    //            weapon_facing_direction = transform.right;
    //            bullet_spawn.rotation = Quaternion.Euler(50.0f, 50.0f, 0.0f);
    //            Debug.Log("WEAPON FACING RIGHT");
    //            break;
    //        case left:
    //            weapon_facing_direction = -transform.right;
    //            Debug.Log("WEAPON FACING LEFT");
    //            break;
    //            // DIAGONALS
    //        case up_right:
    //            //bullet_spawn.position = new Vector3(0,0,0);
    //            weapon_facing_direction = Vector3.Lerp(transform.up, transform.right, 0.5f);
                
                
    //            Debug.Log("WEAPON FACING UP RIGHT");
    //            break;
    //        case up_left:
    //            weapon_facing_direction = Vector3.Lerp(transform.up, -transform.right, 0.5f);
    //            Debug.Log("WEAPON FACING UP LEFT");
    //            break;
    //        case down_right:
    //            weapon_facing_direction = Vector3.Lerp(-transform.up, transform.right, 0.5f);
    //            Debug.Log("WEAPON FACING DOWN RIGHT");
    //            break;
    //        case down_left:
    //            weapon_facing_direction = Vector3.Lerp(-transform.up, -transform.right, 0.5f);
    //            Debug.Log("WEAPON FACING DOWN LEFT");
    //            break;
    //    }
    //}

    private void Awake() {
        string weapon_prefix = this.name;
        Debug.Log("WEAPON CLASS:  "+weapon_prefix);
        ammo = max_ammo;
    }

    void Fire() {
        ammo--;
        GameObject bullet_ = Instantiate(bullet_prefab, bullet_spawn.position, bullet_spawn.rotation);
        //bullet_.SetActive(false);
        bullet = bullet_.GetComponent<Bullet>();
        weapon_damage += bullet.bullet_damage;
        //bullet.ChangeBulletDirection(weapon_facing_direction);
        //bullet_.SetActive(true);
        next_fire = Time.time + fire_rate;
    }

   void Reload() {
        
        if (bullets > max_ammo) {
            ammo = max_ammo;
            bullets -= max_ammo;
        } else {
            ammo = bullets;
            bullets -= bullets;
        }        
    }

    void FixedUpdate() {
     
        if (Input.GetButtonDown("Fire1") && Time.time > next_fire && ammo!=0) {
            //CheckActiveWeapon();
            Fire();
        }

        if (Input.GetButtonDown("Fire2") && Time.time > next_fire) {
            if(bullets!=0 && ammo == 0) {
                Debug.Log(" _____ RE-LOADING ...");
                Reload();
            } else if (bullets == 0 && ammo!=0) {
                Debug.Log(" _____ OUT OF BULLETS");
            } else {
                Debug.Log(" _____ OUT OF AMMO");
            }         
        }
    }
}
