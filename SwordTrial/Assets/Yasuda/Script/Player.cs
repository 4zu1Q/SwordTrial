using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���؂�ւ��̂���



public class Player : MonoBehaviour
{
    /*�X�e�[�^�X�ϐ�*/
    [SerializeField] public int m_hp;
    [SerializeField] private int m_hpNum;
    [SerializeField] private float m_speed;
    [SerializeField] private float m_acel;


    /*�I�u�W�F�N�g�ϐ�*/
    GameObject m_boss;
    GameObject m_player;
    Transform m_attack;

    /*�^�O�ϐ�*/
    private string m_attackTag;
    private string m_gardTag;

    /*�t���[���ϐ�*/
    private int m_frame;

    /*�ړ��ϐ�*/
    private float m_inputHorizontal;
    private float m_inputVertical;
    private Rigidbody m_rb;

    private bool m_isDash;
    private bool m_isItem;
    private bool m_isGard;

    /*�J�����̕ϐ�*/
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
        /*�ړ�����*/
        m_inputHorizontal = Input.GetAxis("Horizontal");
        m_inputVertical = Input.GetAxis("Vertical");

        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        Vector3 m_cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 m_moveForward = m_cameraForward * m_inputVertical + Camera.main.transform.right * m_inputHorizontal;

        if (!m_isGard)
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

        // �L�����N�^�[�̌�����i�s������
        if (m_moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(m_moveForward);
        }

        /*�{�^������*/



        //B�{�^��
        if(m_hpNum > 0)
        {
            if (Input.GetButtonDown("Bbutton") && m_hp < 100)
            {
                m_isItem = true;

            }
        }


        //X�{�^��
        if (Input.GetButtonDown("Xbutton"))
        {
            Debug.Log("attack");

            //�����蔻���\��
            //m_attack.gameObject.SetActive(true);
            //SetTag(m_gardTag);
        }
        else
        {
            //m_attack.gameObject.SetActive(false);
            //SetTag(m_attackTag);
        }

        //Y�{�^��
        if (Input.GetButton("Ybutton"))
        {
            //Debug.Log("�K�[�h");
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

        //HP�������Ă����ꍇ
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

        //LT�{�^��
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


        //�E�X�e�B�b�N��������
        if (Input.GetButtonDown("Target"))
        {
            Debug.Log("�^�[�Q�b�g");
        }


        //HP���[���ɂȂ�����
        if(m_hp <= 0)
        {
            ////LoseScene�Ɉڍs
            //SceneManager.LoadScene("SceneLose");
            Debug.Log("����");
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
