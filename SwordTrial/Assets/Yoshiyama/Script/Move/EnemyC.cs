//�G�̏���

using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.UIElements;

public class EnemyC : MonoBehaviour
{
    //�U���̎��
    public enum AttackKinds
    {
        kNormalAttack,//�ʏ�
        kChargeAttack,//����
        kComboAttack,//�A��
        kRotateAttack,//��]
        kAttackMaxKinds//�ő���
    }

    //�ǐՂ���^�[�Q�b�g�̃I�u�W�F�N�g
    [SerializeField] private GameObject m_target;
    //�ړ����鑬�x
    [SerializeField] private float m_speed;

    //���W------------------------------------------------------
    private Vector3 m_targetPosition;//�ǐՂ���^�[�Q�b�g
    private Vector3 m_enemyPosition;//�G
    //----------------------------------------------------------

    //�����ƓG�̋���--------------------------------------------
    private float m_currentDistance = 0;//���݂̋���
    [SerializeField] private float m_shortDistance = 0;//�ŒZ����
    //----------------------------------------------------------

    //��]���x
    [SerializeField] private float m_rotateSpeed = 0;

    //�̗�-------------------------------------------------------
    private int m_currentHP = 100;//����
    private readonly int m_maxHP = 100;//�ő�l
    private readonly int m_minHP = 0;//�ŏ��l
    //-----------------------------------------------------------

    //�����Ă��邩�ǂ������擾
    private bool m_isAlive = true;

    //�U��-------------------------------------------------------
    //�U���ƍU���̊Ԃɂ���C���^�[�o���A�U���ɂ���ăC���^�[�o���̎��Ԃ�ύX
    private int m_attackInterval = 10;
    private int m_currentAttackInterval = 0;//���݂̃C���^�[�o��

    public int m_attackKinds = 0;//���̍U��������̂������߂�

    private bool m_isCombat = false;//�퓬�Ԑ��ɓ����Ă��邩�ǂ���

    private bool[] m_currentAttackState;//���݂̍U����

    public GameObject m_attackCol;//�U���̓����蔻��

    private bool m_isActive = false;//���݂��Ă��邩�ǂ���

    //-----------------------------------------------------------

    //�ʂ̃X�N���v�g���擾---------------------------------------
    EnemyNormalAttack m_normalAttack;// �ʏ�U��

    //-----------------------------------------------------------


    void Start()
    {
        Initialization();
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
    }

    private void OnTriggerEnter(Collider other)
    {
        //�f�o�b�O�p�_���[�W
        //TODO:�����������Ȃ̂ŃA���t�@�ŕύX����
        if (other.tag == "PlayerAttack")
        {
            ReceiveDamage();
        }
    }


    /// <summary>
    /// ������
    /// </summary>
    private void Initialization()
    {
        m_currentHP = 100;
        m_attackKinds = 3;
        m_currentAttackState = new bool[(int)AttackKinds.kAttackMaxKinds];

        m_normalAttack = new EnemyNormalAttack();

        m_isActive = false;
    }

    /// <summary>
    /// �ϐ��̒��g���X�V��������
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
    /// ���݂̋������擾
    /// </summary>
    private void SetDistance()
    {
        m_currentDistance = Vector3.Distance(m_targetPosition, m_enemyPosition);
    }

    /// <summary>
    /// �^�[�Q�b�g�Ɍ������Đi��
    /// </summary>
    private void GoToTarget()
    {
        var m_moveVec = m_targetPosition - transform.position;
        m_moveVec.Normalize();

        TurnTowards();
        SpeedChange();

        // �v���C���[�������ƈړ�
        if (m_currentDistance >= m_shortDistance)
        {
            //�I�u�W�F�N�g�̑O���ɐi�܂���
            transform.Translate(0, 0, m_speed, Space.Self);
            m_isCombat = false;
            for (int i = 0; i < (int)AttackKinds.kAttackMaxKinds; i++)
            {
                m_currentAttackState[i] = false;
            }
            m_isActive = false;
        }
        //�v���C���[�ɋ߂Â�����ԂɂȂ�Ɛ퓬�Ԑ��Ɉڂ�
        else if (m_currentDistance <= m_shortDistance)
        {
            m_isCombat = true;
        }

    }

    /// <summary>
    /// �X�s�[�h�̕ύX
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
    /// �^�[�Q�b�g�̕�������
    /// </summary>
    /// <param name="turnFlame">�����X�s�[�h</param>
    private void TurnTowards()
    {
        // �^�[�Q�b�g�̕����x�N�g��.
        Vector3 _direction = new Vector3(m_targetPosition.x - transform.position.x,
            0.0f, m_targetPosition.z - transform.position.z);
        // �����x�N�g������N�H�[�^�j�I���擾
        Quaternion _rotation = Quaternion.LookRotation(_direction, Vector3.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, _rotation, Time.deltaTime * m_rotateSpeed);
    }

