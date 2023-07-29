using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track_Cars : MonoBehaviour
{
    static public int car_number= 0;

    public GameObject[] cars;

    public Camera camera;

    private void Awake()
    {        
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(false);
        }
    }
    public void Start()
    {
        cars[car_number].SetActive(true);        
        camera.transform.parent = cars[car_number].transform;
    }   
}

