using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    /*�ϐ�*/
    //private string m_walk = "isWalk";
    //private string m_attack = "isAttack";
    //private string m_dash = "isDash";
    //private string m_gard = "isGard";
    //private string m_item = "isItem";
    //private string m_damage = "isDamage";
    //private string m_win = "isWin";
    //private string m_lose = "isLose";

    //�A�j���[�V�����̃g���K�[
    private string m_idle = "Idle";         //�ҋ@
    private string m_run = "Run";           //����
    private string m_dash = "Dash";         //�_�b�V��
    private string m_attack = "Attack";     //�U��
    private string m_recovery = "Recovery"; //��
    private string m_guard = "Guard";       //�h��

    Animator m_anim;

    //���݂̃t���[����
    private int m_currentFlameNum = 0;
    //�ҋ@��ԂɑJ�ڂ���^�C�~���O
    private int m_changeFlameNum = 0;

    private string m_currentAnim;

    //�Q�[���p�b�h���͒l-----------------------------------

    //�E�X�e�B�b�N�̓��͒l
    private float m_leftStickHorizontal = 0;
    private float m_leftStickVertical = 0;

    private bool m_walkStick = false;           // �ړ��X�e�B�b�N

    private bool m_dashAButton = false;         // �_�b�V���{�^��
    private bool m_recoveryBButton = false;     // �񕜃{�^��
    private bool m_attackXButton = false;       // �U���{�^��
    private bool m_guardYButton = false;        // �h��{�^��

    //-----------------------------------------------------


    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GamePadInputUpdate();
        AnimTransitionUpdate();
    }

    private void FixedUpdate()
    {
        m_currentFlameNum++;

        AnimEnd(m_currentAnim);
    }

    /// <summary>
    /// �A�j���[�V�����I�����̏���
    /// </summary>
    private void AnimEnd(string anim)
    {
        if (m_currentFlameNum == m_changeFlameNum)
        {
            m_anim.SetBool(anim, false);
        }
    }

    /// <summary>
    /// �A�j���[�V�����J��
    /// </summary>
    private void AnimTransitionUpdate()
    {
        //��
        if (m_recoveryBButton)
        {
            NextAnim(m_recovery, 0, 30);
            m_recoveryBButton = false;
        }
        //�U��
        else if(m_attackXButton)
        {
            NextAnim(m_attack, 0, 19);
            m_attackXButton = false;
        }

        //�ړ�
        if (m_walkStick)
        {
            m_anim.SetBool(m_run, true);
            if (!m_dashAButton)
            {
                m_anim.SetBool(m_dash, false);
            }
            else if (m_dashAButton)
            {
                m_anim.SetBool(m_dash, true);
            }
        }
        else if (!m_walkStick)
        {
            m_anim.SetBool(m_run, false);
            m_anim.SetBool(m_dash, false);
        }
        //�h��
        if (m_guardYButton)
        {
            m_anim.SetBool(m_guard, true);
        }
        else if (!m_guardYButton)
        {
            m_anim.SetBool(m_guard, false);
        }
    }

    /// <summary>
    /// ���ɑJ�ڂ���A�j���[�V�����̏��
    /// </summary>
    /// <param name="m_nextAnim">���̃A�j���[�V����</param>
    /// <param name="currentFlameNum">���݂̃t���[��</param>
    /// <param name="changeFlameNum">�ҋ@��ԂɑJ�ڂ���^�C�~���O</param>
    private void NextAnim(string m_nextAnim, int currentFlameNum, int changeFlameNum)
    {
        m_anim.SetBool(m_nextAnim, true);
        m_currentFlameNum = currentFlameNum;
        m_changeFlameNum = changeFlameNum;
        m_currentAnim = m_nextAnim;
    }

    /// <summary>
    /// �R���g���[���[�̓��͏��X�V
    /// </summary>
    private void GamePadInputUpdate()
    {
        //���X�e�B�b�N�̓��͏��
        m_leftStickHorizontal = Input.GetAxis("Horizontal");
        m_leftStickVertical = Input.GetAxis("Vertical");

        if(m_leftStickHorizontal != 0 || m_leftStickVertical != 0)
        {
            m_walkStick = true;
        }
        else if(m_leftStickHorizontal == 0 && m_leftStickVertical == 0)
        {
            Debug.Log("ddd");
            m_walkStick = false;
        }

        // �{�^�����������u��
        if (Input.GetButtonDown("Abutton"))
        {
            m_dashAButton = true;
        }
        else if(Input.GetButtonDown("Bbutton"))
        {
            m_recoveryBButton = true;
        }
        else if (Input.GetButtonDown("Ybutton"))
        {
            m_guardYButton = true;
        }
        else if (Input.GetButtonDown("Xbutton"))
        {
            m_attackXButton = true;
        }

        if (Input.GetButtonUp("Abutton"))
        {
            m_dashAButton = false;
        }
        else if(Input.GetButtonUp("Ybutton"))
        {
            m_guardYButton = false;
        }
    }
}
