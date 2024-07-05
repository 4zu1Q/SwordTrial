using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyC;

public class EnemyMove : MonoBehaviour
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

    private bool[] m_currentAttackState;//現在の攻撃状況
    private bool m_isCombat = false;//戦闘態勢に入っているかどうか
    private bool m_isActive = false;//存在しているかどうか


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
        //プレイヤーに近づいた状態になると戦闘態勢に移る
        else if (m_currentDistance <= m_shortDistance)
        {
            m_isCombat = true;
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

}
