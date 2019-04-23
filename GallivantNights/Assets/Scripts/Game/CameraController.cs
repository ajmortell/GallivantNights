using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

    public Transform target;

    public RectTransform MovementBounds {
        get;
        set;
    }

    void Awake() {
        //cam = Camera.main;
    }

    public void ChangeTarget(Transform _target) {
        target = _target;
    }

    void LateUpdate() {
        transform.position = new Vector3(target.position.x, target.position.y, -10f);
    }
}
