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
            panel_text.text = "현재 빨간불 입니다.\n 차량을 멈추세요!";
            panel_text.color = Color.red;
        }
        else if (traffic_Light.Orange_light)
        {
            panel_text.enabled = true;
            panel_text.text = "현재 주황불 입니다.\n 서서히 차량을 멈추세요";
            panel_text.color = Color.yellow;
        }
        else if(traffic_Light.Green_light)
        {
            panel_text.enabled = true;
            panel_text.text = "현재 초록불 입니다.\n 안전하게 지나가세요";
            panel_text.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        panel.SetActive(false);
        panel_text.enabled = false;
    }
}
