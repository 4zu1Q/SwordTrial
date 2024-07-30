using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using State = StateMachine<PlayerState>.State;

public class PlayerState : MonoBehaviour
{
    private StateMachine<PlayerState> stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine<PlayerState>(this);
    }


    private class StateMove : State
    {
        
    }
}
