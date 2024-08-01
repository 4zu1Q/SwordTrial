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
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    private void UpdateFunc()
    {

    }

    /// <summary>
    /// 50fps�Œ�X�V����
    /// </summary>
    private void FixedUpdateFunc()
    {
        StateFrameManager();
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
        // ����s���ɂ����Ԃ�
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


}
