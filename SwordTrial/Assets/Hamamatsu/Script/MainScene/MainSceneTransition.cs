//メインシーンのシーン遷移

using UnityEngine;

public class MainSceneTransition : SceneTransitionBase
{
    //タイマー情報
    private Timer m_timer;
    PauseUI m_Ui;

    protected override void Start()
    {
        base.Start();
        m_timer = GetComponent<Timer>();
        m_Ui = GetComponent<PauseUI>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        //DebugSceneTransition();
        //SceneTransitoinPause();
    }

    /// <summary>
    /// デバッグ用シーン遷移
    /// </summary>
    private void DebugSceneTransition()
    {
        //Aボタンを押したら
        if (Input.GetButton("Abutton"))
        {
            m_fade.m_isFading = false;
            GetNextScene((int)SceneKinds.kWinScene);
        }
        //Bボタンを押したら、またはカウントダウンが終了したらシーン遷移
        else if (Input.GetButton("Bbutton") || m_timer.GetFinishCountDown())
        {
            m_fade.m_isFading = false;
            GetNextScene((int)SceneKinds.kLoseScene);
        }
    }
    /// <summary>
    /// ポーズのシーン遷移の実装
    /// </summary>
    private void SceneTransitoinPause()
    {
        if (m_Ui.m_pauseNum[(int)PauseUI.SelectNum.kTitleBack])
        {
            m_fade.m_isFading = false;
            GetNextScene((int)SceneKinds.kTitleScene);
        }
    }
}
