using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : UIOperationBase
{
    public enum SelectNum
    {
        kBack, //�߂�
        kTitleBack,   //�^�C�g���ɖ߂�
        kMaxNum
    }
    public PauseMenu m_pauseMenu;//�X�N���v�g�̎擾
    public Image m_pauseImage;//�|�[�Y�̉摜�擾
    public Image m_defaultPauseImage;//�|�[�Y�̉摜�擾
    //�I������Ă��鍀��
    public bool[] m_pauseNum;
    private bool m_isPress;
    private bool m_isPauseOpen;
    protected override void Start()
    {
        base.Start();
        m_pauseNum = new bool[(int)SelectNum.kMaxNum];
        m_isPress = false;
        m_isPauseOpen = false;
        m_defaultPauseImage = m_pauseImage;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateFunction();
        PauseUpdate();
        SlectUIColorChenge(m_isPress);

    }
    /// <summary>
    /// �|�[�Y��ʂ̏���
    /// </summary>
    private void PauseUpdate()
    {
        //�{�^��������������
        PressButton();
        //�|�[�Y����Q�[���ɖ߂鏈��
        if (m_isPress && m_selectNum == (int)SelectNum.kBack)
        {
            //�|�[�Y��ʂ��J���t���O��ύX����
            m_pauseMenu.GetPauseFlag(false);
            //�������t���O��߂��Ă���
            m_isPress = false;
            Debug.Log("���ǂ��");
        }
        //�|�[�Y����^�C�g���ɖ߂鏈��
        else if (m_isPress && m_selectNum == (int)SelectNum.kTitleBack)
        {
            //�����≹���̒����Ƃ��ł���悤�ȃE�B���h�E��W�J
            m_pauseNum[(int)SelectNum.kTitleBack] = true;
            Debug.Log("�������J��");
        }
        if(!m_pauseMenu.GetMenu())
        {
            PauseImgInit();
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
        if (Input.GetButtonDown("Abutton"))
        {
            m_isPress = false;
        }

        DecisionUpdate(m_isPress);
    }

    private void PauseOpenEffect()
    {
        if (!m_isPauseOpen)
        {
            m_pauseImage.transform.DOMoveX(10,
            10.2f).SetEase(Ease.OutCubic);
            m_isPauseOpen = true;
        }
    }
    public void PauseImgInit()
    {
        if (!m_isPauseOpen)
        {
            m_pauseImage = m_defaultPauseImage;
            m_isPauseOpen = false;
        }
    }
}
