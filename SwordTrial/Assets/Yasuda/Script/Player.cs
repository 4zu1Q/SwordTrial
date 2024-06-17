using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン切り替えのため



public class Player : MonoBehaviour
{
    /*ステータス変数*/
    public int m_hp;

    /*移動変数*/

    /*アイテム変数*/
    public enum ItemType
    {
        kBom,   //ボム
        kHeal,  //回復
    }

    private ItemType m_itemType;

    private string m_tagName = "Boss";

    /**/
    GameObject m_boss;

    GameObject m_player;
    Collider m_isAttack;

    private int m_frame;

    private float m_inputHorizontal;
    private float m_inputVertical;
    private Rigidbody m_rb;

    private bool m_isDash;

    private float m_moveSpeed;
    private Vector3 m_acel;
    private Vector3 m_cameraForward;
    private Vector3 m_moveForward;


    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_boss = GameObject.Find("Boss");
        m_player = GameObject.Find("Player");
        m_isAttack = GameObject.Find("Attack").GetComponent<SphereCollider>();
        m_hp = 100;
        m_moveSpeed = 5.0f;
        m_acel = new Vector3(1,0,1);
        m_isDash = false;
        m_frame = 0;
        m_itemType = ItemType.kBom;

    }

    void FixedUpdate()
    {

        /*移動処理*/
        m_inputHorizontal = Input.GetAxis("Horizontal");
        m_inputVertical = Input.GetAxis("Vertical");

        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 m_cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 m_moveForward = m_cameraForward * m_inputVertical + Camera.main.transform.right * m_inputHorizontal;

        // 移動方向にスピードを掛ける。
        m_rb.velocity = m_moveForward * m_moveSpeed;

        // キャラクターの向きを進行方向に
        if (m_moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(m_moveForward);
        }

        //Debug.Log(m_hp);
    }

    void Update()
    {

        //Aボタン
        //押している間はダッシュする
        if (Input.GetButton("Abutton") && !m_isDash)
        {
            Debug.Log("dash");
            Debug.Log(m_frame);
            m_frame++;

            m_rb.velocity = m_moveForward * m_moveSpeed;
        }



        //Bボタン
        if (Input.GetButtonDown("Bbutton") && m_itemType == ItemType.kBom)
        {
            Debug.Log("item:Bom");
        }
        else if (Input.GetButtonDown("Bbutton") && m_itemType == ItemType.kHeal && m_hp <= 100)
        {
            Debug.Log("item:Heal");


            if(m_hp < 100)
            {
                m_hp += 20;
            }

        }


            //Yボタン
            if (Input.GetButtonDown("Ybutton"))
        {
            Debug.Log("nanimonasi");
        }

        //Xボタン
        if (Input.GetButtonDown("Xbutton"))
        {
            Debug.Log("attack");

            //当たり判定を表示
            m_isAttack.enabled = true;

            Invoke("ColliderReset", 1.4f);

        }
        //else m_attack.gameObject.SetActive(false);


        //右スティック押し込み
        if (Input.GetButtonDown("Target"))
        {
            Debug.Log("ターゲット");
        }


        //HPがゼロになったら
        if(m_hp <= 0)
        {
            ////LoseSceneに移行
            //SceneManager.LoadScene("SceneLose");
            Debug.Log("負け");
        }

    }

    private void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.name == m_tagName)
        {
            m_hp -= 10;
        }
    }

    private void ColliderReset()
    {
        m_isAttack.enabled = false;
    }

}


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