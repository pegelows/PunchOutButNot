using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveManager : MonoBehaviour
{
    public float chargingDistance; //- how close the gloves have to be to the player in order to charge
    public float chargeRate; //- how quickly the charge should build up on the glove
    public float chargeDrainRate; //- how quickly the charge will drain while the glove is outside the chargingDistance
    public float currentCharge; //- the current amount of charge the glove has
    public float maxCharge; //- what is the maximum amount of charge the glove can have

    public float headPunchDamage; //- the amount of damage a punch to the opponent's head will do
    public float bodyPunchDamage; //- the amount of damage a punch to the body will do

    public float punchDuration; //- the amount of time the glove has been outside the chargingDistance of the player
    public float punchTimeBeforeDrain; //- the amount of time the glove has to be outside the chargingDistance before the charge starts decreasing

    public Color fullChargeColor; //- The color the gloves should be when at maxCharge
    public Color zeroChargeColor; //- The color the gloves should be when at 0 charge


    public Collider gloveCollider;
    public GameObject player;
    public MeshRenderer gloveMesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float sqrDistance = (player.transform.position - this.transform.position).sqrMagnitude;
        Debug.Log("glove distance:" + Mathf.Sqrt(sqrDistance));
        //If the glove is held close to the player
        if (sqrDistance < chargingDistance * chargingDistance)
        {
            currentCharge += chargeRate * Time.deltaTime;
            if(currentCharge>maxCharge)
            {
                currentCharge = maxCharge;
            }

            UpdateGloveGlow();
            punchDuration = 0;
        }
        else //The players arm is extended
        {
            punchDuration += Time.deltaTime;
            if(punchDuration > punchTimeBeforeDrain)
            {
                currentCharge -= chargeDrainRate * Time.deltaTime;
                if(currentCharge<0)
                {
                    currentCharge = 0;
                }
                UpdateGloveGlow();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        float sqrDistance = (player.transform.position - this.transform.position).sqrMagnitude;

        //Is this a block?
        if (sqrDistance < chargingDistance * chargingDistance)
        {
            //TODO Disable opponents punch
        }
        else //This is a punch we threw
        {
            string tag = collision.gameObject.tag;

            switch (tag)
            {
                case "Glove":
                    //The punch was blocked
                    currentCharge = 0;
                    UpdateGloveGlow();

                    break;
                case "Head":

                    break;
                case "Body":

                    break;
            }
        }
    }

    void UpdateGloveGlow()
    {
        Color interp = Color.Lerp(zeroChargeColor, fullChargeColor, (currentCharge / maxCharge));
        gloveMesh.material.color = interp;
    }
}
