using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    enum FaceDirections {W=0, WD=1, D=2, SD=3, S=4, SA=5, A=6, WA=7};
    private Vector3 direction = Vector3.zero;
    Quaternion Up;
    Quaternion UpRight;
    Quaternion Right;
    Quaternion DownRight;
    Quaternion Down;
    Quaternion DownLeft;
    Quaternion Left;
    Quaternion UpLeft;

    FaceDirections face_directions;
    FaceDirections current_face_direction;
    FaceDirections previous_face_direction;

    void Awake() {
        face_directions = FaceDirections.W;

        Up = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        UpRight = Quaternion.Euler(0.0f, 0.0f, -45.0f);
        Right = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        DownRight = Quaternion.Euler(0.0f, 0.0f, -135.0f);
        Down = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        DownLeft = Quaternion.Euler(0.0f, 0.0f, 135.0f);
        Left = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        UpLeft = Quaternion.Euler(0.0f, 0.0f, 45.0f);

        int current_direction_holder_ = 0;// integer for enum iteration
        face_directions = (FaceDirections)current_direction_holder_;//set enum to numerical value = 'W' in enum (element 0)

        face_directions = FaceDirections.S;
        int directions_ = Enum.GetNames(typeof(FaceDirections)).Length -(int)face_directions;
        for (int i = 0; i < (int)face_directions; i++) {
              
        }

        //face_directions = FaceDirections.D;
        //int face_number = (int)face_directions;
        //current_face_direction = face_directions;
        //Debug.Log("FACE NUMBER: "+ face_number);
    }

    public Vector2 CurrentInput {
        get {
            return new Vector2(Input.GetAxis("Horizontal_DPAD"),
                Input.GetAxis("Vertical_DPAD"));
        }
    }

    void VehicleInput() {
        previous_face_direction = current_face_direction;
        
    }


}
