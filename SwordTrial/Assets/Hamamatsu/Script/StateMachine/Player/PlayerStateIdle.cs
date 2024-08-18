/*待機状態*/

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
            if (Input.GetButtonDown("Xbutton"))
            {
                owner.StateTransition(m_attack);
            }

            // 移動する
            if(owner.m_inputHorizontal != 0 || owner.m_inputVertical != 0 && !Input.GetButtonDown("Abutton")) 
            {
                owner.StateTransition(m_run);
            }
            // ダッシュする
            else if ((owner.m_inputHorizontal != 0 || owner.m_inputVertical != 0) && Input.GetButton("Abutton"))
            {
                owner.StateTransition(m_dash);
            }
        }
    }
}