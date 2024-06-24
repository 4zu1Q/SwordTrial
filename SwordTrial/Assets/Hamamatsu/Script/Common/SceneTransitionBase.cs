//�V�[���J�ڃx�[�X����

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionBase : MonoBehaviour
{
    //�V�[���̎��
    protected enum SceneKinds
    {
        TitleScene,
        MainScene,
        WinScene,
        LoseScene,
        MaxNum
    }

    //�t�F�[�h���
    Fade m_fade;
    //���݂̃V�[���͉���
    protected bool[] m_nextSceneKinds; 

    protected virtual void Start()
    {
        m_fade = GameObject.Find("Fade").GetComponent<Fade>();
        m_nextSceneKinds = new bool[(int)SceneKinds.MaxNum];
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
        if(m_fade.GetFadeEnd() && m_nextSceneKinds[(int)SceneKinds.TitleScene])
        {
            SceneManager.LoadScene("TitleScene");
        }
        //���C���V�[����
        else if (m_fade.GetFadeEnd() && m_nextSceneKinds[(int)SceneKinds.MainScene])
        {
            SceneManager.LoadScene("GameScene");
        }
        //�����V�[����
        else if (m_fade.GetFadeEnd() && m_nextSceneKinds[(int)SceneKinds.WinScene])
        {
            SceneManager.LoadScene("WinScene");
        }
        //�s�k�V�[����
        else if (m_fade.GetFadeEnd() && m_nextSceneKinds[(int)SceneKinds.LoseScene])
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    /// <summary>
    /// ���݂̃V�[��
    /// </summary>
    protected void GetCurrentScene(int NextSceneNumber)
    {
        m_nextSceneKinds[NextSceneNumber] = true;
    }


}
