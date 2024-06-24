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
        if (Input.GetButton("Bbutton") && m_selectNum == (int)SelectNum.kContinue)
        {
            m_selectItem[(int)SelectNum.kContinue] = true;
        }
        else if (Input.GetButton("Bbutton") && m_selectNum == (int)SelectNum.kHome)
        {
            m_selectItem[(int)SelectNum.kHome] = true;
        }
    }
}
