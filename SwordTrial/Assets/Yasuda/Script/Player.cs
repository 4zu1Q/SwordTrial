using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���؂�ւ��̂���



public class Player : MonoBehaviour
{
    /*�X�e�[�^�X�ϐ�*/
    public int m_hp;

    /*�ړ��ϐ�*/
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
    private bool m_isGard;
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
        m_isGard = false;
        m_isItem = false;
        m_frame = 0;

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

        if(!m_isGard)
        {
            // �ړ������ɃX�s�[�h���|����B
            m_rb.velocity = m_moveForward * m_moveSpeed;

            //A�{�^��
            //�����Ă���Ԃ̓_�b�V������
            if (Input.GetButton("Abutton") && !m_isDash)
            {

                m_rb.velocity = m_moveForward * m_moveSpeed * 2.0f;
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
        if (Input.GetButtonDown("Bbutton"))
        {
            m_isItem = true;

        }

        //X�{�^��
        if (Input.GetButtonDown("Xbutton"))
        {
            Debug.Log("attack");

            //�����蔻���\��
            m_attack.gameObject.SetActive(true);

        }
        else
        {
            m_attack.gameObject.SetActive(false);

        }

        //Y�{�^��
        if (Input.GetButton("Ybutton"))
        {
            Debug.Log("�K�[�h");
            m_gard.gameObject.SetActive(true);
            m_isGard = true;
        }
        else
        {
            m_gard.gameObject.SetActive(false);
            m_isGard = false;

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

        //LT�{�^��
        if (Input.GetButtonDown("LT"))
        {


        }

        Debug.Log(m_frame);



        Debug.Log(m_hp);
    }

    void Update()
    {



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

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "PlayerAttack")
        {
            //m_rb.velocity = -m_moveForward * m_moveSpeed * 2.0f;
            
            m_hp -= 10;
        }
    }


}
