using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// CUBE SPAWNER
[System.Serializable]
public class Weapon : MonoBehaviour {

    public Weaponry weaponry;
    public Transform bullet_spawn;
    public GameObject bullet_prefab;
    private ObjectPooler object_pooler;

    [SerializeField]
    private float weapon_damage; 
    private int ammo;
    [SerializeField]
    private int max_ammo;
    [SerializeField]
    private int bullets;
    [SerializeField]
    private float fire_rate;
    [SerializeField]
    private float reload_speed;
    [SerializeField]
    private int bullet_count;

    private bool is_locked = true;
    private float next_fire;
    private Bullet bullet;

    private void Awake() {
        ammo = max_ammo;
    }

    private void Start() {
        object_pooler = ObjectPooler.Pooler_Instance;
    }

    void Fire() {
        ammo--;
        //object_pooler.SpawnFromPool("bullet_singlegun_1", bullet_spawn.transform.position, bullet.transform.rotation);
        GameObject bullet_ = Instantiate(bullet_prefab, bullet_spawn.position, bullet_spawn.rotation);
        bullet = bullet_.GetComponent<Bullet>();
        weapon_damage += bullet.bullet_damage;
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
