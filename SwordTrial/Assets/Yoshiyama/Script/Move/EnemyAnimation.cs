using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    private string paramaterName = "Attack1";

    Animator m_anim;
    bool m_pushFlag = false;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
        //�����_���l�̒l�ɉ����ăA�j���[�V������؂�ւ���
        m_pushFlag = false;
    }


    // Update is called once per frame
    void Update()
    {
        

        // �ʏ�U��
        if (Input.GetKeyDown("up"))
        {
            Debug.Log("�ʏ�U��");
            if(m_pushFlag)
            {
                m_pushFlag = false;
            }
            else
            {
                m_pushFlag = true;
            }

            
        }
        //else if (Input.GetKeyDown("down"))
        //{
        //    Debug.Log("���ߍU��");
        //    m_pushFlag = true;
        //}
        //else if (Input.GetKeyDown("right"))
        //{
        //    Debug.Log("�A���U��");
        //    m_pushFlag = true;
        //}
        //else if (Input.GetKeyDown("left"))
        //{
        //    Debug.Log("��]�U��");
        //    m_pushFlag = true;
        //}

        //�p�����[�^�̒l��ύX

        m_anim.SetBool(paramaterName, m_pushFlag);

        Debug.Log(m_pushFlag);
    }
}
