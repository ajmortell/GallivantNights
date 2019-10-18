using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody2D bullet_body;

    [SerializeField]
    private float bullet_decay;
    [SerializeField]
    private float bullet_speed;
    [SerializeField]
    public float bullet_damage;

    public Vector3 transform_direction;
    
    public void OnObjectSpawn () {
    }

   

    private void Awake() {
        bullet_body = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyBullet());
        transform_direction = transform.up;
    }

    private IEnumerator DestroyBullet() {
        yield return new WaitForSeconds(bullet_decay);
        Debug.Log("DESTROYED:  " + bullet_decay);
        Destroy(gameObject);
    }

    private void Update() {
        bullet_body.velocity = transform_direction * bullet_speed;
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.forward, out hit))
        //{
        //    Debug.Log("HIT SOMETHING");
        //    //Instantiate(explosion, hit.point, Quaternion.LookRotation(hit.normal));
        //    /* DoSlowMotion() */
        //}
    }
}
