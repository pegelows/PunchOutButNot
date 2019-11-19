using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHP;
    public float currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
            Debug.Log("No health left");
            //SceneManager.LoadScene("Main Menu");

        }
    }

    public void ApplyDamage(float damageToGive)
    {
        currentHP -= damageToGive;
    }

    public void SetMaxHP()
    {
        currentHP = maxHP;
    }
}
