using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public float LeftTriggerInput {
        get {
            return Input.GetAxis("LeftTrigger");
        }
    }

    public float RightTriggerInput {
        get {
            return Input.GetAxis("RightTrigger");
        }
    }

    public Vector2 CurrentInput {
        get {
            return new Vector2(Input.GetAxisRaw("Horizontal_DPAD"),
                Input.GetAxisRaw("Vertical_DPAD"));
        }
    }

}
