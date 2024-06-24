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
        if (Input.GetButtonDown("Bbutton") && m_selectNum == (int)SelectNum.kStart)
        {
            m_selectItem[(int)SelectNum.kStart] = true;
        }
        else if (Input.GetButtonDown("Bbutton") && m_selectNum == (int)SelectNum.kOption)
        {
            //�����≹���̒����Ƃ��ł���悤�ȃE�B���h�E��W�J
            Debug.Log("�������J��");
        }
        else if (Input.GetButtonDown("Bbutton") && m_selectNum == (int)SelectNum.kEnd)
        {
            //�Q�[���I��������
            //End();
            Debug.Log("�Q�[���I��");
        }
    }
}
