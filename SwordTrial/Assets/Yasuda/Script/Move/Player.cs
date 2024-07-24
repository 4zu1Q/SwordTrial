using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン切り替えのため
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    /*ステータス変数*/
    [SerializeField] public int m_itemNum;       //アイテムの個数
    [SerializeField] private float m_speed;
    [SerializeField] private float m_acel;
    [SerializeField] public int m_hp;

    /*オブジェクト変数*/
    GameObject m_boss;
    GameObject m_player;
    GameObject m_attack;
    public GameObject m_itemNumText;
    //Transform m_attack;

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
    [SerializeField] private int kAttackSeNum;
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
    Text m_text;

    /*ポーズ用変数*/
    public bool m_isPause;

    /*SE用変数*/
    public AudioClip m_attackSe;
    public AudioClip m_healSe;
    public AudioClip m_damageSe;

    AudioSource m_audioSource;


    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_boss = GameObject.Find("Boss");
        m_player = GameObject.Find("Player");
        m_attack = GameObject.Find("Attack");
        //m_player.transform.Find("Attack");

        m_slider.value = m_hp;

        //m_text = m_itemNumText.GetComponent<Text>();

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

        m_isPause = true;

        m_audioSource = GetComponent<AudioSource>();

        m_attack.SetActive(false);

    }

    void FixedUpdate()
    {
        
        if (!m_isPause) return;
        
        m_text = m_itemNumText.GetComponent<Text>();
        
        m_text.text = "x" + m_itemNum;
        
        m_playerPosition = this.transform.position;
        
        m_attackPosition = m_playerPosition;
        m_gardPosition = m_playerPosition;


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
        if (m_itemNum > 0)
        {
            //Bボタン
            if (Input.GetButtonDown("Bbutton") && m_hp < 100)
            {
                m_isItem = true;
            }
        }

        //HPが減っていた場合
        if (m_isItem)
        {
            m_itemFrame++;
            if (m_itemFrame >= kItemFrameCountNum)
            {
                m_isItem = false;
                m_itemFrame = 0;
                m_hp += 10;
                m_slider.value = m_hp;//HPバーのUI変更
                m_audioSource.PlayOneShot(m_healSe);
                m_itemNum--;


            }
        }

        //Xボタン
        if (Input.GetButtonDown("Xbutton"))
        {
            m_isAttack = true;

        }


        //当たり判定を表示
        if (m_isAttack)
        {

            m_attackFrame++;

            m_attack.SetActive(true);

            if(m_attackFrame == kAttackSeNum)
            {
                m_audioSource.PlayOneShot(m_attackSe);
            }

            if (m_attackFrame >= kAttackFrameCountNum)
            {

                //Debug.Assert(m_attack == null);

                m_attackFrame = 0;
                m_isAttack = false;
                m_attack.SetActive(false);
            }
        }

        Debug.Log(m_hp);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!m_isPause) return;

        if (collision.transform.tag == "EnemyAttack")
        {
            m_hp -= 10;
            m_slider.value = m_hp;//HPバーのUI変更
            m_audioSource.PlayOneShot(m_damageSe);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "EnemyAttack")
        {
            Debug.Log("攻撃");
            m_hp -= 10;
            m_slider.value = m_hp;//HPバーのUI変更
        }
    }


    private void SetTag(string newTag)
    {
        m_player.tag = newTag;
    }


}
