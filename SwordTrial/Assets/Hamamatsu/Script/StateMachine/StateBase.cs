// ��ԊǗ��̒��ۃN���X

public abstract class StateBase
{
    /*�v���C���[*/
    /// <summary>
    /// �X�e�[�g�J�n���Ăяo��
    /// </summary>
    /// <param name="owner">�A�N�Z�X���邽�߂̎Q��</param>
    /// <param name="prevState">�ЂƂO�̏��</param>
    public virtual void OnEnter(PlayerState owner, StateBase prevState) { }
    /// <summary>
    /// Update
    /// </summary>
    /// <param name="owner">�A�N�Z�X���邽�߂̎Q��</param>
    public virtual void OnUpdate(PlayerState owner) { }
    /// <summary>
    /// FixedUpdate
    /// </summary>
    /// <param name="owner">�A�N�Z�X���邽�߂̎Q��</param>
    public virtual void OnFixedUpdate(PlayerState owner) { }
    /// <summary>
    /// �X�e�[�g�I�����Ăяo��
    /// </summary>
    /// <param name="owner">�A�N�Z�X���邽�߂̎Q��</param>
    /// <param name="nextState">���ɑJ�ڂ�����</param>
    public virtual void OnExit(PlayerState owner, StateBase nextState) { }
    /// <summary>
    /// �X�e�[�g�J�ڂ̌Ăяo��
    /// </summary>
    /// <param name="owner">�A�N�Z�X���邽�߂̎Q��</param>
    public virtual void OnChangeState(PlayerState owner) { }


    /*�����X�^�[*/
    /// <summary>
    /// �X�e�[�g�J�n���Ăяo��
    /// </summary>
    /// <param name="owner">�A�N�Z�X���邽�߂̎Q��</param>
    /// <param name="prevState">�ЂƂO�̏��</param>
    public virtual void OnEnter(EnemyState owner, StateBase prevState) { }
    /// <summary>
    /// Update
    /// </summary>
    /// <param name="owner">�A�N�Z�X���邽�߂̎Q��</param>
    public virtual void OnUpdate(EnemyState owner) { }
    /// <summary>
    /// FixedUpdate
    /// </summary>
    /// <param name="owner">�A�N�Z�X���邽�߂̎Q��</param>
    public virtual void OnFixedUpdate(EnemyState owner) { }
    /// <summary>
    /// �X�e�[�g�I�����Ăяo��
    /// </summary>
    /// <param name="owner">�A�N�Z�X���邽�߂̎Q��</param>
    /// <param name="nextState">���ɑJ�ڂ�����</param>
    public virtual void OnExit(EnemyState owner, StateBase nextState) { }
    /// <summary>
    /// �X�e�[�g�J�ڂ̌Ăяo��
    /// </summary>
    /// <param name="owner">�A�N�Z�X���邽�߂̎Q��</param>
    public virtual void OnChangeState(EnemyState owner) { }
}
