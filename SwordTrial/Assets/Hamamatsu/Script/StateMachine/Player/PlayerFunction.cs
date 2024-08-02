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
        m_currentState.OnEnter(this, null);
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void UpdateFunc()
    {
        GetGamePadInformation();
        m_currentState.OnUpdate(this);
    }

    /// <summary>
    /// 50fps固定更新処理
    /// </summary>
    private void FixedUpdateFunc()
    {
        StateFrameManager();
        AnimTransition();
        m_currentState.OnFixedUpdate(this);
        m_currentState.OnChangeState(this);
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
        // 次に遷移する状態の代入
        m_currentState = nextState;

        StateTransitionInitialization();
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

    /// <summary>
    /// ゲームパッドのの入力情報取得
    /// </summary>
    private void GetGamePadInformation()
    {
        // スティックの情報を取得
        m_inputHorizontal = Input.GetAxis("Horizontal");
        m_inputVertical = Input.GetAxis("Vertical");
    }


    private void Move()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 m_cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 m_moveForward = m_cameraForward * m_inputVertical + Camera.main.transform.right * m_inputHorizontal;

        // 移動方向にスピードを掛ける。
        m_rigidbody.velocity = m_moveForward * m_speed;

        // キャラクターの向きを進行方向に
        if (m_moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(m_moveForward);
        }

        //Aボタン
        //押している間はダッシュする
        if (Input.GetButton("Abutton"))
        {

            m_rigidbody.velocity = m_moveForward * m_speed * m_acel;
        }
    }
}
