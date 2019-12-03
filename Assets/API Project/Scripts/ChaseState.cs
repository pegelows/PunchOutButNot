using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[System.Serializable]
public class ChaseState : IAIState
{
    /// <summary>
    /// If statements must be used to assign different chase parameters for each enemy type, subtype,
    /// and whether Hive Mind is present or not, by Tags
    /// </summary>
    /// <param name="previousState"></param>
    /// <param name="stateMachine"></param>
    [SerializeField] private UnityEngine.AI.NavMeshAgent agent;
    
    [Tooltip("This determines how far from the player the enemy AI will see in world space to check if it chases the player.")]
    [SerializeField] private float searchRange;
    [Tooltip("This variable determines the range the enemy AI must be from the player to attack.")]
    [SerializeField] private float attackRange;
    [Tooltip("This variable sets how often the enemy can attack within an adjusted period of time.")]
    [SerializeField] private float attackCooldown;
    [Tooltip("This is the countdown for how much cooldown remains.")]
    [SerializeField] private float cooldownRemaining;
    [Tooltip("How much damage the enemy does on an attack.")]
    [SerializeField] private float attackDamage;
    [Tooltip("How fast the AI will chase after the player.")]
    [SerializeField] private float chaseAcceleration;

    public void OnStateEnter(IAIState previousState, EnemyStateMachine stateMachine)
    {
        agent = stateMachine.GetComponent<UnityEngine.AI.NavMeshAgent>();

        cooldownRemaining = attackCooldown;
    }

    public void OnStateExit(IAIState nextState, EnemyStateMachine stateMachine)
    {

    }

    public void OnStateUpdate(EnemyStateMachine stateMachine)
    {
        // Ensure the boxer is still alive
        if (stateMachine.player == null)
        {
            // This is to clear boxer's current location such as when the current target dies
            stateMachine.player = null;
            agent.destination = stateMachine.transform.position;
            return;
        }

        if (Vector3.Distance(stateMachine.player.transform.position, stateMachine.transform.position) < searchRange)
        {
            // Follow Target
            agent.destination = stateMachine.player.transform.position;
            // Check if it's possible to attack target according to the cooldown time between attacks

            if (cooldownRemaining <= 0)
            {
                float squareDistance = (stateMachine.transform.position - stateMachine.player.transform.position).sqrMagnitude;//Square distance is faster computationally
                if (squareDistance <= attackRange * attackRange)
                {
                    agent.destination = stateMachine.transform.position;
                    stateMachine.ChangeState(stateMachine.attackState);
                    // Within attack range to attack the target
                    // PlayerHealth targetHealth = target.GetComponent<PlayerHealth>();
                    // if (targetHealth != null)
                    // {
                    //     targetHealth.ReduceHealth(attackDamage);
                    //     cooldownRemaining = attackCooldown;
                    //     if (targetHealth.totalHealth <= 0)
                    //     {
                    //         target = null;
                    //     }

                    // }
                }
            }
            else
            {
                cooldownRemaining -= Time.deltaTime;
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        throw new System.NotImplementedException();
    }
}
