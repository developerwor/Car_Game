using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sign_trrigerAlarm1 : MonoBehaviour
{
    public Text panel_text;
    public GameObject panel;   

    // Start is called before the first frame update
    void Start()
    {
        panel_text.enabled = false;
        panel.SetActive(false);        
    }



    private void OnTriggerStay(Collider other)
    {
        panel.SetActive(true);

        panel_text.enabled = true;
        panel_text.fontSize = 15;
        panel_text.text = "현재 60km \n 가속구간입니다";
        panel_text.color = Color.black;        
    }

    private void OnTriggerExit(Collider other)
    {
        panel.SetActive(false);
        panel_text.text = string.Empty;
        panel_text.enabled = false;
        panel_text.fontSize = 26;
    }
}
