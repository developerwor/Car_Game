using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_move : MonoBehaviour
{
    [Header("자동차 오브젝트")]
    public GameObject Car;
    

    [Header("자동차 바퀴 배열")]
    public GameObject[] Car_tire;   

    [Header("파티클 부스터")]
    public ParticleSystem[] Particle;
    //private Rigidbody Car_rigidbody;

    public string Side = "Vertical";
    //public string front = "Horizontal";

    public float car_front;
    public float car_side;    

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    public float booster_speed = 20f;

    [SerializeField]
    private float rotation_speed = 1f;

    private Vector3 move_Vector;

    private bool frontback_move_check;

    Quaternion tire_rotation;
    // Start is called before the first frame update
    void Start()
    {
        //Particle[0].gameObject.SetActive(false);
        //Particle[1].gameObject.SetActive(false);
        //Car_rigidbody = Car.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {        
        input_Move();

        move_Vector = new Vector3(0, 0 , car_side) * speed * Time.deltaTime;               

        Move();
        Cartire_move();        
    }

    void input_Move()
    {
        car_side = Input.GetAxis(Side);
        frontback_move_check = Input.GetButton(Side);
        //car_front = Input.GetAxis(front);
    }
    
    void Move()
    {
        Car.transform.Translate(move_Vector);
    }

    void Cartire_move()
    {
        if (move_Vector.z > 0f)
        {
            Car_tire[0].transform.Rotate(0f, 0f, 30f * speed * Time.deltaTime);
            Car_tire[1].transform.Rotate(0f, 0f, 30f * -speed * Time.deltaTime);
            Car_tire[2].transform.Rotate(0f, 0f, 30f * speed * Time.deltaTime);
            Car_tire[3].transform.Rotate(0f, 0f, 30f * -speed * Time.deltaTime);

            //Particle[0].gameObject.SetActive(true);
            //Particle[1].gameObject.SetActive(true);
        }
        else if(move_Vector.z < 0f)
        {
            Car_tire[0].transform.Rotate(0f, 0f, 30f * -speed * Time.deltaTime);
            Car_tire[1].transform.Rotate(0f, 0f, 30f * speed * Time.deltaTime);
            Car_tire[2].transform.Rotate(0f, 0f, 30f * -speed * Time.deltaTime);
            Car_tire[3].transform.Rotate(0f, 0f, 30f * speed * Time.deltaTime);

            //Particle[0].gameObject.SetActive(false);
            //Particle[1].gameObject.SetActive(false);
        }



        if (Input.GetKey(KeyCode.A))
        {
            //Car_tire[0].transform.Rotate(Vector3.down, -1f); // 오른쪽 앞바퀴                        
            //if (//y의 각도가 130도 보다 높을때)
            //                                                {
            //    y = 130 * normallize;
            //}
            //Quaternion aa = Car_tire[0].transform.rotation;
            //Debug.Log("aa : " + aa);
            //if (aa.y >= 0.8f)
            //{
            //    Debug.Log("aa : " + aa);
            //    aa.y = 0.8f;
            //}

            Quaternion LrotAxis = Quaternion.Euler(0, 60, -180);

            //Car_tire[0].transform.localRotation = rotAxis;
            Car_tire[0].transform.localRotation = Quaternion.Lerp(Car_tire[0].transform.localRotation, LrotAxis, Time.deltaTime * 1.0f);
            Car_tire[2].transform.localRotation = Quaternion.Lerp(Car_tire[0].transform.localRotation, LrotAxis, Time.deltaTime * 1.0f);




            //Car_tire[2].transform.Rotate(Vector3.down, -1f);// 왼쪽 앞바퀴

            Car.transform.Rotate(Vector3.down, rotation_speed * 0.1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Car_tire[0].transform.Rotate(Vector3.down, -1f);
            //Car_tire[2].transform.Rotate(Vector3.down, 1f);
            Car.transform.Rotate(Vector3.down, -rotation_speed * 0.1f);
            Quaternion RrotAxis = Quaternion.Euler(0,120,-180);
            Car_tire[0].transform.localRotation = Quaternion.Lerp(Car_tire[0].transform.localRotation, RrotAxis, Time.deltaTime * 1.0f);
            Car_tire[2].transform.localRotation = Quaternion.Lerp(Car_tire[0].transform.localRotation, RrotAxis, Time.deltaTime * 1.0f);
        }
        else if (frontback_move_check)
        {
            Quaternion frontrot = Quaternion.Euler(0,90,-180);
            Car_tire[0].transform.localRotation = frontrot;
            Car_tire[2].transform.localRotation = frontrot;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("부스터 구간");
            speed = booster_speed;
            Particle[0].gameObject.SetActive(true);
            Particle[1].gameObject.SetActive(true);
        }        
        else
        {
            Particle[0].gameObject.SetActive(false);
            Particle[1].gameObject.SetActive(false);
            speed = 10f;
        }
    }
}
