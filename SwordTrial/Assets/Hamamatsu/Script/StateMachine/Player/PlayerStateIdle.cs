/*ë“ã@èÛë‘*/

using UnityEngine;

public partial class PlayerState
{
    public class PlayerStateIdle : StateBase
    {
        public override void OnEnter(PlayerState owner, StateBase prevState)
        {
            owner.m_idleMotion = true;

            
        }

        public override void OnExit(PlayerState owner, StateBase nextState)
        {
            owner.m_idleMotion = false;
        }

        public override void OnChangeState(PlayerState owner)
        {
            if(owner.m_inputHorizontal != 0 || owner.m_inputVertical != 0) 
            {
                owner.StateTransition(m_run);
                Debug.Log("Ç†Ç†Ç†");
            }
        }
    }
}