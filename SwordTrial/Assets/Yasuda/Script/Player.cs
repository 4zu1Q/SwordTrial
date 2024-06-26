using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン切り替えのため



public class Player : MonoBehaviour
{
    /*ステータス変数*/
    public int m_hp;

    /*移動変数*/
    private string m_tagName = "Boss";

    /**/
    GameObject m_boss;

    GameObject m_player;
    Transform m_attack;
    Transform m_gard;

    private int m_frame;

    private float m_inputHorizontal;
    private float m_inputVertical;
    private Rigidbody m_rb;

    private bool m_isDash;
    private bool m_isItem;

    private float m_moveSpeed;
    private Vector3 m_acel;
    private Vector3 m_cameraForward;
    private Vector3 m_moveForward;


    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_boss = GameObject.Find("Boss");
        m_player = GameObject.Find("Player");
        m_attack = m_player.transform.Find("Attack");
        m_gard = m_player.transform.Find("Gard");
        m_hp = 100;
        m_moveSpeed = 5.0f;
        m_acel = new Vector3(1,0,1);
        m_isDash = false;
        m_isItem = false;
        m_frame = 0;

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
        //Debug.Log("速度ベクトル: " + m_rb.velocity);

        // キャラクターの向きを進行方向に
        if (m_moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(m_moveForward);
        }

        /*ボタン操作*/
        //Aボタン
        //押している間はダッシュする
        if (Input.GetButton("Abutton") && !m_isDash)
        {

            m_rb.velocity = m_moveForward * m_moveSpeed * 2.0f;
        }


        //Bボタン
        if (Input.GetButtonDown("Bbutton"))
        {
            m_isItem = true;

            //else if (m_hp >= 90) 
            //{
            //    m_hp += 10;
            //}

        }

        //Xボタン
        if (Input.GetButtonDown("Xbutton"))
        {
            Debug.Log("attack");

            //当たり判定を表示
            m_attack.gameObject.SetActive(true);

        }
        else
        {
            m_attack.gameObject.SetActive(false);

        }

        //Yボタン
        if (Input.GetButton("Ybutton"))
        {
            Debug.Log("ガード");
            m_gard.gameObject.SetActive(true);

        }
        else
        {
            m_gard.gameObject.SetActive(false);

        }

        if (m_isItem)
        {
            m_frame++;
            if(m_frame >= 180)
            {
                m_isItem = false;
                m_hp += 10;
                m_frame = 0;

            }
        }

        //LTボタン
        if (Input.GetButtonDown("LT"))
        {


        }

        Debug.Log(m_frame);



        Debug.Log(m_hp);
    }

    void Update()
    {
        //Debug.Log(m_hp);

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
            m_rb.velocity = -m_moveForward * m_moveSpeed * 2.0f;
            
            m_hp -= 10;
        }
    }

    //private void ColliderReset()
    //{
    //    m_isAttack.enabled = false;
    //}

}
