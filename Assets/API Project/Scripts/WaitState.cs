using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaitState : IAIState
{
    public void OnStateEnter(IAIState previousState, EnemyStateMachine stateMachine)
    {
        stateMachine.anim.SetFloat("vertical", 0f);
    }

    public void OnStateExit(IAIState nextState, EnemyStateMachine stateMachine)
    {

    }

    public void OnStateUpdate(EnemyStateMachine stateMachine)
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        
    }
}
