﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour {

    InputManager input_manager;
    private float power = 128.0f;
    private int gear = 1;
    private float gear_timer = 0.0f;
    private Vector3 direction = Vector3.zero;
    private Vector2 input = Vector2.zero;
    #region Quaternions and Vectors
    Quaternion Up;
    Quaternion UpRight;
    Quaternion Right;
    Quaternion DownRight;
    Quaternion Down;
    Quaternion DownLeft;
    Quaternion Left;
    Quaternion UpLeft;

    Vector2 up_vector;
    Vector2 up_right_vector;
    Vector2 right_vector;
    Vector2 down_right_vector;
    Vector2 down_vector;
    Vector2 down_left_vector;
    Vector2 left_vector;
    Vector2 up_left_vector;
    #endregion

    enum FaceDirections { W = 0, WD = 1, D = 2, SD = 3, S = 4, SA = 5, A = 6, WA = 7 };
    enum MotionStates { Stopped, Accelerating, Braking};
    FaceDirections face_direction;
    FaceDirections current_face_direction;
    FaceDirections previous_face_direction;
    MotionStates motion_state;
    private SpriteRenderer vehicle_renderer = null;

    public LayerMask  blocked_collision_layer;
    private BoxCollider2D box_collider;
    private Rigidbody2D rb2D;

    void Awake() {
        input_manager = GetComponent<InputManager>();
        #region Quaternions and Vectors
        Up = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        UpRight = Quaternion.Euler(0.0f, 0.0f, -45.0f);
        Right = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        DownRight = Quaternion.Euler(0.0f, 0.0f, -135.0f);
        Down = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        DownLeft = Quaternion.Euler(0.0f, 0.0f, 135.0f);
        Left = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        UpLeft = Quaternion.Euler(0.0f, 0.0f, 45.0f);

        up_vector = new Vector2(0.0f, 1.0f);
        up_right_vector = new Vector2(1.0f, 1.0f);
        right_vector = new Vector2(1.0f, 0.0f);
        down_right_vector = new Vector2(1.0f, -1.0f);
        down_vector = new Vector2(0.0f, -1.0f);
        down_left_vector = new Vector2(-1.0f, -1.0f);
        left_vector = new Vector2(-1.0f, 0.0f);
        up_left_vector = new Vector2(-1.0f, 1.0f);
        #endregion
    }

    #region VEHICLE DIRECTIONAL MOVEMENT FUNCTIONS
    void GoUp() {
        current_face_direction = FaceDirections.W;
        transform.rotation = Up;
        direction = Vector3.up;
    }

    void GoUpRight() {
        face_direction = FaceDirections.WD;
        current_face_direction = face_direction;
        transform.rotation = UpRight;
        direction = (Vector3.forward + Vector3.up).normalized;
    }

    void GoRight() {
        face_direction = FaceDirections.D;
        current_face_direction = face_direction;
        transform.rotation = Right;
        direction = Vector3.up;
    }

    void GoDownRight() {
        face_direction = FaceDirections.SD;
        current_face_direction = face_direction;
        transform.rotation = DownRight;
        direction = (Vector3.forward + Vector3.up).normalized;
    }

    void GoDown() {
        face_direction = FaceDirections.S;
        current_face_direction = face_direction;
        transform.rotation = Down;
        direction = Vector3.up;
    }

    void GoDownLeft() {
        face_direction = FaceDirections.SA;
        current_face_direction = face_direction;
        transform.rotation = DownLeft;
        direction = (Vector3.forward + Vector3.up).normalized;
    }

    void GoLeft() {
        face_direction = FaceDirections.A;
        current_face_direction = face_direction;
        transform.rotation = Left;
        direction = Vector3.up;
    }

    void GoUpLeft() {
        face_direction = FaceDirections.WA;
        current_face_direction = face_direction;
        transform.rotation = UpLeft;
        direction = (Vector3.forward + Vector3.up).normalized;
    }
    #endregion

    private float LeftTriggerInput {
        get {
            return input_manager.LeftTriggerInput;
        }
    }

    private float RightTriggerInput {
        get {
            return input_manager.RightTriggerInput;
        }
    }

    private Vector2 CurrentInput {
        get
        {
            return input_manager.CurrentInput;
        }
        
    }
   
    void VehicleInput() {
   
        previous_face_direction = current_face_direction;

        if (input == up_vector) {
            GoUp();
        } else if (input == up_right_vector) {
            GoUpRight();
        } else if (input == right_vector) {
            GoRight();
        } else if (input == down_right_vector) {
            GoDownRight();
        } else if (input == down_vector) {
            GoDown();
        } else if (input == down_left_vector) {
            GoDownLeft();
        } else if (input == left_vector) {
            GoLeft();
        } else if (input == up_left_vector) {
            GoUpLeft();
        } else {
            face_direction = current_face_direction;           
        }
    }

    void MoveCar() {

        input = CurrentInput;
        transform.Translate(direction * (power * gear) * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        //LogMovementData();
    }

    void GearControl() {
        if (gear < 6) {
            gear_timer -= Time.deltaTime;
            if (gear_timer <= 0) {
                gear++;
                gear_timer = 0.2f;
            }
        }
    }

    void DownShiftControl() {
        if (gear != 0) {
            gear_timer -= Time.deltaTime;
            if (gear_timer <= 0) {
                gear--;
                gear_timer = 0.2f;
            }
        }
    }

    void GearInput() {
        if (RightTriggerInput == 1) {
            GearControl();
        } else if (RightTriggerInput == 0) {
        }
        if (LeftTriggerInput == 1) {
            DownShiftControl();
        } else if (LeftTriggerInput == 0) {
        }
    }

    private void LogMovementData()
    {
        Debug.Log("<color=red>SPEED: </color>" + transform.GetComponent<Rigidbody2D>().angularVelocity);

        Debug.Log("POS: " + transform.position);
        Debug.Log("POS_X: " + transform.position.x);
        Debug.Log("POS_Y: " + transform.position.y);
        Debug.Log("POS_Z: " + transform.position.z);

        Debug.Log("<color=white>EULER_ROTATION: </color>" + transform.eulerAngles);
        Debug.Log("<color=magenta>EULER_ROTATION_X: </color>" + transform.eulerAngles.x);
        Debug.Log("<color=magenta>EULER_ROTATION_Y: </color>" + transform.eulerAngles.y);
        Debug.Log("<color=magenta>EULER_ROTATION_Z: </color>" + transform.eulerAngles.z);
        Debug.Log("<color=cyan>TRANSFORM - WORLD TO LOCAL MATRIX: </color>" + transform.worldToLocalMatrix);
    }

    void FixedUpdate() {
        VehicleInput();
        MoveCar();
        GearInput();


    }
}
