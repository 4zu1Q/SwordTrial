//���C���V�[���̃V�[���J��

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneTransition : MonoBehaviour
{
    void Update()
    {
        DebugSceneTransition();
    }

    /// <summary>
    /// �f�o�b�O�p�V�[���J��
    /// </summary>
    private void DebugSceneTransition()
    {
        //A�{�^������������
        if (Input.GetButton("Abutton"))
        {
            //�Q�[���V�[���Ɉړ�
            SceneManager.LoadScene("WinScene");
        }
        //B�{�^������������
        else if (Input.GetButton("Bbutton"))
        {
            //�Z���N�g�V�[���Ɉڍs
            SceneManager.LoadScene("LoseScene");
        }
    }



}
