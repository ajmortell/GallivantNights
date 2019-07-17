using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

    public Transform target;
    private VehicleController vehicle_controller;

    public RectTransform MovementBounds {
        get;
        set;
    }

    void Awake() {
        //cam = Camera.main;
        vehicle_controller = target.GetComponent<VehicleController>();
    }

    public void ChangeTarget(Transform _target) {
        target = _target;
    }

    /* DOWN
    ==============================

     S : transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);

     SA: transform.rotation = Quaternion.Euler(0.0f, 0.0f, 135.0f);

     SD: transform.rotation = Quaternion.Euler(0.0f, 0.0f, -135.0f);

    ===============================
    */

    /*
    ===============================

     W : transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

     WA: transform.rotation = Quaternion.Euler(0.0f, 0.0f, 45.0f);

     WD: transform.rotation = Quaternion.Euler(0.0f, 0.0f, -45.0f);

    ===============================
    */

    void LateUpdate() {
        
        /*
        //if(vehicle_controller.current_face_direction == VehicleController.FaceDirections.S || vehicle_controller.current_face_direction == VehicleController.FaceDirections.SA || vehicle_controller.current_face_direction == VehicleController.FaceDirections.SD) {
        //    transform.position = new Vector3(target.position.x, target.position.y-140, -10f);
        //} else if (vehicle_controller.previous_face_direction == VehicleController.FaceDirections.S || vehicle_controller.previous_face_direction == VehicleController.FaceDirections.SA || vehicle_controller.previous_face_direction == VehicleController.FaceDirections.SD) {
        //    transform.position = new Vector3(target.position.x, target.position.y-140, -10f);
        //} else {
        //    transform.position = new Vector3(target.position.x, target.position.y+140, -10f);
        //}
        */
        transform.position = new Vector3(target.position.x, target.position.y, -10f);
    }
}
