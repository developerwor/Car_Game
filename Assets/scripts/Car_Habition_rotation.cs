using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Habition_rotation : MonoBehaviour
{
    [Header("전시관 캐릭터")]    
    public GameObject Habition_chariter;

    [Header("전시관 차량 오브젝트")]
    public GameObject[] Car;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.name);
        Habition_chariter.transform.RotateAround(Habition_chariter.transform.position,Vector3.up, 0.1f);
    }    
}
