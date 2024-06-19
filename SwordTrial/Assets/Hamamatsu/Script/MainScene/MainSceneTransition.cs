//メインシーンのシーン遷移

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneTransition : MonoBehaviour
{
    //タイマー情報
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
    /// デバッグ用シーン遷移
    /// </summary>
    private void DebugSceneTransition()
    {
        //Aボタンを押したら
        if (Input.GetButton("Abutton"))
        {
            //勝利シーンに移動
            SceneManager.LoadScene("WinScene");
        }
        //Bボタンを押したら、またはカウントダウンが終了したらシーン遷移
        else if (Input.GetButton("Bbutton") || m_timer.GetFinishCountDown())
        {
            //敗北シーンに移行
            SceneManager.LoadScene("LoseScene");
        }
    }
}
