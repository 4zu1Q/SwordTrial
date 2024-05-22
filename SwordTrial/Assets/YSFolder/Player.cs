using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Player : MonoBehaviour
{
    /*�ϐ��錾*/
    GameObject target;  
    private float m_velocity;
    private bool m_isMove;  //�ړ��ł��邩�̃t���O

    private Vector3 m_prevPos;  //�O��


    // Start is called before the first frame update
    void Start()
    {
        //Mathf.Sin(Radian);


        m_velocity = 0.01f;
        m_isMove = false;



    }

    // Update is called once per frame
    void Update()
    {
       

        //�_�b�V������

        //A�{�^��
        //�����Ă���Ԃ̓_�b�V������
        if (Input.GetButton("Abutton"))
        {
            m_velocity = 0.02f;
            Debug.Log("dash");
        }
        else m_velocity = 0.01f;
        

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
        float inputX = Input.GetAxis("Horizontal") * m_velocity;
        float inputZ = Input.GetAxis("Vertical") * m_velocity;


        if (!m_isMove)
        {
            //�ړ�����
            transform.position = new Vector3(transform.position.x + inputX, transform.position.y, transform.position.z + inputZ);

        }
    }
}
