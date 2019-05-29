using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    [SerializeField]
    private int power = 128;
    [SerializeField]
    private int gear = 1;
    private float gear_timer = 0.5f;
    private Vector3 direction = Vector3.zero;

    private SpriteRenderer vehicle_renderer = null;

    private void Awake() {
        vehicle_renderer = this.GetComponent<SpriteRenderer>();
    }

    void VehicleInput() {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) {
           
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, -45.0f);
            direction = (Vector3.forward + Vector3.up).normalized;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 45.0f);
            direction = (Vector3.forward + Vector3.up).normalized;
        }
        //
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 135.0f);
            direction = (Vector3.forward + Vector3.up).normalized;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, -135.0f);
            direction = (Vector3.forward + Vector3.up).normalized;
        }
        //
        else if (Input.GetKey(KeyCode.W)) {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            direction = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.S)) {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
            direction = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.A)) {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            direction = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.D)) {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
            direction = Vector3.up;
        } else {
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
