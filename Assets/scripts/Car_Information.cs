using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public enum Carlist
{
    Monster_truck,
    Jeep,
    Sports_car1,
    truck1,
    truck2,
    Sports_car2_3,
}
public class Car_Information : MonoBehaviour
{
    [Header("Ʈ���� üũ")]
    public bool isearth;

    [Header("�������� ���� ����Ʈ")]
    [Tooltip("����Ʈ��/����/������ī1/Ʈ��1/Ʈ��2/������ī2,3")]
    public Carlist carlist;

    [Header("���� �迭")]
    public GameObject[] Cars;

    [Header("�г�")]
    public VideoPlayer [] Video_Array;

    [Header("�г� �ؽ�Ʈ")]
    public Text[] car_button_information_text;

    [Header("�г� ������Ʈ")]
    public GameObject panel;

    public GameObject button;

    private void Awake()
    {
        button.SetActive(false);
    }
    
    private void OnTriggerStay(Collider other)
    {
        isearth = true;

        switch (carlist)
        {            
            case Carlist.Monster_truck:
                Monster_truck_Information();
                break;
            case Carlist.Jeep:
                Jeep_Information();
                break;
            case Carlist.Sports_car1:
                Sports_car1_Information();
                break;
            case Carlist.truck1:
                truck_Information();
                break;
            case Carlist.truck2:
                truck2_Information();
                break;
            case Carlist.Sports_car2_3:
                Sports_car2_3_Information();
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isearth = false;

        Panel_ONOFF();
        Text_ONOFF();
    }

    public void Monster_truck_Information()
    {
        Video_Array[0].Play();
        Video_Array[1].Play();

        Panel_ONOFF();
        Text_ONOFF();

        button.SetActive(true);
        track_Cars.car_number = 0;
    }
   
    public void Jeep_Information()
    {
        Video_Array[2].Play();
        Video_Array[3].Play();

        Panel_ONOFF();
        Text_ONOFF();

        button.SetActive(true);
        track_Cars.car_number = 1;
    }
    
    public void Sports_car1_Information()
    {
        Video_Array[4].Play();
        Video_Array[5].Play();
        
        Panel_ONOFF();
        Text_ONOFF();

        button.SetActive(true);
        track_Cars.car_number = 2;
    }
   
    public void truck_Information()
    {
        Video_Array[6].Play();
        
        Panel_ONOFF();
        Text_ONOFF();

        button.SetActive(true);
        track_Cars.car_number = 3;
    }
    public void truck2_Information()
    {
        Video_Array[7].Play();
        Video_Array[8].Play();
        
        Panel_ONOFF();
        Text_ONOFF();

        button.SetActive(true);
        track_Cars.car_number = 4;
    }
    public void Sports_car2_3_Information()
    {
        Video_Array[9].Play();
        Video_Array[10].Play();

        Panel_ONOFF();
        Text_ONOFF();

        button.SetActive(true);
        track_Cars.car_number = 5;
    }
    public void Text_ONOFF()
    {
        if (isearth)
        {
            car_button_information_text[0].text = "Play";
        }
        else
        {
            car_button_information_text[0].text = string.Empty;
        }               
    }
    public void Panel_ONOFF()
    {
        if (isearth)
        {
            panel.SetActive(true);            
        }
        else
        {
            panel.SetActive(false);
            button.SetActive(false);            
        }
    }

    public void Video_Stop()
    {
        for (int i = 0; i < Video_Array.Length; i++)
        {
            Video_Array[i].Stop();
        }

        Panel_ONOFF();
        Text_ONOFF();
    }
}
