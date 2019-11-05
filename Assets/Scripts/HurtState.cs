using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HurtState : IAIState
{
    // Entry state for all enemies which immediately sends them to their designated RoamingStates by Tag

    public void OnStateEnter(IAIState previousState, EnemyStateMachine stateMachine)
    {

    }

    public void OnStateExit(IAIState nextState, EnemyStateMachine stateMachine)
    {

    }

    public void OnStateUpdate(EnemyStateMachine stateMachine)
    {

    }

    public void OnTriggerStay(Collider other)
    {
        throw new System.NotImplementedException();
    }
}
