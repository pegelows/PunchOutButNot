using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    
    [HideInInspector]
    public IAIState currentState;
    [HideInInspector]
    public SpawnState spawnState;
    [Tooltip("Enemy AI decides what types of boxing attacks it will do. Including combo randomization.")]
    public AttackState attackState;
    [Tooltip("Enemy AI finds the player in world space, tracks the player, and chases the player down.")]
    public ChaseState chaseState;
    [Tooltip("Enemy AI will simply idle")]
    public WaitState waitState;
    [Tooltip("This determines if the enemy AI has been knocked out and placed in 'dead state'.")]
    public AIKOState aIKOState;
    [Tooltip("Determines if enemy AI boxer has been injured enough to be stunned.")]
    public HurtState hurtState;

    public GameObject player;

    public Animator anim;
    void Start()
    {
        // This can be eliminated or commented out if an animator is not needed.
        if (GetComponentInChildren<Animator>())
        {
            anim = GetComponentInChildren<Animator>();
        }
        // This is the starting state for the enemy AI. It will then go into ChaseState if it is out of range of an attack.
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
