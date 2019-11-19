using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableLocation : MonoBehaviour
{
    public HealthManager health;
    public float damageModifier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(float damageToGive)
    {
        health.ApplyDamage(damageToGive * damageModifier);
        Debug.Log("Damage dealt: " + (damageModifier * damageToGive));
    }
}
