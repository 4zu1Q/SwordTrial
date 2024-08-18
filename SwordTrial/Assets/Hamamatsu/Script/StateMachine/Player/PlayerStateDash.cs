using UnityEngine;

public partial class PlayerState
{
    public class PlayerStateDash : StateBase
    {
        public override void OnEnter(PlayerState owner, StateBase prevState)
        {
            owner.m_dashMotion = true;
            owner.m_speed = 10;
        }

        public override void OnFixedUpdate(PlayerState owner)
        {
            owner.Move();
        }

        public override void OnExit(PlayerState owner, StateBase nextState)
        {
            owner.m_dashMotion = false;
        }

        public override void OnChangeState(PlayerState owner)
        {
            if (owner.m_inputHorizontal == 0 && owner.m_inputVertical == 0)
            {
                owner.StateTransition(m_idle);
            }
            
            if((owner.m_inputHorizontal != 0 || owner.m_inputVertical != 0) && Input.GetButtonUp("Abutton"))
            {
                owner.StateTransition(m_run);
                Debug.Log("‚Â‚Â");
            }
        }
    }
}