using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public IAIState currentState;

    public SpawnState spawnState;
    public AttackState attackState;
    public ChaseState chaseState;
    public AIKOState aIKOState;
    public HurtState hurtState;
    
    void Start()
    {
        currentState = spawnState;
        spawnState.OnStateEnter(null, this);
    }

    void Update()
    {
        currentState.OnStateUpdate(this);
    }

    public void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }

    public void ChangeState(IAIState nextState)
    {
        currentState.OnStateExit(nextState, this);
        nextState.OnStateEnter(currentState, this);

        currentState = nextState;
    }
}
