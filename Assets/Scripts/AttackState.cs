using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackState : IAIState
{
    [SerializeField] private float damage;
    [SerializeField] private float attackDelay;

    /// <summary>
    /// If statements must be used to assign different attacks for each enemy type and subtype by Tags
    /// </summary>
    /// <param name="previousState"></param>
    /// <param name="stateMachine"></param>

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
