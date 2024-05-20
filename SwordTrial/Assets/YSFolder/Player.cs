using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Player : MonoBehaviour
{
    /*�ϐ��錾*/
    GameObject target;  
    private float m_velocity;
    private bool m_isMove;  //�ړ��ł��邩�̃t���O

    

    // Start is called before the first frame update
    void Start()
    {
        m_velocity = 0.01f;
        m_isMove = false;   

    }

    // Update is called once per frame
    void Update()
    {
       

        //�_�b�V������

        //A�{�^��
        if (Input.GetButton("Fire1"))
        {
            m_velocity = 0.02f;
            Debug.Log("dash");
        }
        else m_velocity = 0.01f;
        

        //B�{�^��
        if (Input.GetButtonDown("Fire2"))
        {

            Debug.Log("item");
        }

        //X�{�^��
        if (Input.GetButtonDown("Fire3"))
        {

            Debug.Log("attack");
            m_isMove = true;
        }
        else
        {
            m_isMove = false;
        }

        //Y�{�^��
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("nanimonasi");
        }


        float inputX = Input.GetAxis("Horizontal") * m_velocity;
        float inputZ = Input.GetAxis("Vertical") * m_velocity;


        if (!m_isMove)
        {
            //�ړ�����
            transform.position = new Vector3(transform.position.x + inputX, transform.position.y, transform.position.z + inputZ);

        }
    }
}
