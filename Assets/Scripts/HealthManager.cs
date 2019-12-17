using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int maxHP;
    public float currentHP;

    public bool isPlayer;
    public KnockedOutStars stars;
    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        
    }

    public void ApplyDamage(float damageToGive)
    {
        currentHP -= damageToGive;

        if (currentHP <= 0)
        {
            if (isPlayer)
            {
                stars.KnockedDown();
                //SceneManager.LoadScene("Main Menu");
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void SetMaxHP()
    {
        currentHP = maxHP;
    }
}
