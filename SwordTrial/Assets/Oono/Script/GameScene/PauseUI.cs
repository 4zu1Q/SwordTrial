using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : UIOperationBase
{
    public enum SelectNum
    {
        kBack, //�߂�
        kTitleBack,   //�^�C�g���ɖ߂�
        kMaxNum
    }
    //�I������Ă��鍀��
    public bool[] m_selectItem;
    private bool m_isPress;

    protected override void Start()
    {
        base.Start();
        m_selectItem = new bool[(int)SelectNum.kMaxNum];
        m_isPress = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFunction();
        PauseUpdate();
    }
    /// <summary>
    /// �|�[�Y��ʂ̏���
    /// </summary>
    private void PauseUpdate()
    {
        //�{�^��������������
        PressButton();

        if (m_isPress && m_selectNum == (int)SelectNum.kBack)
        {
            m_selectItem[(int)SelectNum.kBack] = true;
            SlectUIColorChenge();
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kTitleBack)
        {
            //�����≹���̒����Ƃ��ł���悤�ȃE�B���h�E��W�J
            Debug.Log("�������J��");
            SlectUIColorChenge();
        }
    }

    /// <summary>
    /// �{�^�����������Ƃ��̏���
    /// </summary>
    private void PressButton()
    {
        //�{�^��������������
        if (Input.GetButtonDown("Bbutton"))
        {
            m_isPress = true;
        }

        DecisionUpdate(m_isPress);
    }
}
