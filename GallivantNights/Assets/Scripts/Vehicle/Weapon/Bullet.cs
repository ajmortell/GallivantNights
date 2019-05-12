using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody2D bullet_body;

    [SerializeField]
    private float bullet_decay = 0.0f;
    [SerializeField]
    private float bullet_speed = 0.0f;
    [SerializeField]
    public float bullet_damage_mod = 0.0f;

    public Vector3 transform_direction;

    public void ChangeBulletDirection(Vector3 dir) {
        transform_direction = dir;
    }

    void Awake() {
        bullet_body = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyBullet());
    }

    private IEnumerator DestroyBullet() {
        yield return new WaitForSeconds(bullet_decay);
        Debug.Log("DESTROYED:  " + bullet_decay);
        Destroy(gameObject);
    }

    private void Update() {
        bullet_body.velocity = transform_direction * bullet_speed;
    }

}
