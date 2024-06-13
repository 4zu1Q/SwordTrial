//�s�k��ʂ̃J�[�\������

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseUICursor : UIOperationBase
{
    public enum SelectNum
    {
        kContinue, //�R���e�j���[
        kHome,//�z�[����
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
            //�Z���N�g�V�[���Ɉڍs
            SceneManager.LoadScene("GameScene");
        }
        else if (Input.GetButton("Bbutton") && m_selectNum == (int)SelectNum.kHome)
        {
            //�^�C�g����ʂ�
            SceneManager.LoadScene("TitleScene");
        }
    }
}
