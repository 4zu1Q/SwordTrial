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
    public bool m_isPushFlag1 = false;
    public bool m_isPushFlag2 = false;
    public bool m_isPushFlag3 = false;
    public bool m_isPushFlag4 = false;
    private int m_animationInterval = 10;

    private EnemyC m_pEnemy;
    private int m_animationNo;
    private bool m_isGoTime = false;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
        //ランダム値の値に応じてアニメーションを切り替える

        m_pEnemy = GetComponent<EnemyC>();
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("ahahahahahahahhah");
        // 通常攻撃
        if (m_pEnemy.m_isAttackAnimation1 == true && m_isPushFlag1 == false)
        {
            m_isPushFlag1 = true;
            m_isGoTime = true;
        }
        else if (m_pEnemy.m_isAttackAnimation2 == true && m_isPushFlag2 == false)
        {
            m_isPushFlag2 = true;
            m_isGoTime = true;
        }
        else if (m_pEnemy.m_isAttackAnimation3 == true && m_isPushFlag3 == false)
        {
            m_isPushFlag3 = true;
            m_isGoTime = true;
        }
        else if (m_pEnemy.m_isAttackAnimation4 == true && m_isPushFlag4 == false)
        {
            m_isPushFlag4 = true;
            m_isGoTime = true;
        }
        if (m_isGoTime == true)
        {
            m_animationInterval++;
        }
        if (m_animationInterval >= 400)
        {
            //m_isPushFlag1 = false;
            //m_isPushFlag2 = false;
            //m_isPushFlag3 = false;
            //m_isPushFlag4 = false;
            m_animationInterval = 0;
            Debug.Log("hai");
        }
        m_anim.SetBool(m_attack1, m_isPushFlag1);
        m_anim.SetBool(m_attack2, m_isPushFlag2);
        m_anim.SetBool(m_attack3, m_isPushFlag3);
        m_anim.SetBool(m_attack4, m_isPushFlag4);

        Debug.Log(m_isPushFlag1);
        Debug.Log(m_isPushFlag2);
        Debug.Log(m_isPushFlag3);
        Debug.Log(m_isPushFlag4);
    }

}

