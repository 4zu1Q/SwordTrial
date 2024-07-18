using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyC;

public class EnemyMove : MonoBehaviour
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

    private bool[] m_currentAttackState;//���݂̍U����
    private bool m_isCombat = false;//�퓬�Ԑ��ɓ����Ă��邩�ǂ���
    private bool m_isActive = false;//���݂��Ă��邩�ǂ���


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
