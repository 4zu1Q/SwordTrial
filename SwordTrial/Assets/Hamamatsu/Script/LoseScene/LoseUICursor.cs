//�s�k��ʂ̃J�[�\������

using UnityEngine;

public class LoseUICursor : UIOperationBase
{
    public enum SelectNum
    {
        kContinue, //�R���e�j���[
        kHome,//�z�[����
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
        //A�{�^������������
        if (m_isPress && m_selectNum == (int)SelectNum.kContinue)
        {
            m_selectItem[(int)SelectNum.kContinue] = true;
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kHome)
        {
            m_selectItem[(int)SelectNum.kHome] = true;
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
