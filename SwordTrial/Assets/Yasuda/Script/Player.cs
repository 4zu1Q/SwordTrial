using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン切り替えのため



public class Player : MonoBehaviour
{
    /*ステータス変数*/
    [SerializeField] public int m_hp;
    [SerializeField] private int m_hpNum;
    [SerializeField] private float m_speed;
    [SerializeField] private float m_acel;


    /*オブジェクト変数*/
    GameObject m_boss;
    GameObject m_player;
    Transform m_attack;

    /*タグ変数*/
    private string m_attackTag;
    private string m_gardTag;

    /*フレーム変数*/
    private int m_frame;

    /*移動変数*/
    private float m_inputHorizontal;
    private float m_inputVertical;
    private Rigidbody m_rb;

    private bool m_isDash;
    private bool m_isItem;
    private bool m_isGard;

    /*カメラの変数*/
    private Vector3 m_cameraForward;
    private Vector3 m_moveForward;


    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_boss = GameObject.Find("Boss");
        m_player = GameObject.Find("Player");
        m_attack = m_player.transform.Find("Attack");
        m_hp = 100;
        m_hpNum = 3;
        m_speed = 5.0f;
        m_acel = 2.0f;
        m_isDash = false;
        m_isItem = false;
        m_isGard = false;
        m_frame = 0;

        m_inputHorizontal = 0;
        m_inputVertical = 0;

        m_attackTag = "PlayerAttack";
        m_gardTag = "PlayerGard";

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

        if (!m_isGard)
        {
            // 移動方向にスピードを掛ける。
            m_rb.velocity = m_moveForward * m_speed;

            //Aボタン
            //押している間はダッシュする
            if (Input.GetButton("Abutton") && !m_isDash)
            {

                m_rb.velocity = m_moveForward * m_speed * m_acel;
            }
        }

        //Debug.Log("速度ベクトル: " + m_rb.velocity);

        // キャラクターの向きを進行方向に
        if (m_moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(m_moveForward);
        }

        /*ボタン操作*/



        //Bボタン
        if(m_hpNum > 0)
        {
            if (Input.GetButtonDown("Bbutton") && m_hp < 100)
            {
                m_isItem = true;

            }
        }


        //Xボタン
        if (Input.GetButtonDown("Xbutton"))
        {
            Debug.Log("attack");

            //当たり判定を表示
            //m_attack.gameObject.SetActive(true);
            //SetTag(m_gardTag);
        }
        else
        {
            //m_attack.gameObject.SetActive(false);
            //SetTag(m_attackTag);
        }

        //Yボタン
        if (Input.GetButton("Ybutton"))
        {
            //Debug.Log("ガード");
            m_isGard = true;
            m_player.tag = "PlayerGard";
            Debug.Log(m_player.tag);

        }
        else
        {
            m_isGard = false;
            m_player.tag = "PlayerAttack";
            Debug.Log(m_player.tag);

        }

        //HPが減っていた場合
        if (m_isItem)
        {
            m_frame++;
            if(m_frame >= 180)
            {
                m_isItem = false;
                m_frame = 0;
                m_hp += 10;
                m_hpNum--;


            }
        }

        //LTボタン
        if (Input.GetButtonDown("LT"))
        {


        }

        //Debug.Log(m_frame);



        //Debug.Log(m_hp);
        //Debug.Log(m_hpNum);
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
       if(other.gameObject.name == "Boss")
        {
            m_rb.velocity = -m_moveForward * m_speed * 2.0f;
            
            m_hp -= 10;
        }
    }

    private void SetTag(string newTag)
    {
        m_player.tag = newTag;
    }
}
