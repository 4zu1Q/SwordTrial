using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public enum EnemyState
    {
        walk,
        wait,
        Chase,
        Attack
    }

    private CharacterController m_enemyController;
    private Animator m_animator;

    private Vector3 m_destination;          //目的地
    [SerializeField]                            //歩くスピード
    private float m_walkSpeed = 1.0f;     //現状は1.0f　追々変更になる可能性はある
    private Vector3 m_velocity;        　   //速度
    private Vector3 m_direction;            //移動方向
    private bool m_arrived;              //プレイヤーとの到着フラグ
                                         //  private SetPosition m_setPosition;          //SetPositionスクリプト
    [SerializeField]                            //待ち時間
    private float m_waitTime = 5f;        //現状は5f　追々変更になる可能性はある
    private float m_elapsedTime;          //経過時間
    private EnemyState m_state;                //敵の状態
    private Transform m_playerTransform;      //プレイヤーTransform

    // Start is called before the first frame update
    void Start()
    {
        m_enemyController = GetComponent<CharacterController>();
        m_animator = GetComponent<Animator>();
        // m_setPosition     = GetComponent<SetPosition>;
        m_setPosition.CreateRandomPosition();
        m_velocity = Vector3.zero;
        m_arrived = false;
        m_elapsedTime = 0;
        SetState(EnemyState.walk);

    }

    // Update is called once per frame
    void Update()
    {
        //見回りまたはキャラクターを追いかける状態
        if (m_state == EnemyState.walk || m_state == EnemyState.Chase)
        {
            //   m_setPosion.SetDestination(m_playerTransform.position);
        }
        if (m_enemyController.isGrounded)
        {
            m_velocity = Vector3.zero;
            m_animator.SetFloat("Speed", 0.0f);
            //   m_direction  = (m_setPosition.GetDestination() - transform.position).normalized;
            //   transform.LookAt(new Vector3(m_setPosition.GetDestination().x,transform.position.y, m_setPosition.GetDestination().z));))
            m_velocity = m_direction * m_walkSpeed;
        }
        //目的地に到着したのかどうかの判定
        //到着したら移動速度を0にする
        //if (Vector3.Distance(transform.position, m_setPosition.GetDestination()) < 0.5f) ;
    }

    public void SetState(EnemyState tempState, Transform targetObj = null)
    {
        if (tempState == EnemyState.walk)
        {
            m_arrived = false;
            m_elapsedTime = 0f;
            m_state = tempState;
            m_setPosition.CreateRandomPosition();
        }
        else if (tempState == EnemyState.Chase)
        {
            m_state = tempState;
            //待機状態から追いかける場合もあるのでoff
            m_arrived = false;
            //追いかける対象をセット
            m_playerTransform = targetObj;
        }
        else if (tempState == EnemyState.wait)
        {
            m_elapsedTime = 0f;
            m_state = tempState;
            m_arrived = true;
            m_velocity = Vector3.zero;
            m_animator.SetFloat("Speed", 0f);
        }
    }
    //敵キャラクターとの状態取得メソッド
    public EnemyState GetState()
    {
        return m_state;
    }
}
