//�G�̏���

using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.UIElements;

public class EnemyState : MonoBehaviour
{
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
        //�f�o�b�O�p�_���[�W
        //TODO:�����������Ȃ̂ŃA���t�@�ŕύX����
        if(other.tag == "PlayerAttack")
        {
            Debug.Log("�ʂ�");
            ReceiveDamage();
        }
    }


    /// <summary>
    /// ������
    /// </summary>
    private void Initialization()
    {
        m_currentHP = 100;
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

        //m_currentDistance = Vector3.Distance(new Vector3(m_targetPosition.x, 0, m_targetPosition.y),
        //    new Vector3(m_enemyPosition.x, 0, m_enemyPosition.y));
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

        if (m_currentDistance >= m_shortDistance)
        {
            //�I�u�W�F�N�g�̑O���ɐi�܂���
            transform.Translate(0, 0, m_speed, Space.Self);
        }
        
    }

    /// <summary>
    /// �X�s�[�h�̕ύX
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
}
