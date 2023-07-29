using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_print : MonoBehaviour
{
    public Gamemanager gamemanager;

    public GameObject Option_UI;

    public int UI_ONOFF;

    private void Start()
    {
        UI_ONOFF = 0;
        Option_UI.SetActive(false);
    }

    public void OptionUI()
    {
        if (UI_ONOFF == 0)
        {
            Option_UI.SetActive(true);
            UI_ONOFF = 1;
        }
        else if (UI_ONOFF == 1)
        {
            Option_UI.SetActive(false);
            UI_ONOFF = 0;
        }
        
    }
    
    public void Start_Button()
    {        
        gamemanager.HabitionSceneload();
    }

    public void Gidelint_Button()
    {

    }

    public void Startscene()
    {
        gamemanager.StartSceneload();
    }

    public void Exit_Button()
    {
        Application.Quit();
    }   
}
