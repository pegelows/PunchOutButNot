using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChaseState : IAIState
{
    /// <summary>
    /// If statements must be used to assign different chase parameters for each enemy type, subtype,
    /// and whether Hive Mind is present or not, by Tags
    /// </summary>
    /// <param name="previousState"></param>
    /// <param name="stateMachine"></param>

    [SerializeField] private float chaseAcceleration;

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
