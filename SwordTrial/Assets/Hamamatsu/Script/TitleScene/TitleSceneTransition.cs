// タイトルシーンにおけるシーン遷移処理

public class TitleSceneTransition : SceneTransitionBase
{
    TitleUICursor m_Ui;

    protected override void Start()
    {
        base.Start();
        m_Ui = GetComponent<TitleUICursor>();
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
        if (m_Ui.m_selectItem[(int)TitleUICursor.SelectNum.kStart])
        {
            m_fade.m_isFading = false;
            GetNextScene((int)SceneKinds.kMainScene);
        }
        
    }
}
