//�^�C�g����ʂ̃J�[�\���̑���

using UnityEngine;

public class TitleUICursor : UIOperationBase
{
    public enum SelectNum
    {
        kStart, //�X�^�[�g
        kOption,//�I�v�V����
        kEnd,   //�I��
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

    void Update()
    {
        UpdateFunction();
        SceneTransition();
        SlectUIColorChenge(m_isPress);

    }

    /// <summary>
    /// �V�[���J��
    /// </summary>
    private void SceneTransition()
    {
        //�{�^��������������
        PressButton();

        if (m_isPress && m_selectNum == (int)SelectNum.kStart)
        {
            m_selectItem[(int)SelectNum.kStart] = true;
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kOption)
        {
            //�����≹���̒����Ƃ��ł���悤�ȃE�B���h�E��W�J
            Debug.Log("�������J��");
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kEnd)
        {
            //�Q�[���I��������
            //End();
            Debug.Log("�Q�[���I��");
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
}
