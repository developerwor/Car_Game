using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public enum button_loCation
{
    rigth,
    left,
    stop
}

public class button : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public button_loCation buttonenum;


    public wheel_controller wheel_;

    public void OnDrag(PointerEventData eventData)
    {
Debug.Log("À¯´ÏÆ¼");
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonenum == button_loCation.left)
        {

            //wheel_.steering(-1);
        }
        else if (buttonenum == button_loCation.rigth)
        {
            //wheel_.steering(1);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
