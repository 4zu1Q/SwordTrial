using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject m_playerObj;
    private Vector3 m_targetPos;
    private Transform m_transform;

    // Start is called before the first frame update
    void Start()
    {
        m_playerObj = GameObject.Find("Player");
        m_targetPos = m_playerObj.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̈ړ��ʕ��A�J�������ړ�����
        m_transform.position += m_playerObj.transform.position - m_targetPos;
        m_targetPos = m_playerObj.transform.position - m_targetPos;

        //�v���C���[���ړ����Ă����
        if(Input.GetMouseButtonDown(0))
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputZ = Input.GetAxis("Vertical");

            //�v���C���[�̈ʒu��Y���𒆐S�ɁA��]����
            m_transform.RotateAround(m_targetPos, Vector3.up, inputX * Time.deltaTime * 200f);
        }



    }
}