    /// <summary>
    /// �_���[�W�����炤
    /// </summary>
    private void ReceiveDamage()
    {
        if (!m_isAlive) return;

        m_currentHP -= 10;
    }

    /// <summary>
    /// ���S����m_isAlive��false����
    /// </summary>
    private void Dead()
    {
        m_isAlive = false;
    }

    /// <summary>
    /// �C���^�[�o�������Z�b�g
    /// </summary>
    private void IntervalReset()
    {
        if (!m_isCombat)
        {
            m_currentAttackInterval = 0;
        }
    }

    /// <summary>
    /// �U���̎�ނ�Random�Ō��߂�
    /// </summary>
    private void GetAttackKinds()
    {
        m_attackKinds = Random.Range((int)AttackKinds.kNormalAttack, (int)AttackKinds.kAttackMaxKinds);
    }

    /// <summary>
    /// �U���̃C���^�[�o�������Z���Ă���
    /// </summary>
    private void AttackIntervalAdd()
    {
        m_currentAttackInterval++;

        // ���̃C���^�[�o�����߂���ƍU�����s��
        if (m_currentAttackInterval >= m_attackInterval)
        {

            AttackNumber();
            m_currentAttackInterval = 0;
        }
    }

    /// <summary>
    /// �U����m_attackKinds�̒l�ɂ���ĕς���
    /// (int)AttackKinds.kNormalAttack = �ʏ�U��
    /// (int)AttackKinds.kChargeAttack = ���ߍU��
    /// (int)AttackKinds.kComboAttack = �A���U��
    /// (int)AttackKinds.kRotateAttack = ��]�U��
    /// </summary>
    private void AttackNumber()
    {
        // �ʏ�U��
        if (m_attackKinds == (int)AttackKinds.kNormalAttack)
        {
            Debug.Log("�ʏ�U��");
            m_currentAttackState[(int)AttackKinds.kNormalAttack] = true;
            m_attackInterval = 400;
        }
        else if (m_attackKinds == (int)AttackKinds.kChargeAttack)
        {
            Debug.Log("���ߍU��");
            m_currentAttackState[(int)AttackKinds.kChargeAttack] = true;
            m_attackInterval = 400;
        }
        else if (m_attackKinds == (int)AttackKinds.kComboAttack)
        {
            Debug.Log("�A���U��");
            m_currentAttackState[(int)AttackKinds.kComboAttack] = true;
            m_attackInterval = 400;
        }
        else if (m_attackKinds == (int)AttackKinds.kRotateAttack)
        {
            Debug.Log("��]�U��");
            m_currentAttackState[(int)AttackKinds.kRotateAttack] = true;
            m_attackInterval = 400;
        }
    }

    /// <summary>
    /// �U�����肪���݂��Ă��邩
    /// </summary>
    private void AttackActive()
    {
        Debug.Log(m_isActive);
        m_attackCol.SetActive(m_isActive);
    }

    /// <summary>
    /// �U���̏���
    /// </summary>
    private void UpdateAttack()
    {
        if (m_currentAttackState[(int)AttackKinds.kNormalAttack])
        {
            if (m_currentAttackInterval >= m_attackInterval)
            {
                m_currentAttackState[(int)AttackKinds.kNormalAttack] = false;
            }
            DebugAttack(100, 200, new Vector3(0.0f, 0.1f, 0.06f), new Vector3(1.0f, 1.0f, 1.0f));
            Debug.Log("�ʏ�U��");
        }
        else if (m_currentAttackState[(int)AttackKinds.kChargeAttack])
        {
            if (m_currentAttackInterval >= m_attackInterval)
            {
                m_currentAttackState[(int)AttackKinds.kChargeAttack] = false;
            }
            DebugAttack(250, 300, new Vector3(0.0f, 0.1f, 0.06f), new Vector3(2.0f, 2.0f, 2.0f));
            Debug.Log("���ߍU��");
        }
        else if (m_currentAttackState[(int)AttackKinds.kComboAttack])
        {
            if (m_currentAttackInterval >= m_attackInterval)
            {
                m_currentAttackState[(int)AttackKinds.kComboAttack] = false;
            }
            DebugAttack(250, 300, new Vector3(0.0f, 0.1f, 0.06f), new Vector3(0.5f, 0.5f, 0.5f));
            Debug.Log("�A���U��");
        }
        else if (m_currentAttackState[(int)AttackKinds.kRotateAttack])
        {
            if (m_currentAttackInterval >= m_attackInterval)
            {
                m_currentAttackState[(int)AttackKinds.kRotateAttack] = false;
            }
            DebugAttack(200, 300, new Vector3(0.0f, 0.1f, 0.0f), new Vector3(2.0f, 2.0f, 2.0f));
            Debug.Log("��]�U��");
        }


    }

    /// <summary>
    /// �f�o�b�O�p�����蔻��
    /// </summary>
    /// <param name="isActiveTime"></param>
    /// <param name="noActiveTime"></param>
    /// <param name="scale"></param>
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
            Debug.Log("�ʂ�");
        }
    }
}
