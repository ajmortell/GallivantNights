using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightCycleEffect : MonoBehaviour {
    Light2D light_2D;
    public float duration;
    public Color color_a;
    public Color color_b;

    void Awake(){
        light_2D = GetComponent<Light2D>();
    }

    void CycleLerp() {
        float cycle = Mathf.PingPong(Time.time, duration) / duration;     
        light_2D.color = Color.Lerp(color_a, color_b, cycle);
    }

    void Update() {
        CycleLerp();
    }
}
