using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class EnemySight : MonoBehaviour {
   
    private List<Transform> eyes;
    private Vector2 left;
    private Vector2 right;
    private Vector2 front;
    private Vector2 rear;

    void Awake() {
        eyes = new List<Transform>();
        for (int index = 0; index < transform.childCount; index++) {
            eyes.Add(transform.GetChild(index));
        }
        left = -Vector2.right;
        right = Vector2.right;
        front = Vector2.up;
        rear = -Vector2.up;
    }

    void Search() {

        RaycastHit2D left_hit = Physics2D.Raycast(eyes[0].position, left);
        RaycastHit2D right_hit = Physics2D.Raycast(eyes[1].position, right);
        RaycastHit2D front_hit = Physics2D.Raycast(eyes[2].position, front);
        RaycastHit2D rear_hit = Physics2D.Raycast(eyes[3].position, rear);

        List<RaycastHit2D> hits = new List<RaycastHit2D> {
            left_hit,
            right_hit,
            front_hit,
            rear_hit
        };

        for (int i = 0; i < hits.Count; i++) {
            if (hits[i].collider != null) {
                //Debug.Log(" H I T ");
                return;
            } 
        }   
    }

    void FixedUpdate() {
        Search();
    }
}
