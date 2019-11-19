using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackState : IAIState
{
    [SerializeField] private float damage;

    [SerializeField] private float attackDelay;

    public float attackDuration;
    public float timeElapsed;
    public int randomAttack;
    //PlayerHealth here
    public bool canHitPlayer;
    public bool hasHitplayer;
    
    public void OnStateEnter(IAIState previousState, EnemyStateMachine stateMachine)
    {
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

        if(canHitPlayer == false && timeElapsed >= attackDelay)
        {
            canHitPlayer = true;
        }

       if(timeElapsed >= attackDuration)
       {
            if(hasHitplayer == true)
            {
                stateMachine.ChangeState(stateMachine.currentState);
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
