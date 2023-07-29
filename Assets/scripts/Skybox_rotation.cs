using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skybox_rotation : MonoBehaviour
{
    [Header("스카이 박스 회전값")]
    public float Rotation_number;
    
    // Start is called before the first frame update   

    // Update is called once per frame
    void Update()
    {
        Rotation_number += 0.001f * Time.deltaTime;

        RenderSettings.skybox.SetFloat("_Rotation", Rotation_number);

        Skybox_Rotation_Reset();
    }
    private void Skybox_Rotation_Reset()
    {
        if (Rotation_number >= 360)
        {
            Rotation_number = 0;
        }
    }
}
