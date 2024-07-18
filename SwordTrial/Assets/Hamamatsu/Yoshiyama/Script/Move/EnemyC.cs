//敵の処理

using UnityEngine;
using UnityEngine.UI;

public class EnemyC : MonoBehaviour
{
    /*UI*/
    public Slider m_slider;

    //攻撃の種類
    public enum AttackKinds
    {
        kNormalAttack,//通常
        kChargeAttack,//溜め
        kComboAttack,//連続
        kRotateAttack,//回転
        kAttackMaxKinds//最大種類
    }

    //追跡するターゲットのオブジェクト
    [SerializeField] private GameObject m_target;
    //移動する速度
    [SerializeField] private float m_speed;

    //アニメーション-------------------------------------------
    private string m_attack1 = "Attack1";
    private string m_attack2 = "Attack2";
    private string m_attack3 = "Attack3";
    private string m_attack4 = "Attack4";
    private string m_walk = "Walk";
    private string m_dash = "Dash";

    Animator m_anim;
    public bool m_isPushFlag1 = false;
    public bool m_isPushFlag2 = false;
    public bool m_isPushFlag3 = false;
    public bool m_isPushFlag4 = false;
    private bool m_isDashFlag = false;
    private int m_animationInterval = 10;
    private float m_frame = 0;


    //座標------------------------------------------------------
    private Vector3 m_targetPosition;//追跡するターゲット
    private Vector3 m_enemyPosition;//敵
    public bool m_dashAnimation = false;
    //----------------------------------------------------------

    //味方と敵の距離--------------------------------------------
    private float m_currentDistance = 0;//現在の距離
    [SerializeField] private float m_shortDistance = 0;//最短距離
    //----------------------------------------------------------

    //回転速度
    [SerializeField] private float m_rotateSpeed = 0;

    //体力-------------------------------------------------------
    public int m_currentHP = 100;//現在
    public readonly int m_maxHP = 100;//最大値
    public readonly int m_minHP = 0;//最小値
    //-----------------------------------------------------------

    //生きているかどうかを取得
    private bool m_isAlive = true;

    //攻撃-------------------------------------------------------
    //攻撃と攻撃の間にあるインターバル、攻撃によってインターバルの時間を変更
    public int m_attackInterval = 10;
    private int m_currentAttackInterval = 0;//現在のインターバル

    public int m_attackKinds = 0;//何の攻撃をするのかを決める

    private bool m_isCombat = false;//戦闘態勢に入っているかどうか

    private bool[] m_currentAttackState;//現在の攻撃状況

    public GameObject m_attackCol;//攻撃の当たり判定

    private bool m_isActive = false;//存在しているかどうか

    public bool m_isAttackAnimation1 = false;
    public bool m_isAttackAnimation2 = false;
    public bool m_isAttackAnimation3 = false;
    public bool m_isAttackAnimation4 = false;

    //-----------------------------------------------------------

    private EnemyAnimation m_pAnimation;

    //別のスクリプトを取得---------------------------------------
    EnemyNormalAttack m_normalAttack;// 通常攻撃

    //-----------------------------------------------------------

    //アニメーションを中断したかどうか
    private bool m_animInterrupt = false;


    void Start()
    {
        Initialization();
        m_pAnimation = GetComponent<EnemyAnimation>();
        m_anim = GetComponent<Animator>();
    }

    void Update()
    {
        GetAttackKinds();
    }

    private void FixedUpdate()
    {
        if (!m_isAlive) return;

        if (m_currentHP <= m_minHP)
        {
            Dead();
        }

        UpdateVariable();
        GoToTarget();
        IntervalReset();


        if (m_isCombat)
        {
            AttackIntervalAdd();
        }

        AttackActive();
        UpdateAttack();
        if (!m_isAttackAnimation4) return;
    }

    private void OnTriggerEnter(Collider other)
    {
        //デバッグ用ダメージ
        //TODO:条件分が仮なのでアルファで変更する
        if (other.tag == "PlayerAttack")
        {
            ReceiveDamage();
        }
    }


    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialization()
    {
        m_currentHP = 100;
        m_attackKinds = 3;
        m_currentAttackState = new bool[(int)AttackKinds.kAttackMaxKinds];

        m_normalAttack = new EnemyNormalAttack();

        m_isActive = false;

        m_slider.value = m_currentHP;
    }

    /// <summary>
    /// 変数の中身を更新し続ける
    /// </summary>
    private void UpdateVariable()
    {
        SetPosition();
        SetDistance();
    }

    private void SetPosition()
    {
        m_targetPosition = m_target.transform.position;
        m_enemyPosition = transform.position;
    }

    /// <summary>
    /// 現在の距離を取得
    /// </summary>
    private void SetDistance()
    {
        m_currentDistance = Vector3.Distance(m_targetPosition, m_enemyPosition);
    }

