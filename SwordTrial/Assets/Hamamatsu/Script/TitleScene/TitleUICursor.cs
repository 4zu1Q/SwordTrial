//�^�C�g����ʂ̃J�[�\���̑���

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class TitleUICursor : UIOperationBase
{
    public enum SelectNum
    {
        kStart, //�X�^�[�g
        kOption,//�I�v�V����
        kEnd,   //�I��
    }

    //����
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
        if (Input.GetButton("Bbutton") && m_selectNum == (int)SelectNum.kStart)
        {
            //�Z���N�g�V�[���Ɉڍs
            SceneManager.LoadScene("GameScene");
        }
        else if (Input.GetButton("Bbutton") && m_selectNum == (int)SelectNum.kOption)
        {
            //�����≹���̒����Ƃ��ł���悤�ȃE�B���h�E��W�J
            Debug.Log("�������J��");

        }
        else if (Input.GetButton("Bbutton") && m_selectNum == (int)SelectNum.kEnd)
        {
            //�Q�[���I��������
            //End();
            Debug.Log("�Q�[���I��");
        }
    }
}
