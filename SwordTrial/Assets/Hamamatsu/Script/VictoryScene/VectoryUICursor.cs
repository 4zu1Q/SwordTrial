//������ʂ̃J�[�\������

using UnityEngine;
using UnityEngine.SceneManagement;

public class VectoryUICursor : UIOperationBase
{
    public enum SelectNum
    {
        KRetry, //�X�^�[�g
        kHome,//�I�v�V����
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
            //�Z���N�g�V�[���Ɉڍs
            SceneManager.LoadScene("GameScene");
        }
        else if (Input.GetButton("Bbutton") && m_selectNum == (int)SelectNum.kHome)
        {
            //�����≹���̒����Ƃ��ł���悤�ȃE�B���h�E��W�J
            SceneManager.LoadScene("TitleScene");

        }
    }
}
