using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelcollider_test : MonoBehaviour
{
    public WheelCollider[] wheels;
    public float Motoer_power = 100f;    
    public float streal_power = 100f;    

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var wheel in wheels)
        {
            wheel.motorTorque = Input.GetAxis("Vertical") * Motoer_power;                
        }
        for (int i = 0; i < wheels.Length; i++)
        {
            if (i < 2)
            {
                wheels[i].motorTorque = Input.GetAxis("Horizontal") * streal_power;
            }            
        }
    }   
}
