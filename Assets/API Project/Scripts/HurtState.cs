using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HurtState : IAIState
{
    // The HurtState determines if the enemy has been hurt enough to be stunned.
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
