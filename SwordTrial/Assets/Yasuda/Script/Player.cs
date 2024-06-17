using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���؂�ւ��̂���



public class Player : MonoBehaviour
{
    /*�X�e�[�^�X�ϐ�*/
    public int m_hp;

    /*�ړ��ϐ�*/

    /*�A�C�e���ϐ�*/
    public enum ItemType
    {
        kBom,   //�{��
        kHeal,  //��
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

        /*�ړ�����*/
        m_inputHorizontal = Input.GetAxis("Horizontal");
        m_inputVertical = Input.GetAxis("Vertical");

        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        Vector3 m_cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 m_moveForward = m_cameraForward * m_inputVertical + Camera.main.transform.right * m_inputHorizontal;

        // �ړ������ɃX�s�[�h���|����B
        m_rb.velocity = m_moveForward * m_moveSpeed;

        // �L�����N�^�[�̌�����i�s������
        if (m_moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(m_moveForward);
        }

        //Debug.Log(m_hp);
    }

    void Update()
    {

        //A�{�^��
        //�����Ă���Ԃ̓_�b�V������
        if (Input.GetButton("Abutton") && !m_isDash)
        {
            Debug.Log("dash");
            Debug.Log(m_frame);
            m_frame++;

            m_rb.velocity = m_moveForward * m_moveSpeed;
        }



        //B�{�^��
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


            //Y�{�^��
            if (Input.GetButtonDown("Ybutton"))
        {
            Debug.Log("nanimonasi");
        }

        //X�{�^��
        if (Input.GetButtonDown("Xbutton"))
        {
            Debug.Log("attack");

            //�����蔻���\��
            m_isAttack.enabled = true;

            Invoke("ColliderReset", 1.4f);

        }
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


///*�ϐ��錾*/
//public int m_hp;

//private GameObject m_target;  //Boss
//private GameObject m_camera;
//private float m_velocity;   //���x
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
//    m_target = GameObject.Find("Boss"); //�{�X�̏��
//    m_camera = GameObject.Find("MainCamera");

//    m_rb = GetComponent<Rigidbody>();

//    m_velocity = 0.001f;                 //���x
//    m_frame = 0;
//    //m_isDash = false;

//}

//// Update is called once per frame
//void Update()
//{
//    //�_�b�V������


//    //A�{�^��
//    //�����Ă���Ԃ̓_�b�V������
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

//    //B�{�^��
//    if (Input.GetButtonDown("Bbutton"))
//    {

//        Debug.Log("item");
//    }

//    //X�{�^��
//    if (Input.GetButtonDown("Xbutton"))
//    {

//        Debug.Log("attack");
//    }
//    else
//    {
//    }

//    //Y�{�^��
//    if (Input.GetButtonDown("Ybutton"))
//    {
//        Debug.Log("nanimonasi");
//        transform.position = new Vector3 (transform.position.x , transform.position.y + 0.8f, transform.position.z);
//    }

//    if (Input.GetButtonDown("Pause"))
//    {
//        Debug.Log("�|�[�Y");

//    }

//    if (Input.GetButtonDown("Target"))
//    {
//        Debug.Log("�^�[�Q�b�g");

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

//    //�C���v�b�g�l���擾
//    m_inputHorizontal = Input.GetAxisRaw("Horizontal");
//    m_inputVertical = Input.GetAxisRaw("Vertical");

//}

//private void FixedUpdate()
//{
//    //�J�����̕�������AX�AZ���ʂ̒P�ʃx�N�g�����擾
//    //Vector3 cameraFoward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
//    Vector3 cameraFoward = Vector3.Scale(m_camera.transform.position, new Vector3(1, 0, 1)).normalized;

//    //�����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
//    //Vector3 moveForward = cameraFoward * m_inputVertical + Camera.main.transform.right * m_inputHorizontal;
//    Vector3 moveForward = cameraFoward * m_inputVertical + m_camera.transform.position * m_inputHorizontal;

//    //�ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
//    m_rb.velocity = moveForward * m_velocity + new Vector3(0, m_rb.velocity.y, 0);
//    //transform.position = moveForward * m_velocity + new Vector3(0, 9, 0);

//    //transform.position += new Vector3(m_inputHorizontal, m_rb.velocity.y, m_inputVertical);

//    //�L�����N�^�[�̌�����i�s������
//    if (moveForward != Vector3.zero)
//    {
//        transform.rotation = Quaternion.LookRotation(moveForward);
//    }

//    //Debug.Log(cameraFoward);

//}