using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic_Light : MonoBehaviour
{
    public Light[] traffic_light;
    // traffic_light[0] ������
    // traffic_light[1] ��Ȳ��
    // traffic_light[2] �ʷϺ�

    public bool Red_light;
    public bool Orange_light;
    public bool Green_light;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < traffic_light.Length; i++)
        {
            traffic_light[i].enabled = false;
        }

        StartCoroutine("Waiting_time");
        StopAllCoroutines();
        StartCoroutine("Traffic_start");
    }
    private void Update()
    {
        if (traffic_light[0].enabled && !traffic_light[1].enabled && !traffic_light[2].enabled)
        {
            Red_light = true;
            Orange_light= false;
            Green_light = false;
        }
        else if (!traffic_light[0].enabled && traffic_light[1].enabled && !traffic_light[2].enabled)
        {
            Red_light = false;
            Orange_light = true;
            Green_light = false;
        }
        else if (!traffic_light[0].enabled && !traffic_light[1].enabled && traffic_light[2].enabled)
        {
            Red_light = false;
            Orange_light = false;
            Green_light = true;
        }
    }
    // Update is called once per frame

    IEnumerator Waiting_time()
    {        
        traffic_light[0].enabled = false;
        traffic_light[1].enabled = false;
        traffic_light[2].enabled = true;        
        yield return new WaitForSeconds(3.0f);
    }

    IEnumerator Traffic_start()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);
            traffic_light[0].enabled = false; // ������ off
            traffic_light[1].enabled = true;  // ��Ȳ�� on          
            traffic_light[2].enabled = false; // �ʷϺ� off

            yield return new WaitForSeconds(2.0f);
            traffic_light[0].enabled = true; // ������ off
            traffic_light[1].enabled = false; // ��Ȳ�� off 
            traffic_light[2].enabled = false;  // �ʷϺ� on

            yield return new WaitForSeconds(10.0f);
            traffic_light[0].enabled = false;  // ������ on
            traffic_light[1].enabled = false; // ��Ȳ�� off
            traffic_light[2].enabled = true;  // �ʷϺ� off
        }
    }
}
