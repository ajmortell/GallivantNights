using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletFire : MonoBehaviour {

    Weapon current_weapon;

    public float fire_rate = 0.5f;// dynamic from weapon
    public Transform shot_spawn;

    public wild WildCard<wild>(wild param) where wild : class {
        return param;
    }

    private void Awake() {
        current_weapon = this.GetComponentInParent<Weapon>();
    }

    // Use this for initialization
    void Start() {
        InvokeRepeating("Fire", fire_rate, fire_rate);
    }

    // Update is called once per frame
    void Fire() {
        GameObject obj = ObjectPooler.current.GetPooledObject();
        if (obj == null) { return; }
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
}
