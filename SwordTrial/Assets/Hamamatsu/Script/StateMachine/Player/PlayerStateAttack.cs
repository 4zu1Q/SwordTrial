/*攻撃状態*/

using Unity.VisualScripting;
using UnityEngine;

public partial class PlayerState
{
    public class PlayerStateAttack : StateBase
    {
        public override void OnEnter(PlayerState owner, StateBase prevState)
        {
            owner.m_attackMotion = true;
            
        }

        public override void OnFixedUpdate(PlayerState owner)
        {
            if(owner.m_currentFrame == 1)
            {
                Instantiate(owner.m_attackCol, owner.m_attackPos.transform.position, Quaternion.identity);
            }
        }

        public override void OnExit(PlayerState owner, StateBase nextState)
        {
            owner.m_attackMotion = false;
        }

        public override void OnChangeState(PlayerState owner)
        {
            // 100フレームたたないと状態遷移の条件をスキップする
            if (owner.m_currentFrame <= 20) return;

            if (owner.m_inputHorizontal == 0 && owner.m_inputVertical == 0)
            {
                owner.StateTransition(m_idle);
            }
            else if (owner.m_inputHorizontal != 0 || owner.m_inputVertical != 0 && !Input.GetButtonDown("Abutton"))
            {
                owner.StateTransition(m_run);
            }
            else if ((owner.m_inputHorizontal != 0 || owner.m_inputVertical != 0) && Input.GetButton("Abutton"))
            {
                owner.StateTransition(m_dash);
            }
        }
    }
}