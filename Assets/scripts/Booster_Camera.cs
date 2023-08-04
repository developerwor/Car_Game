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
    
    void Start()
    {
        wheel_Controller = FindObjectOfType<wheel_controller>();
        Booster_particleSystem.Stop();
    }
    
    void Update()
    {
        // 자동차의 속도가 300이상이거나 같을때
        if (wheel_Controller.rpm >= 300f)
        {
            // 카메라가 조금 멀어진다
            Car_Camera.transform.position = Vector3.Lerp(Car_Camera.transform.position, cameramovepos.transform.position, 1.5f * Time.deltaTime);

            // 부스터 파티클 시스템이 플레이중이 아닐때
            if(!Booster_particleSystem.isPlaying)
            {
                // 부스터 파티클 시스템 플레이 시작
                Booster_particleSystem.Play();
            }
        }
        else
        {
            if(Booster_particleSystem.isPlaying)
            {
                Booster_particleSystem.Stop();
            }            
        }      

        // 항상 카메라가 타겟으로 설정된 위치를 바라본다.
        Car_Camera.transform.LookAt(cameraTarget);
    }
}
