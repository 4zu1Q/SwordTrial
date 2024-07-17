//メインシーンのシーン遷移

using UnityEngine;

public class MainSceneTransition : SceneTransitionBase
{
    //タイマー情報
    private Timer m_timer;
    private PauseUI m_Ui;

    //Player情報
    [SerializeField] private Player m_player;
    //Enemy情報
    [SerializeField] private EnemyC m_enemyState;

    //LoseSceneに遷移するかどうか
    private bool m_isLoseScene = false;
    //WinSceneに遷移するかどうか
    private bool m_isWinScene = false;

    protected override void Start()
    {
        base.Start();
        m_timer = GetComponent<Timer>();
        m_Ui = GetComponent<PauseUI>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        SetBoolScene();
        DebugSceneTransition();
        SceneTransitoinPause();
    }

    /// <summary>
    /// シーン遷移するかどうかを判断する
    /// </summary>
    private void SetBoolScene()
    {
        // 敗北シーンに遷移するかのフラグ
        m_isLoseScene = (m_player.m_hp <= 0) || m_timer.GetFinishCountDown();
        // 勝利シーンに遷移するかのフラグ
        m_isWinScene = m_enemyState.m_currentHP <= 0;
    }

    /// <summary>
    /// デバッグ用シーン遷移
    /// </summary>
    private void DebugSceneTransition()
    {
        // プレイヤーの体力が0または時間切れになると敗北画面へ
        if(m_isLoseScene)
        {
            m_fade.m_isFading = false;
            GetNextScene((int)SceneKinds.kLoseScene);
        }
        // 敵の体力が0以下になれば勝利画面へ
        else if(m_isWinScene)
        {
            m_fade.m_isFading = false;
            GetNextScene((int)SceneKinds.kWinScene);
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
