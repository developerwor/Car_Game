using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum move_head { 
    Front,
    Back
}

public class wheel_controller : MonoBehaviour
{
    public move_head mheac = move_head.Front;

    [Header("자동차 타이어 휠콜라이더")]
    WheelFrictionCurve FRFrictionCurve;
    WheelFrictionCurve FLFrictionCurve;
    WheelFrictionCurve HRFrictionCurve;
    WheelFrictionCurve HLFrictionCurve;

    [Header("자동차 타이어 게임오브젝트 배열")]    
    public GameObject[] tire;
    public GameObject[] streering;

    [Header("자동차 휠콜라이더 배열")]
    [Tooltip("4가지 타이어")]
    public WheelCollider[] wheels;

    [Header("타이어 모터 스피드")]
    public float tireMoter_Power = 100f;

    [Space(10f)]

    [Header("타이어 회전각")]
    [Range(0,180)]
    public float tireangle_Power = 45f;

    [Space(10f)]

    [Header("RPM")]
    public int rpm;

    [Header("마찰의 정도")]        
    public float number = 0.001f;

    [SerializeField]
    private Rigidbody Player_rigidbody;

    [SerializeField] 
    [Header("시간")]
    private float time;

    bool Verticalcheck;
    bool Horizontalcheck;

    // Start is called before the first frame update
    void Start()
    {
        Verticalcheck = false;

        time = 0f;

        Player_rigidbody = GetComponent<Rigidbody>();
        Player_rigidbody.centerOfMass = new Vector3(0, -1, 0);        

        FRFrictionCurve = wheels[2].sidewaysFriction;
        FLFrictionCurve = wheels[2].forwardFriction;
        HRFrictionCurve = wheels[3].sidewaysFriction;
        HLFrictionCurve = wheels[3].forwardFriction;
    }

    // Update is called once per frame
    void Update()
    {
        frontmove();
        steering();
        buttoninput();
        brake();
        RPM_Check();     
    }
    public void frontmove()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            float h = 1f;
            if (mheac == move_head.Back)
            {
                h = -1f;
            }

            wheels[i].motorTorque = Input.GetAxis("Vertical") * tireMoter_Power * h;
            if (Verticalcheck && tireMoter_Power < 1500)
            {
                tireMoter_Power += 0.1f;
            }
            else if (Horizontalcheck)
            {
                tireMoter_Power -= 0.1f;
            }
            
            tire[i].transform.Rotate(Vector3.right, wheels[i].motorTorque * 0.01f);
        }
    }

    public void steering()
    {
        
        for (int i = 0; i < 2; i++)
        {
            wheels[i].steerAngle = Input.GetAxis("Horizontal") * tireangle_Power * 0.8f;
            
            streering[i].transform.localRotation = Quaternion.Euler(0, wheels[i].steerAngle, 0);            
        }
    }

    public void buttoninput()
    {
        Verticalcheck = Input.GetButton("Vertical");
        Horizontalcheck = Input.GetButton("Horizontal");       
    }

    public void RPM_Check()
    {
        rpm = (int)wheels[0].rpm;           
    }
    
    public void brake()
    {  
        if (Input.GetKey(KeyCode.Space))
        {            
            Player_rigidbody.drag = 1f;
            Player_rigidbody.angularDrag = 1f;

            FRFrictionCurve.stiffness = number;
            FLFrictionCurve.stiffness = number;
            HRFrictionCurve.stiffness = number;
            HLFrictionCurve.stiffness = number;

            if (number >= 1.0f)
            {
                number = 1;
            }

            wheels[2].forwardFriction = FRFrictionCurve;
            wheels[2].sidewaysFriction= FLFrictionCurve;
            wheels[3].forwardFriction = HRFrictionCurve;
            wheels[3].sidewaysFriction = HLFrictionCurve;

            for (int i = 1; i < wheels.Length; i++)
            {
                wheels[i].brakeTorque = 10000000f;
            }
        }
        else
        {            
            Player_rigidbody.drag = 0f;
            Player_rigidbody.angularDrag = 11f;

            FRFrictionCurve.stiffness = 1f;
            FLFrictionCurve.stiffness = 1f;
            HRFrictionCurve.stiffness = 1f;
            HLFrictionCurve.stiffness = 1f;

            wheels[2].forwardFriction = FRFrictionCurve;
            wheels[2].sidewaysFriction = FLFrictionCurve;
            wheels[3].forwardFriction = HRFrictionCurve;
            wheels[3].sidewaysFriction = HLFrictionCurve;

            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].brakeTorque = 0f;
            }
        }                
    }       
}
