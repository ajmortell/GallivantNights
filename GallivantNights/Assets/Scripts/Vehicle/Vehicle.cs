using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {

    private Weaponry weaponry;
    private Rigidbody2D body;

    // Use this for initialization
    private void Awake() {
        body = this.GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update () {
		
	}
}
