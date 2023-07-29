using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traffic_trrigerAlarm : MonoBehaviour
{
    public Text panel_text;
    public GameObject panel;

    private Traffic_Light traffic_Light;

    // Start is called before the first frame update
    void Start()
    {
        panel_text.enabled = false;
        panel.SetActive(false);
        traffic_Light = FindObjectOfType<Traffic_Light>();
    }



    private void OnTriggerStay(Collider other)
    {
        panel.SetActive(true);

        if (traffic_Light.Red_light)
        {
            panel_text.enabled = true;
            panel_text.text = "���� ������ �Դϴ�.\n ������ ���߼���!";
            panel_text.color = Color.red;
        }
        else if (traffic_Light.Orange_light)
        {
            panel_text.enabled = true;
            panel_text.text = "���� ��Ȳ�� �Դϴ�.\n ������ ������ ���߼���";
            panel_text.color = Color.yellow;
        }
        else if(traffic_Light.Green_light)
        {
            panel_text.enabled = true;
            panel_text.text = "���� �ʷϺ� �Դϴ�.\n �����ϰ� ����������";
            panel_text.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        panel.SetActive(false);
        panel_text.enabled = false;
    }
}
