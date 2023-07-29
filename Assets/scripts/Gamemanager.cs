using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{

    public static Gamemanager instance = null;
    public track_Cars track_cars;        

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            
        }
    }

    public GameObject[] Cars;
    public void Monstertruck_play()
    {
        SceneManager.LoadScene("track");        
        Debug.Log("track��Scene���� �̵��մϴ�");   
    }

    public void HabitionSceneload()
    {
        SceneManager.LoadScene("Car_Habition");
        Debug.Log("Habition��Scene���� �̵��մϴ�");        
    }
    public void StartSceneload()
    {
        SceneManager.LoadScene("Start_Scene");
        Debug.Log("Start_Scene��Scene���� �̵��մϴ�");
    }
}
