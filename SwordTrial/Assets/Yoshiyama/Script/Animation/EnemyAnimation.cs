using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyC;

public class EnemyAnimation : MonoBehaviour
{
    private string m_attack1 = "isAttack1";
    private string m_attack2 = "isAttack2";
    private string m_attack3 = "isAttack3";
    private string m_attack4 = "isAttack4";

    Animator m_anim;
    bool m_isPushFlag = false;

    private EnemyC m_pEnemy;
    private int m_animationNo;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
        //�����_���l�̒l�ɉ����ăA�j���[�V������؂�ւ���
        m_isPushFlag = false;

        m_pEnemy = GetComponent<EnemyC>();
    }


    // Update is called once per frame
    void Update()
    {
        m_animationNo = m_pEnemy.m_attackKinds;
        // �ʏ�U��
        if (Input.GetKeyDown("up"))
        {
            Debug.Log("�ʏ�U��");
            if (m_isPushFlag)
            {
                m_isPushFlag = false;
            }
            else
            {
                m_isPushFlag = true;
            }
            m_anim.SetBool(m_attack1, m_isPushFlag);
        }
        else if (Input.GetKeyDown("down"))
        {
            Debug.Log("���ߍU��");
            if (m_isPushFlag)
            {
                m_isPushFlag = false;
            }
            else
            {
                m_isPushFlag = true;
            }
            m_anim.SetBool(m_attack2, m_isPushFlag);
        }
        else if (Input.GetKeyDown("right"))
        {
            Debug.Log("�A���U��");
            if (m_isPushFlag)
            {
                m_isPushFlag = false;
            }
            else
            {
                m_isPushFlag = true;
            }
            m_anim.SetBool(m_attack3, m_isPushFlag);
        }
        else if (Input.GetKeyDown("left"))
        {
            Debug.Log("��]�U��");
            if (m_isPushFlag)
            {
                m_isPushFlag = false;
            }
            else
            {
                m_isPushFlag = true;
            }
            m_anim.SetBool(m_attack4, m_isPushFlag);
        }
        Debug.Log(m_animationNo);
    }
}
