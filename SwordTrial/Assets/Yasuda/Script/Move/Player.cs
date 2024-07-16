using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���؂�ւ��̂���
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    /*�X�e�[�^�X�ϐ�*/
    [SerializeField] private int m_itemNum;       //�A�C�e���̌�
    [SerializeField] private float m_speed;
    [SerializeField] private float m_acel;
    [SerializeField] public int m_maxHp;
    [SerializeField] public int m_hp;

    /*�I�u�W�F�N�g�ϐ�*/
    GameObject m_boss;
    GameObject m_player;
    GameObject m_attack;
    GameObject m_gard;

    /*�I�u�W�F�N�g�̍��W�ϐ�*/
    private Vector3 m_playerPosition;
    private Vector3 m_attackPosition;
    private Vector3 m_gardPosition;

    /*�^�O�ϐ�*/
    private string m_attackTag;
    private string m_gardTag;

    /*�t���[���ϐ�*/
    [SerializeField] private int m_itemFrame;
    [SerializeField] private int m_attackFrame;

    /*�萔*/
    [SerializeField] private int kItemFrameCountNum;
    [SerializeField] private int kAttackFrameCountNum;
    [SerializeField] private int kAttackPower;

    /*�ړ��ϐ�*/
    private float m_inputHorizontal;
    private float m_inputVertical;
    private Rigidbody m_rb;

    private bool m_isDash;
    private bool m_isItem;
    private bool m_isAttack;
    private bool m_isGard;

    /*�J�����̕ϐ�*/
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


        /*�ړ�����*/
        m_inputHorizontal = Input.GetAxis("Horizontal");
        m_inputVertical = Input.GetAxis("Vertical");

        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        Vector3 m_cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 m_moveForward = m_cameraForward * m_inputVertical + Camera.main.transform.right * m_inputHorizontal;

        if (!m_isGard && !m_isAttack)
        {
            // �ړ������ɃX�s�[�h���|����B
            m_rb.velocity = m_moveForward * m_speed;

            //A�{�^��
            //�����Ă���Ԃ̓_�b�V������
            if (Input.GetButton("Abutton") && !m_isDash)
            {

                m_rb.velocity = m_moveForward * m_speed * m_acel;
            }
        }

        //Debug.Log("���x�x�N�g��: " + m_rb.velocity);

        if (!m_isGard && !m_isAttack)
        {
            // �L�����N�^�[�̌�����i�s������
            if (m_moveForward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(m_moveForward);
            }
        }





        /*�{�^������*/
        //�񕜃A�C�e�����c���Ă����ꍇ
        if(m_itemNum > 0)
        {
            //B�{�^��
            if (Input.GetButtonDown("Bbutton") && m_hp < 100)
            {
                m_isItem = true;
            }
        }


        //X�{�^��
        if (Input.GetButton("Xbutton"))
        {
            m_isAttack = true;
        }


        //�����蔻���\��
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

        //Y�{�^��
        if (Input.GetButtonDown("Ybutton"))
        {
            Debug.Log("�K�[�h");
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

        //HP�������Ă����ꍇ
        if (m_isItem)
        {
            m_itemFrame++;
            if(m_itemFrame >= kItemFrameCountNum)
            {
                m_isItem = false;
                m_itemFrame = 0;
                m_hp += 10;
                m_slider.value = m_hp;//HP�o�[��UI�ύX

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




        //HP���[���ɂȂ�����
        if(m_hp <= 0)
        {
            ////LoseScene�Ɉڍs
            //SceneManager.LoadScene("SceneLose");
            Debug.Log("����");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "EnemyAttack")
        {
            m_hp -= 10;
            m_slider.value = m_hp;//HP�o�[��UI�ύX
        }


    }



    private void SetTag(string newTag)
    {
        m_player.tag = newTag;
    }


}
