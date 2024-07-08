//�T�E���h�̍X�V����
using UnityEngine;

public class SoundUICursor : UIOperationBase
{
    public enum SelectNum
    {
        kMastar, //BGM
        kBGM, //BGM
        kSE,//SE
        kEnd,//�����
        kMaxNum
    }

    //�I������Ă��鍀��
    public bool[] m_selectItem;
    private bool m_isPress;
    public bool m_isOptionCancellation;

    protected override void Start()
    {
        base.Start();
        m_selectItem = new bool[(int)SelectNum.kMaxNum];
        m_isPress = false;
        m_isOptionCancellation = false;
    }

    void Update()
    {
        if(!m_isOptionCancellation) { return; }
        CursorTransition();
        SlectUIColorChenge(m_isPress);
        UpdateFunction();
    }

    /// <summary>
    /// �V�[���J��
    /// </summary>
    private void CursorTransition()
    {
        //�{�^��������������
        PressButton();

        if (m_isPress && m_selectNum == (int)SelectNum.kMastar)
        {
            m_selectItem[(int)SelectNum.kMastar] = true;
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kBGM)
        {
            m_selectItem[(int)SelectNum.kBGM] = true;
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kSE)
        {
            //�����≹���̒����Ƃ��ł���悤�ȃE�B���h�E��W�J
            m_selectItem[(int)SelectNum.kSE] = true;
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kEnd)
        {
            m_isOptionCancellation = false;
            //�I��������
            Debug.Log("�Ƃ���");
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
            m_selectItem[(int)SelectNum.kMastar] = false;
            m_selectItem[(int)SelectNum.kBGM] = false;
            m_selectItem[(int)SelectNum.kSE] = false;

            m_isPress = false;
        }

        DecisionUpdate(m_isPress);
    }
    public void CursorReset()
    {
        m_isPress = false;
        m_selectNum = 0;
    }
}
