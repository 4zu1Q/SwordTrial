/*プレイヤーステート関数*/

using UnityEngine;

public partial class PlayerState
{
    /// <summary>
    /// 初期化
    /// </summary>
    private void Init()
    {
        VariableInitialization();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void UpdateFunc()
    {

    }

    /// <summary>
    /// 50fps固定更新処理
    /// </summary>
    private void FixedUpdateFunc()
    {
        StateFrameManager();
    }

    /// <summary>
    /// 変数の初期化
    /// </summary>
    private void VariableInitialization()
    {
        m_currentFrame = 0;
        m_rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
    }

    /// <summary>
    /// 状態遷移
    /// </summary>
    /// <param name="nextState">次の状態</param>
    private void StateTransition(StateBase nextState)
    {
        // 状態終了時
        m_currentState.OnExit(this, nextState);
        // 各状態の時間をリセット
        FrameReset();
        // 次の状態の呼び出し
        nextState.OnEnter(this, m_currentState);
        // 次にs根にする状態の
    }

    /// <summary>
    /// 現在の状態フレーム数を増やす
    /// </summary>
    private void StateFrameManager()
    {
        m_currentFrame++;
    }

    // 状態フレームをリセットする
    private void FrameReset()
    {
        m_currentFrame = 0;
    }

    /// <summary>
    /// 状態遷移時の初期化　
    /// </summary>
    private void StateTransitionInitialization()
    {
        m_currentFrame = 0;
    }

    /// <summary>
    /// アニメーション遷移
    /// </summary>
    private void AnimTransition()
    {
        m_animator.SetBool("Idle", m_idleMotion);
        m_animator.SetBool("Run", m_runMotion);
        m_animator.SetBool("Dash", m_dashMotion);

    }


}
