using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン切り替えのため
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    /*ステータス変数*/
    [SerializeField] private int m_itemNum;       //アイテムの個数
    [SerializeField] private float m_speed;
    [SerializeField] private float m_acel;
    [SerializeField] public int m_maxHp;
    [SerializeField] public int m_hp;

    /*オブジェクト変数*/
    GameObject m_boss;
    GameObject m_player;
    GameObject m_attack;
    GameObject m_gard;

    /*オブジェクトの座標変数*/
    private Vector3 m_playerPosition;
    private Vector3 m_attackPosition;
    private Vector3 m_gardPosition;

    /*タグ変数*/
    private string m_attackTag;
    private string m_gardTag;

    /*フレーム変数*/
    [SerializeField] private int m_itemFrame;
    [SerializeField] private int m_attackFrame;

    /*定数*/
    [SerializeField] private int kItemFrameCountNum;
    [SerializeField] private int kAttackFrameCountNum;
    [SerializeField] private int kAttackPower;

    /*移動変数*/
    private float m_inputHorizontal;
    private float m_inputVertical;
    private Rigidbody m_rb;

    private bool m_isDash;
    private bool m_isItem;
    private bool m_isAttack;
    private bool m_isGard;

    /*カメラの変数*/
    private Vector3 m_cameraForward;
    private Vector3 m_moveForward;

    /*UI*/
    public Slider m_slider;
    


    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_boss = GameObject.Find("Boss");
        m_player = GameObject.Find("Player");
        m_attack = GameObject.Find("Attack");
        m_gard = GameObject.Find("Gard");
        m_hp = m_maxHp;
        m_slider.value = m_maxHp;
        //m_itemNum = 3;

        //m_speed = 5.0f;
        //m_acel = 2.0f;

        
        m_isDash = false;
        m_isItem = false;
        m_isGard = false;
        m_isAttack = false;

        m_itemFrame = 0;
        m_attackFrame = 0;

        m_inputHorizontal = 0;
        m_inputVertical = 0;

        m_attackTag = "PlayerAttack";
        m_gardTag = "PlayerGard";


    }

    void FixedUpdate()
    {
        Vector3 attackAdd = new Vector3(0, 0, 1);
        Vector3 gardAdd = new Vector3(0, 0, 0);

        m_playerPosition = this.transform.position;

        m_attackPosition = m_playerPosition + attackAdd;
        m_gardPosition = m_playerPosition + gardAdd;


        /*移動処理*/
        m_inputHorizontal = Input.GetAxis("Horizontal");
        m_inputVertical = Input.GetAxis("Vertical");

        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 m_cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 m_moveForward = m_cameraForward * m_inputVertical + Camera.main.transform.right * m_inputHorizontal;

        if (!m_isGard && !m_isAttack)
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

        if (!m_isGard && !m_isAttack)
        {
            // キャラクターの向きを進行方向に
            if (m_moveForward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(m_moveForward);
            }
        }





        /*ボタン操作*/
        //回復アイテムが残っていた場合
        if(m_itemNum > 0)
        {
            //Bボタン
            if (Input.GetButtonDown("Bbutton") && m_hp < 100)
            {
                m_isItem = true;
            }
        }


        //Xボタン
        if (Input.GetButton("Xbutton"))
        {
            m_isAttack = true;
        }


        //当たり判定を表示
        if (m_isAttack)
        {
            m_attackFrame++;
            m_attack.transform.position = m_attackPosition;

            m_attack.gameObject.SetActive(true);

            if (m_attackFrame >= kAttackFrameCountNum)
            {
                m_attackFrame = 0;
                m_isAttack = false;
                m_attack.gameObject.SetActive(false);

            }
        }

        //Yボタン
        if (Input.GetButtonDown("Ybutton"))
        {
            Debug.Log("ガード");
            m_isGard = true;
            SetTag(m_gardTag);
            //Debug.Log(m_player.tag);

        }
        else
        {
            m_isGard = false;
            SetTag(m_attackTag);
            //Debug.Log(m_player.tag);
            
        }

        //HPが減っていた場合
        if (m_isItem)
        {
            m_itemFrame++;
            if(m_itemFrame >= kItemFrameCountNum)
            {
                m_isItem = false;
                m_itemFrame = 0;
                m_hp += 10;
                m_slider.value = m_hp;//HPバーのUI変更

                m_itemNum--;


            }
        }





        //Debug.Log(m_frame);
        //Debug.Log(m_hp);
        //Debug.Log(m_hpNum);
    }

    void Update()
    {
        //Debug.Log(m_hp);




        //HPがゼロになったら
        if(m_hp <= 0)
        {
            ////LoseSceneに移行
            //SceneManager.LoadScene("SceneLose");
            Debug.Log("負け");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "EnemyAttack")
        {
            m_hp -= 10;
            m_slider.value = m_hp;//HPバーのUI変更
        }


    }



    private void SetTag(string newTag)
    {
        m_player.tag = newTag;
    }


}
