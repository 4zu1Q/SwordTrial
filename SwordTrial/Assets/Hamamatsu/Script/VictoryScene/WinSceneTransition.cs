//������ʂ̃V�[���J�ڏ���

using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���؂�ւ��̂���

public class WinSceneTransition : MonoBehaviour
{
    void Update()
    {
        //A�{�^������������
        if (Input.GetButton("Abutton"))
        {
            //�Q�[���V�[���Ɉړ�
            SceneManager.LoadScene("GameScene");
        }
        else if (Input.GetButton("Abutton"))
        {
            //�Z���N�g�V�[���Ɉڍs
            SceneManager.LoadScene("TitleScene");
        }
    }
}
