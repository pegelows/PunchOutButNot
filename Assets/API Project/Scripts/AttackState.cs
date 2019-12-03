using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackState : IAIState
{
    [Tooltip("How much damage the enemy does on an attack.")]
    [SerializeField] private float damage;
    [Tooltip("How often the enemy can attack.")]
    [SerializeField] private float attackDelay;
    [Tooltip("How long the enemy can attack for.")]
    public float attackDuration;
    [Tooltip("Timer that keeps track before enemy can attack again.")]
    public float timeElapsed;
    [Tooltip("The type of combos that the enemy chooses from.")]
    public int randomAttack;
    [Tooltip("The range within which the enemy will attempt to punch the player again")]
    public float attackRange;

    [Tooltip("How fast the AI will turn towards the player.")]
    [SerializeField] private float rotateSpeed;

    //PlayerHealth here
    // Determines if the Player is in range and can be hit
    public bool canHitPlayer;
    // Determines if the Player has been hit
    public bool hasHitplayer;
    
    public void OnStateEnter(IAIState previousState, EnemyStateMachine stateMachine)
    {
        // These are settings in the inspector that allow design to adjust variables for attacks
        timeElapsed = 0f;
        hasHitplayer = false;
        canHitPlayer = false;
        randomAttack = Random.Range(0, 10);
        ChooseCombo(stateMachine);
    }

    public void OnStateExit(IAIState nextState, EnemyStateMachine stateMachine)
    {

    }

    public void OnStateUpdate(EnemyStateMachine stateMachine)
    {
        timeElapsed += Time.deltaTime;

        //find the vector pointing from our position to the target
         Vector3 direction = (stateMachine.player.transform.position - stateMachine.transform.position);
        direction.y = 0;
        direction = direction.normalized;

        //create the rotation we need to be in to look at the target
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        //rotate us over time according to speed until we are in the required rotation
        stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);

        if (canHitPlayer == false && timeElapsed >= attackDelay)
        {
            canHitPlayer = true;
        }

       if(timeElapsed >= attackDuration)
       {
            if(hasHitplayer == true)
            {
                stateMachine.ChangeState(stateMachine.currentState);
            }
            else if (Vector3.Distance(stateMachine.player.transform.position, stateMachine.transform.position)<= attackRange)
            {
                stateMachine.ChangeState(stateMachine.currentState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.chaseState);
            }
       }

    }

    public void OnTriggerStay(Collider other)
    {
        if(canHitPlayer && !hasHitplayer)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                //Insert PlayerHealth
                hasHitplayer = true;
            }
        }
        throw new System.Exception("Player has no attached CharacterHealth component" );
    }

    public void ChooseCombo(EnemyStateMachine stateMachine)
    {
        if(randomAttack <= 3)
        {
            //Will need adjusting based on animations
            attackDuration = 3f;
            //Play animation
            stateMachine.anim.CrossFade("Lead Jab", 0.2f);
        }
        if(randomAttack >= 4 && randomAttack <= 6)
        {
            //Will need adjusting based on animations
            attackDuration = 2f;
            //Play animation
            stateMachine.anim.CrossFade("Jab Cross", 0.2f);
        }
        if(randomAttack >= 7 && randomAttack <= 8)
        {
            //Will need adjusting based on animations
            attackDuration = 4f;
            //Play animation
            stateMachine.anim.Play("Lead Jab");
           
            Debug.Log("Three hit combo");
        }
        if(randomAttack >= 9 && randomAttack <= 10)
        {
            //Will need adjusting based on animations
            attackDuration = 4f;
            //Play animation
            stateMachine.anim.CrossFade("Punch Combo", 0.2f);
        }
    }
}
