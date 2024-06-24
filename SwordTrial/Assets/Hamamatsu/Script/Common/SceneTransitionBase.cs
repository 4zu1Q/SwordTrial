//シーン遷移ベース処理

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionBase : MonoBehaviour
{
    //シーンの種類
    protected enum SceneKinds
    {
        kTitleScene,
        kMainScene,
        kWinScene,
        kLoseScene,
        kMaxNum
    }

    //フェード情報
    protected Fade m_fade;
    //現在のシーンは何か
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
    /// シーン遷移処理
    /// </summary>
    private void SceneTransition()
    {
        //タイトルシーンへ
        if(m_fade.GetFadeEnd() && m_nextSceneKinds[(int)SceneKinds.kTitleScene])
        {
            SceneManager.LoadScene("TitleScene");
        }
        //メインシーンへ
        else if (m_fade.GetFadeEnd() && m_nextSceneKinds[(int)SceneKinds.kMainScene])
        {
            SceneManager.LoadScene("GameScene");
        }
        //勝利シーンへ
        else if (m_fade.GetFadeEnd() && m_nextSceneKinds[(int)SceneKinds.kWinScene])
        {
            SceneManager.LoadScene("WinScene");
        }
        //敗北シーンへ
        else if (m_fade.GetFadeEnd() && m_nextSceneKinds[(int)SceneKinds.kLoseScene])
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    /// <summary>
    /// 現在のシーン
    /// </summary>
    protected void GetNextScene(int NextSceneNumber)
    {
        m_nextSceneKinds[NextSceneNumber] = true;
    }


}
