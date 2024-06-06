using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Player : MonoBehaviour
{
    ///*変数宣言*/
    //public int m_hp;

    //private GameObject m_target;  //Boss
    //private GameObject m_camera;
    //private float m_velocity;   //速度
    //private float m_moveSpeed;

    //private float m_inputHorizontal;
    //private float m_inputVertical;

    //private int m_frame;
    ////private bool m_isDash;

    //Rigidbody m_rb;


    //// Start is called before the first frame update
    //void Start()
    //{
    //    m_hp = 100;
    //    m_target = GameObject.Find("Boss"); //ボスの情報
    //    m_camera = GameObject.Find("MainCamera");

    //    m_rb = GetComponent<Rigidbody>();

    //    m_velocity = 0.001f;                 //速度
    //    m_frame = 0;
    //    //m_isDash = false;

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //ダッシュ処理


    //    //Aボタン
    //    //押している間はダッシュする
    //    if (Input.GetButton("Abutton") )
    //    {
    //        m_frame++;
    //        m_velocity = 0.02f;
    //        Debug.Log("dash");
    //    }
    //    else m_velocity = 0.01f;

    //    if(m_frame>=30)
    //    {
    //        //m_isDash = true;

    //    }
    //    else
    //    {
    //        //m_isDash=false;
    //    }

    //    //Bボタン
    //    if (Input.GetButtonDown("Bbutton"))
    //    {

    //        Debug.Log("item");
    //    }

    //    //Xボタン
    //    if (Input.GetButtonDown("Xbutton"))
    //    {

    //        Debug.Log("attack");
    //    }
    //    else
    //    {
    //    }

    //    //Yボタン
    //    if (Input.GetButtonDown("Ybutton"))
    //    {
    //        Debug.Log("nanimonasi");
    //        transform.position = new Vector3 (transform.position.x , transform.position.y + 0.8f, transform.position.z);
    //    }

    //    if (Input.GetButtonDown("Pause"))
    //    {
    //        Debug.Log("ポーズ");

    //    }

    //    if (Input.GetButtonDown("Target"))
    //    {
    //        Debug.Log("ターゲット");

    //    }

    //    if (Input.GetButtonDown("R1"))
    //    {
    //        Debug.Log("R1");

    //    }

    //    //if (Input.GetButtonDown("R2"))
    //    //{

    //    //}

    //    if(m_hp <= 0)
    //    {

    //    }

    //    //インプット値を取得
    //    m_inputHorizontal = Input.GetAxisRaw("Horizontal");
    //    m_inputVertical = Input.GetAxisRaw("Vertical");

    //}

    //private void FixedUpdate()
    //{
    //    //カメラの方向から、X、Z平面の単位ベクトルを取得
    //    //Vector3 cameraFoward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
    //    Vector3 cameraFoward = Vector3.Scale(m_camera.transform.position, new Vector3(1, 0, 1)).normalized;

    //    //方向キーの入力値とカメラの向きから、移動方向を決定
    //    //Vector3 moveForward = cameraFoward * m_inputVertical + Camera.main.transform.right * m_inputHorizontal;
    //    Vector3 moveForward = cameraFoward * m_inputVertical + m_camera.transform.position * m_inputHorizontal;

    //    //移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
    //    m_rb.velocity = moveForward * m_velocity + new Vector3(0, m_rb.velocity.y, 0);
    //    //transform.position = moveForward * m_velocity + new Vector3(0, 9, 0);

    //    //transform.position += new Vector3(m_inputHorizontal, m_rb.velocity.y, m_inputVertical);

    //    //キャラクターの向きを進行方向に
    //    if (moveForward != Vector3.zero)
    //    {
    //        transform.rotation = Quaternion.LookRotation(moveForward);
    //    }

    //    //Debug.Log(cameraFoward);

    //}


    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;

    float moveSpeed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }


}
