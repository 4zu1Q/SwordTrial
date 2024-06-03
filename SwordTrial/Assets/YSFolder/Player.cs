using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Player : MonoBehaviour
{
    /*�ϐ��錾*/
    GameObject target;  
    private float m_velocity;   //���x
    private float m_rotateSpeed;   //��]���鑬�x
    private bool m_isMove;  //�ړ��ł��邩�̃t���O

    private int m_frame;
    private bool m_isDash;

    private Vector3 m_prevPos;  //�O��
    private Rigidbody m_rd;

    // Start is called before the first frame update
    void Start()
    {
        //Mathf.Sin(Radian);


        m_velocity = 0.01f;
        m_rotateSpeed = 0.1f;
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

        /*�v���C���[�ړ�����*/

        //�C���v�b�g�l���擾
        float inputX = Input.GetAxis("Horizontal") * m_velocity;
        float inputZ = Input.GetAxis("Vertical") * m_velocity;

        //float inputX = Input.GetAxis("Horizontal");
        //float inputZ = Input.GetAxis("Vertical");


        if (!m_isMove)
        {
            //�ړ�����
            transform.position = new Vector3(transform.position.x + inputX, transform.position.y, transform.position.z + inputZ);

            ////
            //Vector3 cameraFoward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1).normalized);

            ////
            //Vector3 moveForward = cameraFoward * inputX + Camera.main.transform.right * inputZ;

            //


        }




        /*�A�i���O�X�e�B�b�N�̏���*/
        //float degree = Mathf.Atan2(inputX, inputZ) * Mathf.Rad2Deg;

        //if(degree < 0)
        //{
        //    degree += 360;
        //}

        ////�E�X�e�B�b�N�ŉ�]����
        //transform.Rotate(new Vector3(0.0f, m_rotateSpeed * Input.GetAxis("Horizontal2"), 0.0f));
        ////transform.Rotate(new Vector3(0.0f, m_rotateSpeed * degree, 0.0f));

        //Debug.Log(degree);


    }
}
