//勝利シーンのシーン遷移

public class VictorySceneTransition : SceneTransitionBase
{
    VictoryUICursor m_UI;

    protected override void Start()
    {
        base.Start();
        m_UI = GetComponent<VictoryUICursor>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        SceneTransitionTrigger();
    }

    /// <summary>
    /// シーン遷移するきっかけの処理
    /// </summary>
    private void SceneTransitionTrigger()
    {
        if (m_UI.m_selectItem[(int)VictoryUICursor.SelectNum.KRetry])
        {
            m_fade.m_isFading = false;
            GetNextScene((int)SceneKinds.kMainScene);
        }
        else if (m_UI.m_selectItem[(int)VictoryUICursor.SelectNum.kHome])
        {
            m_fade.m_isFading=false;
            GetNextScene((int)SceneKinds.kTitleScene);
        }
    }
}
