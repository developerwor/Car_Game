using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_defultchange : MonoBehaviour
{
    [Header("라이트 집합체")]
    public Light[] light;
    private float change;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("lightchange");
    }

    // Update is called once per frame
    void Update()
    {        
        
    }

    IEnumerator lightchange()
    {        
        while (true)
        {
            yield return new WaitForSeconds(0.003f);
            change += 1;
            light[0].intensity = change;

            if (change == 120f)
            {
                change = 0f;
            }            
        }
    }
}
