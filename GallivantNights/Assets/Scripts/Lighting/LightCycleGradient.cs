using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightCycleGradient : MonoBehaviour {
    Light2D light_2D;
    public Gradient gradient_cycle;
    public float duration = 2f;

    void Awake() {
        light_2D = GetComponent<Light2D>();
    }

    void CycleGradient() {
        float cycle = Mathf.PingPong(Time.time / duration, 1f);
        light_2D.color = gradient_cycle.Evaluate(cycle);
    }

    void Update() {
        CycleGradient();
    }

}
