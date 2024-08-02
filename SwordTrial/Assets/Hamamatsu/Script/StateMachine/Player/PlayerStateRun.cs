public partial class PlayerState
{
    public class PlayerStateRun : StateBase
    {
        public override void OnEnter(PlayerState owner, StateBase prevState)
        {
            owner.m_runMotion = true;
        }

        public override void OnFixedUpdate(PlayerState owner)
        {
            owner.Move();
        }

        public override void OnExit(PlayerState owner, StateBase nextState)
        {
            owner.m_runMotion = false;
        }

        public override void OnChangeState(PlayerState owner)
        {
            if (owner.m_inputHorizontal == 0 && owner.m_inputVertical == 0)
            {
                owner.StateTransition(m_idle);
            }
        }
    }
}