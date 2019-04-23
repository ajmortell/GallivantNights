using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody2D bullet_body;
   
    public float bullet_decay = 0.0f;
    public float bullet_speed = 0.0f;
    [SerializeField]
    private float bullet_damage_mod = 0.0f;

    void Awake() {
        bullet_body = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyBullet());
    }

    private IEnumerator DestroyBullet() {
        yield return new WaitForSeconds(bullet_decay);
        Debug.Log("DESTROYED:  " + bullet_decay);
        Destroy(gameObject);
    }

    /// <summary>
    /// Get a string value after delimiter
    /// </summary>
    /// <param name="value"></param>
    /// <param name="a"></param>
    /// <returns></returns>
    public string GetStringValueAfter(string value, string a) {
        int posA = value.LastIndexOf(a);
        if (posA == -1) {
            return "";
        }
        int adjustedPosA = posA + a.Length;
        if (adjustedPosA >= value.Length) {
            return "";
        }
        return value.Substring(adjustedPosA);
    }
    private void Update() {
        transform.Translate(0, bullet_speed * Time.deltaTime, 0);
    }

}
