//敵の処理

using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.UIElements;

public class EnemyState : MonoBehaviour
{
    //追跡するターゲットのオブジェクト
    [SerializeField] private GameObject m_target;
    //移動する速度
    [SerializeField] private float m_speed;
    //座標------------------------------------------------------
    private Vector3 m_targetPosition;//追跡するターゲット
    private Vector3 m_enemyPosition;//敵
    //----------------------------------------------------------

    //味方と敵の距離--------------------------------------------
    private float m_currentDistance = 0;//現在の距離
    [SerializeField] private float m_shortDistance = 0;//最短距離
    //----------------------------------------------------------

    //回転速度
    [SerializeField] private float m_rotateSpeed = 0;

    //体力-------------------------------------------------------
    private int m_currentHP = 100;//現在
    private readonly int m_maxHP = 100;//最大値
    private readonly int m_minHP = 0;//最小値
    //-----------------------------------------------------------

    //生きているかどうかを取得
    private bool m_isAlive = true;


    void Start()
    {
        Initialization();
    }

    void Update()
    {
        
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
    }

    private void OnTriggerEnter(Collider other)
    {
        //デバッグ用ダメージ
        //TODO:条件分が仮なのでアルファで変更する
        if(other.tag == "PlayerAttack")
        {
            Debug.Log("通る");
            ReceiveDamage();
        }
    }


    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialization()
    {
        m_currentHP = 100;
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

        //m_currentDistance = Vector3.Distance(new Vector3(m_targetPosition.x, 0, m_targetPosition.y),
        //    new Vector3(m_enemyPosition.x, 0, m_enemyPosition.y));
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

        if (m_currentDistance >= m_shortDistance)
        {
            //オブジェクトの前方に進ませる
            transform.Translate(0, 0, m_speed, Space.Self);
        }
        
    }

    /// <summary>
    /// スピードの変更
    /// </summary>
    private void SpeedChange()
    {
        if(m_currentDistance >= 3)
        {
            m_speed = 0.05f;
        }
        else
        {
            m_speed = 0.01f;
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
    private void ReceiveDamage()
    {
        if (!m_isAlive) return;

        m_currentHP -= 10;
    }

    /// <summary>
    /// 死亡時にm_isAliveにfalseを代入
    /// </summary>
    private void Dead()
    {
        m_isAlive = false;
    }
}
