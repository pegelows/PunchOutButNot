using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public IAIState currentState;

    public AttackState attackState;
    public ChaseState chaseState;
    public AIKOState aIKOState;
    public HurtState hurtState;

    
    public FollowPlayer followPlayer;

    

    void Start()
    {
        currentState = chaseState;
        chaseState.OnStateEnter(null, this);
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