    /// <summary>
    /// ターゲットに向かって進む
    /// </summary>
    private void GoToTarget()
    {
        var m_moveVec = m_targetPosition - transform.position;
        m_moveVec.Normalize();

        TurnTowards();
        SpeedChange();

        // プレイヤーが離れると移動
        if (m_currentDistance >= m_shortDistance)
        {
            //オブジェクトの前方に進ませる
            transform.Translate(0, 0, m_speed, Space.Self);
            m_isCombat = false;
            for (int i = 0; i < (int)AttackKinds.kAttackMaxKinds; i++)
            {
                m_currentAttackState[i] = false;
            }
            m_isActive = false;

            m_frame = 0;

        }
        //プレイヤーに近づいた状態になると戦闘態勢に移る
        else if (m_currentDistance <= m_shortDistance)
        {
            m_isCombat = true;
        }


        // 攻撃を行う状態が終わった時の処理
        if(!m_isCombat && m_currentAttackInterval == 0 && !m_animInterrupt)
        {
            Debug.Log("通る");
            m_anim.SetTrigger(m_walk);
            m_animInterrupt = true;
        }

        

    }

    /// <summary>
    /// スピードの変更
    /// </summary>
    private void SpeedChange()
    {
        if (m_currentDistance >= 3)
        {
            m_speed = 0.05f;
            m_dashAnimation = true;
        }
        else
        {
            m_speed = 0.01f;
            m_dashAnimation = false;
        }
    }

    /// <summary>
    /// ターゲットの方を向く
    /// </summary>
    /// <param name="turnFlame">向くスピード</param>
    private void TurnTowards()
    {
        // ターゲットの方向ベクトル.
        Vector3 _direction = new Vector3(m_targetPosition.x - transform.position.x,
            0.0f, m_targetPosition.z - transform.position.z);
        // 方向ベクトルからクォータニオン取得
        Quaternion _rotation = Quaternion.LookRotation(_direction, Vector3.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, _rotation, Time.deltaTime * m_rotateSpeed);
    }

    /// <summary>
    /// ダメージをもらう
    /// </summary>
    public void ReceiveDamage()
    {
        if (!m_isAlive) return;

        m_currentHP -= 10;

        m_slider.value = m_currentHP;
    }

    /// <summary>
    /// 死亡時にm_isAliveにfalseを代入
    /// </summary>
    private void Dead()
    {
        m_isAlive = false;
    }

    /// <summary>
    /// インターバルをリセット
    /// </summary>
    private void IntervalReset()
    {
        if (!m_isCombat)
        {
            m_currentAttackInterval = 0;
        }
    }

    /// <summary>
    /// 攻撃の種類をRandomで決める
    /// </summary>
    public void GetAttackKinds()
    {
        //m_attackKinds = Random.Range((int)AttackKinds.kNormalAttack, (int)AttackKinds.kAttackMaxKinds);

        m_attackKinds = (int)AttackKinds.kComboAttack;
    }

    /// <summary>
    /// 攻撃のインターバルを加算していく
    /// </summary>
    private void AttackIntervalAdd()
    {
        m_currentAttackInterval++;

        // 一定のインターバルが過ぎると攻撃を行う
        if (m_currentAttackInterval >= m_attackInterval)
        {
            AttackNumber();
            m_currentAttackInterval = 0;
        }
        //Debug.Log("m_attackInterval" + m_attackInterval);
        //Debug.Log("m_frame" + m_frame);
    }

    /// <summary>
    /// 攻撃をm_attackKindsの値によって変える
    /// (int)AttackKinds.kNormalAttack = 通常攻撃
    /// (int)AttackKinds.kChargeAttack = 溜め攻撃
    /// (int)AttackKinds.kComboAttack = 連続攻撃
    /// (int)AttackKinds.kRotateAttack = 回転攻撃
    /// </summary>
    public void AttackNumber()
    {
        // 通常攻撃
        if (m_attackKinds == (int)AttackKinds.kNormalAttack)
        {
            m_isAttackAnimation1 = true;
            m_currentAttackState[(int)AttackKinds.kNormalAttack] = true;
            m_attackInterval = 100;
        }
        else if (m_attackKinds == (int)AttackKinds.kChargeAttack)
        {
            m_isAttackAnimation2 = true;
            m_currentAttackState[(int)AttackKinds.kChargeAttack] = true;
            m_attackInterval = 100;
        }
        else if (m_attackKinds == (int)AttackKinds.kComboAttack)
        {
            m_isAttackAnimation3 = true;
            m_currentAttackState[(int)AttackKinds.kComboAttack] = true;
            m_attackInterval = 100;
        }
        else if (m_attackKinds == (int)AttackKinds.kRotateAttack)
        {
            m_isAttackAnimation4 = true;
            m_currentAttackState[(int)AttackKinds.kRotateAttack] = true;
            m_attackInterval = 100;
        }
    }

