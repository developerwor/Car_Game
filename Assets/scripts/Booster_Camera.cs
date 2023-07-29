using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster_Camera : MonoBehaviour
{

    [Header("카메라")]
    public Camera Car_Camera;

    [Header("카메라가 도착하는 위치")]
    public GameObject cameramovepos;

    [Header("카메라의 원래 Position")]
    public Vector3 cameraPosition_reset;

    [Header("카메라가 바라보는 타겟")]
    public Transform cameraTarget;

    [Header("부스터 파티클")]
    public ParticleSystem Booster_particleSystem;

    wheel_controller wheel_Controller;
    // Start is called before the first frame update
    void Start()
    {
        wheel_Controller = FindObjectOfType<wheel_controller>();
        Booster_particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (wheel_Controller.rpm >= 300f)
        {
            Car_Camera.transform.position = Vector3.Lerp(Car_Camera.transform.position, cameramovepos.transform.position, 1.5f * Time.deltaTime);

            if(!Booster_particleSystem.isPlaying)
                Booster_particleSystem.Play();
            Debug.Log("s");
        }
        else
        {
            if(Booster_particleSystem.isPlaying)
                Booster_particleSystem.Stop();
        }
       

        Car_Camera.transform.LookAt(cameraTarget);
    }
}
