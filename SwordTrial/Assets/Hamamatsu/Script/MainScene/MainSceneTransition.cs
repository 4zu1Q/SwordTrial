//���C���V�[���̃V�[���J��

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneTransition : MonoBehaviour
{
    //�^�C�}�[���
    private Timer m_timer;

    private void Start()
    {
        m_timer = GetComponent<Timer>();
    }

    private void Update()
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
            //�����V�[���Ɉړ�
            SceneManager.LoadScene("WinScene");
        }
        //B�{�^������������A�܂��̓J�E���g�_�E�����I��������V�[���J��
        else if (Input.GetButton("Bbutton") || m_timer.GetFinishCountDown())
        {
            //�s�k�V�[���Ɉڍs
            SceneManager.LoadScene("LoseScene");
        }
    }
}
