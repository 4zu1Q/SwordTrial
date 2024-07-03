using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : EnemyC
{
    CharacterController m_controller;
    Animator m_animator;

    public string paramaterName = "";

    void Start()
    {
        //必要なコンポーネントを自動取得
        m_controller = GetComponent<CharacterController>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //ランダム値の値に応じてアニメーションを切り替える
        bool m_pushFlag = false;

        // 通常攻撃
        if (m_attackKinds == (int)AttackKinds.kNormalAttack)
        {
            Debug.Log("通常攻撃");
            m_pushFlag = true;
            m_animator.SetTrigger("Attack1");
        }
        else if (m_attackKinds == (int)AttackKinds.kChargeAttack)
        {
            Debug.Log("溜め攻撃");
            m_pushFlag = true;
            m_animator.SetTrigger("Attack2");
        }
        else if (m_attackKinds == (int)AttackKinds.kComboAttack)
        {
            Debug.Log("連続攻撃");
            m_pushFlag = true;
            m_animator.SetTrigger("Attack3");
        }
        else if (m_attackKinds == (int)AttackKinds.kRotateAttack)
        {
            Debug.Log("回転攻撃");
            m_pushFlag = true;
            m_animator.SetTrigger("Attack4");
        }
        //パラメータの値を変更
        Animator m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetBool(paramaterName, m_pushFlag); 
    }
}
