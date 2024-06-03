using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Player : MonoBehaviour
{
    /*変数宣言*/
    GameObject target;  
    private float m_velocity;   //速度
    private float m_rotateSpeed;   //回転する速度
    private bool m_isMove;  //移動できるかのフラグ

    private int m_frame;
    private bool m_isDash;

    private Vector3 m_prevPos;  //前の
    private Rigidbody m_rd;

    // Start is called before the first frame update
    void Start()
    {
        //Mathf.Sin(Radian);


        m_velocity = 0.01f;
        m_rotateSpeed = 0.1f;
        m_frame = 0;
        m_isMove = false;
        m_isDash = false; 

    }

    // Update is called once per frame
    void Update()
    {
        //ダッシュ処理

        //Aボタン
        //押している間はダッシュする
        if (Input.GetButton("Abutton") )
        {
            m_frame++;
            m_velocity = 0.02f;
            Debug.Log("dash");
        }
        else m_velocity = 0.01f;
        
        if(m_frame>=30)
        {
            m_isDash = true;

        }
        else
        {
            m_isDash=false;
        }

        //Bボタン
        if (Input.GetButtonDown("Bbutton"))
        {

            Debug.Log("item");
        }

        //Xボタン
        if (Input.GetButtonDown("Xbutton"))
        {

            Debug.Log("attack");
            m_isMove = true;
        }
        else
        {
            m_isMove = false;
        }

        //Yボタン
        if (Input.GetButtonDown("Ybutton"))
        {
            Debug.Log("nanimonasi");
            transform.position = new Vector3 (transform.position.x , transform.position.y + 0.8f, transform.position.z);
        }

        if (Input.GetButtonDown("Pause"))
        {
            Debug.Log("ポーズ");

        }

        if (Input.GetButtonDown("Target"))
        {
            Debug.Log("ターゲット");

        }

        if (Input.GetButtonDown("R1"))
        {
            Debug.Log("R1");

        }

        //if (Input.GetButtonDown("R2"))
        //{

        //}

        /*プレイヤー移動処理*/

        //インプット値を取得
        float inputX = Input.GetAxis("Horizontal") * m_velocity;
        float inputZ = Input.GetAxis("Vertical") * m_velocity;

        //float inputX = Input.GetAxis("Horizontal");
        //float inputZ = Input.GetAxis("Vertical");


        if (!m_isMove)
        {
            //移動処理
            transform.position = new Vector3(transform.position.x + inputX, transform.position.y, transform.position.z + inputZ);

            ////
            //Vector3 cameraFoward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1).normalized);

            ////
            //Vector3 moveForward = cameraFoward * inputX + Camera.main.transform.right * inputZ;

            //


        }




        /*アナログスティックの処理*/
        //float degree = Mathf.Atan2(inputX, inputZ) * Mathf.Rad2Deg;

        //if(degree < 0)
        //{
        //    degree += 360;
        //}

        ////右スティックで回転する
        //transform.Rotate(new Vector3(0.0f, m_rotateSpeed * Input.GetAxis("Horizontal2"), 0.0f));
        ////transform.Rotate(new Vector3(0.0f, m_rotateSpeed * degree, 0.0f));

        //Debug.Log(degree);


    }
}
