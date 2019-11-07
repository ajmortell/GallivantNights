using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {

    public string uid = "";
    public LayerMask blocking_layer; //Layer on which collision will be checked.
    private BoxCollider2D box2D; //The BoxCollider2D component attached to this object.
    private Rigidbody2D rb2D; //The Rigidbody2D component attached to this object.

    protected virtual void Awake() {
    }

    //Protected, virtual functions can be overridden by inheriting classes.
    protected virtual void Start() {
        //Get a component reference to this object's BoxCollider2D
        box2D = GetComponent<BoxCollider2D>();
        //Get a component reference to this object's Rigidbody2D
        rb2D = GetComponent<Rigidbody2D>();
    }
}
