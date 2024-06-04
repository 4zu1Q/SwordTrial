using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Player : MonoBehaviour
{
    /*�ϐ��錾*/
    private GameObject m_target;  //Boss
    private float m_velocity;   //���x
    private float m_moveSpeed;
    private bool m_isMove;  //�ړ��ł��邩�̃t���O

    private float m_inputHorizontal;
    private float m_inputVertical;

    private int m_frame;
    private bool m_isDash;

    private Vector3 m_prevPos;  //�O��
    private Rigidbody m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_target = GameObject.Find("Boss"); //�{�X�̏��

        m_rb = GetComponent<Rigidbody>();

        m_velocity = 0.01f;                 //���x
        m_moveSpeed = 3.0f;                 //
        m_frame = 0;
        m_isMove = false;
        m_isDash = false; 

    }

    // Update is called once per frame
    void Update()
    {
        //�_�b�V������

        //A�{�^��
        //�����Ă���Ԃ̓_�b�V������
        if (Input.GetButton("Abutton") )
        {
            m_frame++;
            m_velocity = 0.02f;
            Debug.Log("dash");
        }
        else m_velocity = 0.01f;
        
        if(m_frame>=30)
        {
            m_isDash = true;

        }
        else
        {
            m_isDash=false;
        }

        //B�{�^��
        if (Input.GetButtonDown("Bbutton"))
        {

            Debug.Log("item");
        }

        //X�{�^��
        if (Input.GetButtonDown("Xbutton"))
        {

            Debug.Log("attack");
            m_isMove = true;
        }
        else
        {
            m_isMove = false;
        }

        //Y�{�^��
        if (Input.GetButtonDown("Ybutton"))
        {
            Debug.Log("nanimonasi");
            transform.position = new Vector3 (transform.position.x , transform.position.y + 0.8f, transform.position.z);
        }

        if (Input.GetButtonDown("Pause"))
        {
            Debug.Log("�|�[�Y");

        }

        if (Input.GetButtonDown("Target"))
        {
            Debug.Log("�^�[�Q�b�g");

        }

        if (Input.GetButtonDown("R1"))
        {
            Debug.Log("R1");

        }

        //if (Input.GetButtonDown("R2"))
        //{

        //}

        //�C���v�b�g�l���擾
        m_inputHorizontal = Input.GetAxis("Horizontal") * m_velocity;
        m_inputVertical = Input.GetAxis("Vertical") * m_velocity;

    }

    private void FixedUpdate()
    {
        //�J�����̕�������AX�AZ���ʂ̒P�ʃx�N�g�����擾
        Vector3 cameraFoward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        //�����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraFoward * m_inputVertical + Camera.main.transform.right * m_inputHorizontal;
        //�ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
        m_rb.velocity = moveForward * m_moveSpeed + new Vector3(0, m_rb.velocity.y, 0);

        //�L�����N�^�[�̌�����i�s������
        if(moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }

    }
}
