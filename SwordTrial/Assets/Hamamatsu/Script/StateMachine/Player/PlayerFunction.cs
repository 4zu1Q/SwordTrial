/*�v���C���[�X�e�[�g�֐�*/

using UnityEngine;

public partial class PlayerState
{
    /// <summary>
    /// ������
    /// </summary>
    private void Init()
    {
        VariableInitialization();
        m_currentState.OnEnter(this, null);
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    private void UpdateFunc()
    {
        GetGamePadInformation();
        m_currentState.OnUpdate(this);
    }

    /// <summary>
    /// 50fps�Œ�X�V����
    /// </summary>
    private void FixedUpdateFunc()
    {
        StateFrameManager();
        AnimTransition();
        m_currentState.OnFixedUpdate(this);
        m_currentState.OnChangeState(this);
    }

    /// <summary>
    /// �ϐ��̏�����
    /// </summary>
    private void VariableInitialization()
    {
        m_currentFrame = 0;
        m_rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
    }

    /// <summary>
    /// ��ԑJ��
    /// </summary>
    /// <param name="nextState">���̏��</param>
    private void StateTransition(StateBase nextState)
    {
        // ��ԏI����
        m_currentState.OnExit(this, nextState);
        // �e��Ԃ̎��Ԃ����Z�b�g
        FrameReset();
        // ���̏�Ԃ̌Ăяo��
        nextState.OnEnter(this, m_currentState);
        // ���ɑJ�ڂ����Ԃ̑��
        m_currentState = nextState;

        StateTransitionInitialization();
    }

    /// <summary>
    /// ���݂̏�ԃt���[�����𑝂₷
    /// </summary>
    private void StateFrameManager()
    {
        m_currentFrame++;
    }

    // ��ԃt���[�������Z�b�g����
    private void FrameReset()
    {
        m_currentFrame = 0;
    }

    /// <summary>
    /// ��ԑJ�ڎ��̏������@
    /// </summary>
    private void StateTransitionInitialization()
    {
        m_currentFrame = 0;
    }

    /// <summary>
    /// �A�j���[�V�����J��
    /// </summary>
    private void AnimTransition()
    {
        m_animator.SetBool("Idle", m_idleMotion);
        m_animator.SetBool("Run", m_runMotion);
        m_animator.SetBool("Dash", m_dashMotion);

    }

    /// <summary>
    /// �Q�[���p�b�h�̂̓��͏��擾
    /// </summary>
    private void GetGamePadInformation()
    {
        // �X�e�B�b�N�̏����擾
        m_inputHorizontal = Input.GetAxis("Horizontal");
        m_inputVertical = Input.GetAxis("Vertical");
    }


    private void Move()
    {
        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        Vector3 m_cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 m_moveForward = m_cameraForward * m_inputVertical + Camera.main.transform.right * m_inputHorizontal;

        // �ړ������ɃX�s�[�h���|����B
        m_rigidbody.velocity = m_moveForward * m_speed;

        // �L�����N�^�[�̌�����i�s������
        if (m_moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(m_moveForward);
        }

        //A�{�^��
        //�����Ă���Ԃ̓_�b�V������
        if (Input.GetButton("Abutton"))
        {

            m_rigidbody.velocity = m_moveForward * m_speed * m_acel;
        }
    }
}
