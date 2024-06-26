//������ʂ̃J�[�\������

using UnityEngine;

public class VictoryUICursor : UIOperationBase
{
    public enum SelectNum
    {
        KRetry, //�X�^�[�g
        kHome,//�^�C�g��
        kMaxNum
    }

    //�I������Ă��鍀��
    public bool[] m_selectItem;

    protected override void Start()
    {
        base.Start();
        m_selectItem = new bool[(int)SelectNum.kMaxNum];
    }

    void Update()
    {
        UpdateFunction();
        SceneTransition();
    }

    /// <summary>
    /// �V�[���J��
    /// </summary>
    private void SceneTransition()
    {
        //A�{�^������������
        if (Input.GetButton("Bbutton") && m_selectNum == (int)SelectNum.KRetry)
        {
            m_selectItem[(int)SelectNum.KRetry] = true;
        }
        else if (Input.GetButton("Bbutton") && m_selectNum == (int)SelectNum.kHome)
        {
            m_selectItem[(int)SelectNum.kHome] = true;
        }
    }
}
