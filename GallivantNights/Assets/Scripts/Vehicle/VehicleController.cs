using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour {

    [SerializeField]
    private int power = 100;
    [SerializeField]
    private int gear = 1;
    private float gear_timer = 0.5f;
    private Vector3 direction = Vector3.zero;

    public enum FaceDirections { W,S,A,D,WD,WA,SD,SA};
    public enum MotionStates { Stopped, Accelerating, Braking};
    FaceDirections face_direction;
    public FaceDirections current_face_direction;
    public FaceDirections previous_face_direction;
    MotionStates motion_state;
    private SpriteRenderer vehicle_renderer = null;

    private void Awake() {
        vehicle_renderer = this.GetComponent<SpriteRenderer>();
    }

    void CheckPreviousFace() {
        if(current_face_direction != previous_face_direction) {
            previous_face_direction = current_face_direction;
        }
    }
 
    void VehicleInput() {
        previous_face_direction = current_face_direction;
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) {
            face_direction = FaceDirections.WD;
            current_face_direction = face_direction;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, -45.0f);
            direction = (Vector3.forward + Vector3.up).normalized;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) {
            face_direction = FaceDirections.WA;
            current_face_direction = face_direction;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 45.0f);
            direction = (Vector3.forward + Vector3.up).normalized;
        }
        //
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) {
            face_direction = FaceDirections.SA;
            current_face_direction = face_direction;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 135.0f);
            direction = (Vector3.forward + Vector3.up).normalized;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) {
            face_direction = FaceDirections.SD;
            current_face_direction = face_direction;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, -135.0f);
            direction = (Vector3.forward + Vector3.up).normalized;
        }
        //
        else if (Input.GetKey(KeyCode.W)) {
            face_direction = FaceDirections.W;
            current_face_direction = face_direction;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            direction = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.S)) {
            face_direction = FaceDirections.S;
            current_face_direction = face_direction;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
            direction = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.A)) {
            face_direction = FaceDirections.A;
            current_face_direction = face_direction;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            direction = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.D)) {
            face_direction = FaceDirections.D;
            current_face_direction = face_direction;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
            direction = Vector3.up;
        } else {
            face_direction = current_face_direction;
            direction = Vector3.zero;
            gear = 1;
        }     
    }

    void MoveCar() {
        transform.Translate(direction * (power * gear) * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    void GearControl() {
        if (gear < 9) {
            gear_timer -= Time.deltaTime;
            if (gear_timer <= 0) {
                gear++;
                gear_timer = 2.0f;
            }
        }
    }

    void FixedUpdate() {
        VehicleInput();
        MoveCar();
        GearControl();
    }
}
