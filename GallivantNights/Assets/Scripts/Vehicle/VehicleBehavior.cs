using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBehavior : MonoBehaviour
{
    InputManager input_manager;
    [SerializeField] float player_speed = 500f;
    private float power = 128.0f;
    private int gear = 1;
    private float gear_timer = 0.0f;
    private Vector3 direction = Vector3.zero;

    void Awake() {
        input_manager = GetComponent<InputManager>();
    }

    void Update() {
        //transform.Translate(input_manager.CurrentInput * Time.deltaTime * player_speed);
        MoveCar();

    }

    

    void MoveCar() {
        transform.Translate(input_manager.CurrentInput * (power * gear) * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    void GearControl()
    {
        if (gear < 9)
        {
            gear_timer -= Time.deltaTime;
            if (gear_timer <= 0)
            {
                gear++;
                gear_timer = 0.2f;
            }
        }
    }

    void DownShiftControl()
    {
        if (gear != 0)
        {
            gear_timer -= Time.deltaTime;
            if (gear_timer <= 0)
            {
                gear--;
                gear_timer = 0.5f;
            }
        }
    }





}
