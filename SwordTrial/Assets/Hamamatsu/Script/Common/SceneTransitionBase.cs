//�V�[���J�ڃx�[�X����

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionBase : MonoBehaviour
{
    //�V�[���̎��
    protected enum SceneKinds
    {
        kTitleScene,
        kMainScene,
        kWinScene,
        kLoseScene,
        kMaxNum
    }

    //�t�F�[�h���
    protected Fade m_fade;
    //���݂̃V�[���͉���
    protected bool[] m_nextSceneKinds; 

    protected virtual void Start()
    {
        m_fade = GameObject.Find("Fade").GetComponent<Fade>();
        m_nextSceneKinds = new bool[(int)SceneKinds.kMaxNum];
    }

    protected virtual void FixedUpdate()
    {
        SceneTransition();
    }

    /// <summary>
    /// �V�[���J�ڏ���
    /// </summary>
    private void SceneTransition()
    {
        //�^�C�g���V�[����
        if(m_fade.GetFadeEnd() && m_nextSceneKinds[(int)SceneKinds.kTitleScene])
        {
            SceneManager.LoadScene("TitleScene");
        }
        //���C���V�[����
        else if (m_fade.GetFadeEnd() && m_nextSceneKinds[(int)SceneKinds.kMainScene])
        {
            SceneManager.LoadScene("GameScene");
        }
        //�����V�[����
        else if (m_fade.GetFadeEnd() && m_nextSceneKinds[(int)SceneKinds.kWinScene])
        {
            SceneManager.LoadScene("WinScene");
        }
        //�s�k�V�[����
        else if (m_fade.GetFadeEnd() && m_nextSceneKinds[(int)SceneKinds.kLoseScene])
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    /// <summary>
    /// ���݂̃V�[��
    /// </summary>
    protected void GetNextScene(int NextSceneNumber)
    {
        m_nextSceneKinds[NextSceneNumber] = true;
    }


}
