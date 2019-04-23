using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour {

    private VehicleDisplayController vdc;
    private Vector3 direction = Vector3.zero;
    [SerializeField]
    private int power = 128;
    [SerializeField]
    private int gear = 1;
    private float gear_timer = 1.0f;

    void Start() {
        vdc = this.GetComponent<VehicleDisplayController>();
    }

    void VehicleInputControl() {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) {
            vdc.RightUp();
            vdc.SetMovingTrue();
            direction = (Vector3.right + Vector3.up).normalized;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) {
            vdc.LeftUp();
            vdc.SetMovingTrue();
            direction = (Vector3.left + Vector3.up).normalized;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) {
            vdc.LeftDown();
            vdc.SetMovingTrue();
            direction = (Vector3.left + Vector3.down).normalized;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) {
            vdc.RightDown();
            vdc.SetMovingTrue();
            direction = (Vector3.right + Vector3.down).normalized;
        }
        else if (Input.GetKey(KeyCode.W)) {
            vdc.Up();
            vdc.SetMovingTrue();
            direction = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.S)) {
            vdc.Down();
            vdc.SetMovingTrue();
            direction = Vector3.down;
        }
        else if (Input.GetKey(KeyCode.A)) {
            vdc.Left();
            vdc.SetMovingTrue();
            direction = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D)) {
            vdc.Right();
            vdc.SetMovingTrue();
            direction = Vector3.right;
        } else {
            vdc.SetMovingFalse();
            direction = Vector3.zero;
            gear = 1;
        }
    }

    void MoveCar() {
        transform.Translate(direction * (power * gear) * Time.deltaTime);
    }

    void GearControl() {
        vdc.SetAnimationTimerReset((float)(3 - (gear - 1)) / 10);
        if (gear < 9) {
            gear_timer -= Time.deltaTime;
            if (gear_timer <= 0) {
                gear++;
                gear_timer = 2.0f;
            }
        }
    }

    void FixedUpdate() {
        VehicleInputControl();
        MoveCar();
        GearControl();
    }
}
