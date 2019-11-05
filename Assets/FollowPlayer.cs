using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] private Transform target;

    [SerializeField] private string targetableTags;

    [SerializeField] private bool hasTarget = false;

    [SerializeField] private float searchRange;
    [SerializeField] private float attackRange;

    [SerializeField] private float attackCooldown;
    [SerializeField] private float cooldownRemaining;

    [SerializeField] private float attackDamage;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        cooldownRemaining = attackCooldown;
        hasTarget = false;
    }

    void Update()
    {
        if (hasTarget)
        {
            // Ensure the boxer is still alive
            if (target == null)
            {
                // This is to clear boxer's current location such as when the current target dies
                target = null;
                hasTarget = false;
                agent.destination = this.transform.position;
                return;
            }


            // Follow Target
            agent.destination = target.position;
            // Check if it's possible to attack target according to the cooldown time between attacks

            if (cooldownRemaining <= 0)
            {
                float squareDistance = (this.transform.position - target.position).sqrMagnitude;//Square distance is faster computationally
                if (squareDistance <= attackRange * attackRange)
                {
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
        else
        {
            // Look for the boxer in range in case we want to make the compAI not follow
            // if the player is a certain distance away
            Collider[] objectsInRange = Physics.OverlapSphere(this.transform.position, searchRange);

            foreach (Collider c in objectsInRange)
            {
                if (targetableTags.Contains(c.tag))
                {
                    hasTarget = true;
                    target = c.transform;
                }
                
            }
        }
    }
}