    /// <summary>
    /// 攻撃判定が存在しているか
    /// </summary>
    private void AttackActive()
    {
        m_attackCol.SetActive(m_isActive);
    }

    /// <summary>
    /// 攻撃の処理
    /// </summary>
    private void UpdateAttack()
    {
        //通常攻撃
        if (m_currentAttackState[(int)AttackKinds.kNormalAttack])
        {
            if (m_currentAttackInterval >= m_attackInterval)
            {
                m_currentAttackState[(int)AttackKinds.kNormalAttack] = false;
                m_isAttackAnimation1 = false;
            }
            DebugAttack(130, 150, new Vector3(0.0f, 0.1f, 0.06f), new Vector3(1.0f, 1.0f, 1.0f));
            m_frame++;
            if (m_frame == 120)
            {
                m_anim.SetTrigger(m_attack1);
            }
            else if (m_frame == 140)
            {
                m_anim.SetTrigger(m_walk);
            }
            else if (m_frame == 400)
            {
                m_frame = 0;
            }
        }
        //溜め攻撃
        else if (m_currentAttackState[(int)AttackKinds.kChargeAttack])
        {
            if (m_currentAttackInterval >= m_attackInterval)
            {
                m_currentAttackState[(int)AttackKinds.kChargeAttack] = false;
                m_isAttackAnimation2 = false;
            }
            DebugAttack(260, 280, new Vector3(0.0f, 0.1f, 0.06f), new Vector3(1.5f, 1.5f, 1.5f));
            m_frame++;
            if (m_frame == 250)
            {
                m_anim.SetTrigger(m_attack2);
            }
            else if (m_frame == 370)
            {
                m_anim.SetTrigger(m_walk);
            }
            else if (m_frame == 400)
            {
                m_frame = 0;
            }
        }
        //連続攻撃
        else if (m_currentAttackState[(int)AttackKinds.kComboAttack])
        {
            DebugAttack(100, 130, new Vector3(0.0f, 0.1f, 0.06f), new Vector3(0.7f, 0.7f, 0.7f));
            //DebugAttack(250, 300, new Vector3(0.0f, 0.1f, 0.06f), new Vector3(0.5f, 0.5f, 0.5f));
            //DebugAttack(250, 300, new Vector3(0.0f, 0.1f, 0.06f), new Vector3(0.5f, 0.5f, 0.5f));

            

            m_frame++;
            if (m_frame == 250)
            {
                m_anim.SetTrigger(m_attack3);
                m_animInterrupt = false;
            }
            else if (m_frame == 370)
            {
                Debug.Log("通る");
                m_animInterrupt = true;
                m_anim.SetTrigger(m_walk);
            }
            else if (m_frame == 400)
            {
                m_frame = 0;
            }
            // 攻撃終了時に呼び出される
            if (m_currentAttackInterval >= m_attackInterval)
            {
                m_currentAttackState[(int)AttackKinds.kComboAttack] = false;
                m_isAttackAnimation3 = false;
            }
        }
        //回転攻撃
        else if (m_currentAttackState[(int)AttackKinds.kRotateAttack])
        {
            if (m_currentAttackInterval >= m_attackInterval)
            {
                m_currentAttackState[(int)AttackKinds.kRotateAttack] = false;
                m_isAttackAnimation4 = false;
            }
            DebugAttack(200, 300, new Vector3(0.0f, 0.1f, 0.0f), new Vector3(2.0f, 2.0f, 2.0f));
            m_frame++;
            if (m_frame == 230)
            {
                m_anim.SetTrigger(m_attack4);
            }
            else if (m_frame == 350)
            {
                m_anim.SetTrigger(m_walk);
            }
            else if (m_frame == 400)
            {
                m_frame = 0;
            }

        }

        

    }

    /// <summary>
    /// デバッグ用当たり判定
    /// </summary>
    /// <param name="isActiveTime">当たり判定生成タイミング</param>
    /// <param name="noActiveTime">当たり判定消去タイミング</param>
    /// <param name="position">発生位置</param>
    /// <param name="scale">大きさ</param>
    private void DebugAttack(int isActiveTime, int noActiveTime, Vector3 position, Vector3 scale)
    {
        if (m_currentAttackInterval == isActiveTime)
        {
            m_isActive = true;

        }

        m_attackCol.transform.localPosition = position;
        m_attackCol.transform.localScale = scale;

        if (m_currentAttackInterval == noActiveTime)
        {
            m_isActive = false;
        }
    }
    internal void AttackNumber(int a, string m_attack1)
    {
        throw new System.NotImplementedException();
    }
}
