//�G�̏���

using UnityEngine;
using UnityEngine.UI;

public class EnemyC : MonoBehaviour
{
    /*UI*/
    public Slider m_slider;

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

    //�A�j���[�V����-------------------------------------------
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


    //���W------------------------------------------------------
    private Vector3 m_targetPosition;//�ǐՂ���^�[�Q�b�g
    private Vector3 m_enemyPosition;//�G
    public bool m_dashAnimation = false;
    //----------------------------------------------------------

    //�����ƓG�̋���--------------------------------------------
    private float m_currentDistance = 0;//���݂̋���
    [SerializeField] private float m_shortDistance = 0;//�ŒZ����
    //----------------------------------------------------------

    //��]���x
    [SerializeField] private float m_rotateSpeed = 0;

    //�̗�-------------------------------------------------------
    public int m_currentHP = 100;//����
    public readonly int m_maxHP = 100;//�ő�l
    public readonly int m_minHP = 0;//�ŏ��l
    //-----------------------------------------------------------

    //�����Ă��邩�ǂ������擾
    private bool m_isAlive = true;

    //�U��-------------------------------------------------------
    //�U���ƍU���̊Ԃɂ���C���^�[�o���A�U���ɂ���ăC���^�[�o���̎��Ԃ�ύX
    public int m_attackInterval = 10;
    private int m_currentAttackInterval = 0;//���݂̃C���^�[�o��

    public int m_attackKinds = 0;//���̍U��������̂������߂�

    private bool m_isCombat = false;//�퓬�Ԑ��ɓ����Ă��邩�ǂ���

    private bool[] m_currentAttackState;//���݂̍U����

    public GameObject m_attackCol;//�U���̓����蔻��

    private bool m_isActive = false;//���݂��Ă��邩�ǂ���

    public bool m_isAttackAnimation1 = false;
    public bool m_isAttackAnimation2 = false;
    public bool m_isAttackAnimation3 = false;
    public bool m_isAttackAnimation4 = false;

    //-----------------------------------------------------------

    private EnemyAnimation m_pAnimation;

    //�ʂ̃X�N���v�g���擾---------------------------------------
    EnemyNormalAttack m_normalAttack;// �ʏ�U��

    //-----------------------------------------------------------

    //�A�j���[�V�����𒆒f�������ǂ���
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

        m_slider.value = m_currentHP;
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

            m_frame = 0;

        }
        //�v���C���[�ɋ߂Â�����ԂɂȂ�Ɛ퓬�Ԑ��Ɉڂ�
        else if (m_currentDistance <= m_shortDistance)
        {
            m_isCombat = true;
        }


        // �U�����s����Ԃ��I��������̏���
        if(!m_isCombat && m_currentAttackInterval == 0 && !m_animInterrupt)
        {
            Debug.Log("�ʂ�");
            m_anim.SetTrigger(m_walk);
            m_animInterrupt = true;
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
            m_dashAnimation = true;
        }
        else
        {
            m_speed = 0.01f;
            m_dashAnimation = false;
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
    public void ReceiveDamage()
    {
        if (!m_isAlive) return;

        m_currentHP -= 10;

        m_slider.value = m_currentHP;
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
    public void GetAttackKinds()
    {
        //m_attackKinds = Random.Range((int)AttackKinds.kNormalAttack, (int)AttackKinds.kAttackMaxKinds);

        m_attackKinds = (int)AttackKinds.kComboAttack;
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
        //Debug.Log("m_attackInterval" + m_attackInterval);
        //Debug.Log("m_frame" + m_frame);
    }

    /// <summary>
    /// �U����m_attackKinds�̒l�ɂ���ĕς���
    /// (int)AttackKinds.kNormalAttack = �ʏ�U��
    /// (int)AttackKinds.kChargeAttack = ���ߍU��
    /// (int)AttackKinds.kComboAttack = �A���U��
    /// (int)AttackKinds.kRotateAttack = ��]�U��
    /// </summary>
    public void AttackNumber()
    {
        // �ʏ�U��
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
    /// �U�����肪���݂��Ă��邩
    /// </summary>
    private void AttackActive()
    {
        m_attackCol.SetActive(m_isActive);
    }

    /// <summary>
    /// �U���̏���
    /// </summary>
    private void UpdateAttack()
    {
        //�ʏ�U��
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
        //���ߍU��
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
        //�A���U��
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
                Debug.Log("�ʂ�");
                m_animInterrupt = true;
                m_anim.SetTrigger(m_walk);
            }
            else if (m_frame == 400)
            {
                m_frame = 0;
            }
            // �U���I�����ɌĂяo�����
            if (m_currentAttackInterval >= m_attackInterval)
            {
                m_currentAttackState[(int)AttackKinds.kComboAttack] = false;
                m_isAttackAnimation3 = false;
            }
        }
        //��]�U��
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
    /// �f�o�b�O�p�����蔻��
    /// </summary>
    /// <param name="isActiveTime">�����蔻�萶���^�C�~���O</param>
    /// <param name="noActiveTime">�����蔻������^�C�~���O</param>
    /// <param name="position">�����ʒu</param>
    /// <param name="scale">�傫��</param>
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
