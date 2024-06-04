using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Player : MonoBehaviour
{
    /*変数宣言*/
    private GameObject m_target;  //Boss
    private float m_velocity;   //速度
    private float m_moveSpeed;
    private bool m_isMove;  //移動できるかのフラグ

    private float m_inputHorizontal;
    private float m_inputVertical;

    private int m_frame;
    private bool m_isDash;

    private Vector3 m_prevPos;  //前の
    private Rigidbody m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_target = GameObject.Find("Boss"); //ボスの情報

        m_rb = GetComponent<Rigidbody>();

        m_velocity = 0.01f;                 //速度
        m_moveSpeed = 3.0f;                 //
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

        //インプット値を取得
        m_inputHorizontal = Input.GetAxis("Horizontal") * m_velocity;
        m_inputVertical = Input.GetAxis("Vertical") * m_velocity;

    }

    private void FixedUpdate()
    {
        //カメラの方向から、X、Z平面の単位ベクトルを取得
        Vector3 cameraFoward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        //方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraFoward * m_inputVertical + Camera.main.transform.right * m_inputHorizontal;
        //移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        m_rb.velocity = moveForward * m_moveSpeed + new Vector3(0, m_rb.velocity.y, 0);

        //キャラクターの向きを進行方向に
        if(moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }

    }
}
