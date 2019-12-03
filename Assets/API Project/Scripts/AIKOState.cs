using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AIKOState : IAIState
{

    /// <summary>
    /// If statements must be used to assign different death animations for each enemy type by Tags
    /// </summary>
    /// <param name="previousState"></param>
    /// <param name="stateMachine"></param>


    // The "Death State" to determine if the enemy AI has been "killed".
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
