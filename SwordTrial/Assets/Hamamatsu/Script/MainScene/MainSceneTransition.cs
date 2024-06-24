//メインシーンのシーン遷移

using UnityEngine;

public class MainSceneTransition : SceneTransitionBase
{
    //タイマー情報
    private Timer m_timer;

    protected override void Start()
    {
        base.Start();
        m_timer = GetComponent<Timer>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
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
}
