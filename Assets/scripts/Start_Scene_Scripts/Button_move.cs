using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Button_move : MonoBehaviour
{
    public GameObject GIdelinetext;

    public Button[] button;
    public Vector2 startpotition;
    public Vector2 Gidelinepotition;
    public Vector2 endpotition;



    // Update is called once per frame

    private void Start()
    {
        button[0].interactable = false;
        button[1].interactable = false;
        button[2].interactable = false;
        GIdelinetext.SetActive(false);
    }

    private void Update()
    {
        StartCoroutine("button_move");                
    }

    
        
    

    IEnumerator button_move()
    {
        yield return new WaitForSeconds(0.5f);
        button[0].transform.position = Vector2.Lerp(button[0].transform.position, startpotition, 5f * Time.deltaTime);
        
        Debug.Log("버튼 1" + button[0].name);
        yield return new WaitForSeconds(1f);
        button[1].transform.position = Vector2.Lerp(button[1].transform.position, Gidelinepotition, 5f * Time.deltaTime);
        
        Debug.Log("버튼 2" + button[1].name);
        yield return new WaitForSeconds(1f);
        button[2].transform.position = Vector2.Lerp(button[2].transform.position, endpotition, 5f * Time.deltaTime);        
        Debug.Log("버튼 3" + button[2].name);
        yield return new WaitForSeconds(1.5f);

        button[0].interactable = true;
        button[1].interactable = true;
        button[2].interactable = true;
    }

    public void Gideline_text_open()
    {
        GIdelinetext.SetActive(true);
    }

    public void Gideline_text_exit()
    {
        GIdelinetext.SetActive(false);
    }
}
