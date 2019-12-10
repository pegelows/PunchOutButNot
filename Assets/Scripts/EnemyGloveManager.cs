using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGloveManager : MonoBehaviour
{
    public EnemyStateMachine enemy;
    public string tagToHit;

    public float punchDelay;
    public bool canHitPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider c)
    {
        if (canHitPlayer && enemy.currentState == enemy.attackState)
        {
            if (c.gameObject.tag.Equals(tagToHit))
            {
                HittableLocation hitLocation = c.gameObject.GetComponent<HittableLocation>();

                if (hitLocation)
                {
                    hitLocation.ApplyDamage(((AttackState) enemy.currentState).damage);

                    canHitPlayer = false;
                    StartCoroutine(BlockedPunchDelay());

                    Debug.Log("Mitch got hit");
                }
            }
            else if (c.gameObject.tag.Equals("Glove"))
            {
                canHitPlayer = false;
                StartCoroutine(BlockedPunchDelay());
            }
        }
    }

    public IEnumerator BlockedPunchDelay()
    {
        yield return new WaitForSeconds(punchDelay);
        canHitPlayer = true;

    }
}
