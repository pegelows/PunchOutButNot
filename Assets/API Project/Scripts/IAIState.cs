using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAIState
{
    void OnStateEnter(IAIState previousState, EnemyStateMachine stateMachine);

    void OnStateUpdate(EnemyStateMachine stateMachine);

    void OnStateExit(IAIState nextState, EnemyStateMachine stateMachine);

    void OnTriggerStay(Collider other);
}
