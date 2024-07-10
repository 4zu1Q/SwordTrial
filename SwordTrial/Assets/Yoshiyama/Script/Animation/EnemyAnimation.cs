using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyC;

public class EnemyAnimation : MonoBehaviour
{
    private string m_attack1 = "Attack1";
    private string m_attack2 = "Attack2";
    private string m_attack3 = "Attack3";
    private string m_attack4 = "Attack4";

    Animator m_anim;
    bool m_isPushFlag1 = false;
    bool m_isPushFlag2 = false;
    bool m_isPushFlag3 = false;
    bool m_isPushFlag4 = false;
    private int m_animationInterval = 10;

    private EnemyC m_pEnemy;
    private int m_animationNo;
    private bool m_isGoTime = false;
    private float m_frame = 0;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
        //�����_���l�̒l�ɉ����ăA�j���[�V������؂�ւ���

        m_pEnemy = GetComponent<EnemyC>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("ahahahahahahahhah");
        // �ʏ�U��
        if (m_pEnemy.m_isAttackAnimation1 == true)
        {
            m_frame++;
            if (m_frame == 3)
            {
                m_anim.SetTrigger(m_attack1);
            }
            else if(m_frame == 200)
            {
                m_frame = 0;
            }
        }
        else if (m_pEnemy.m_isAttackAnimation2 == true)
        {
            m_frame++;
            if (m_frame == 3)
            {
                m_anim.SetTrigger(m_attack2);
            }
            else if (m_frame == 200)
            {
                m_frame = 0;
            }
        }
        else if (m_pEnemy.m_isAttackAnimation3 == true)
        {
            m_frame++;
            if (m_frame == 3)
            {
                m_anim.SetTrigger(m_attack3);
            }
            else if (m_frame == 200)
            {
                m_frame = 0;
            }
        }
        else if (m_pEnemy.m_isAttackAnimation4 == true)
        {
            m_frame++;
            if (m_frame == 3)
            {
                m_anim.SetTrigger(m_attack4);
            }
            else if (m_frame == 200)
            {
                m_frame = 0;
            }

        }

    }

}

