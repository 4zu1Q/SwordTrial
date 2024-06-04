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

    private Vector3 m_destination;          //�ړI�n
    [SerializeField]                            //�����X�s�[�h
    private float m_walkSpeed = 1.0f;     //�����1.0f�@�ǁX�ύX�ɂȂ�\���͂���
    private Vector3 m_velocity;        �@   //���x
    private Vector3 m_direction;            //�ړ�����
    private bool m_arrived;              //�v���C���[�Ƃ̓����t���O
                                         //  private SetPosition m_setPosition;          //SetPosition�X�N���v�g
    [SerializeField]                            //�҂�����
    private float m_waitTime = 5f;        //�����5f�@�ǁX�ύX�ɂȂ�\���͂���
    private float m_elapsedTime;          //�o�ߎ���
    private EnemyState m_state;                //�G�̏��
    private Transform m_playerTransform;      //�v���C���[Transform

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
        //�����܂��̓L�����N�^�[��ǂ���������
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
        //�ړI�n�ɓ��������̂��ǂ����̔���
        //����������ړ����x��0�ɂ���
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
            //�ҋ@��Ԃ���ǂ�������ꍇ������̂�off
            m_arrived = false;
            //�ǂ�������Ώۂ��Z�b�g
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
    //�G�L�����N�^�[�Ƃ̏�Ԏ擾���\�b�h
    public EnemyState GetState()
    {
        return m_state;
    }
}
