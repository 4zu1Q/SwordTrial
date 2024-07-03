using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : EnemyC
{

    public string paramaterName = "";
    // Update is called once per frame
    void Update()
    {
        //�����_���l�̒l�ɉ����ăA�j���[�V������؂�ւ���
        bool m_pushFlag = false;

        // �ʏ�U��
        if (m_attackKinds == (int)AttackKinds.kNormalAttack)
        {
            Debug.Log("�ʏ�U��");
            m_pushFlag = true;
        }
        else if (m_attackKinds == (int)AttackKinds.kChargeAttack)
        {
            Debug.Log("���ߍU��");
            m_pushFlag = true;

        }
        else if (m_attackKinds == (int)AttackKinds.kComboAttack)
        {
            Debug.Log("�A���U��");
            m_pushFlag = true;
        }
        else if (m_attackKinds == (int)AttackKinds.kRotateAttack)
        {
            Debug.Log("��]�U��");
            m_pushFlag = true;
        }
        //�p�����[�^�̒l��ύX
        Animator m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetBool(paramaterName, m_pushFlag); 
    }
}
