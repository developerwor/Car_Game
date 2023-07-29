using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster_Camera : MonoBehaviour
{

    [Header("ī�޶�")]
    public Camera Car_Camera;

    [Header("ī�޶� �����ϴ� ��ġ")]
    public GameObject cameramovepos;

    [Header("ī�޶��� ���� Position")]
    public Vector3 cameraPosition_reset;

    [Header("ī�޶� �ٶ󺸴� Ÿ��")]
    public Transform cameraTarget;

    [Header("�ν��� ��ƼŬ")]
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
