//�^�C�g����ʂ̃J�[�\���̑���

using UnityEngine;

public class TitleUICursor : UIOperationBase
{
    public enum SelectNum
    {
        kStart, //�X�^�[�g
        kOption,//�I�v�V����
        kEnd,   //�I��
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
            m_fade.m_isFading = false;
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
