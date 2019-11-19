using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    public int maxHP;
    public float currentHP;


    public UnityEvent onHealthChanged;

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

        //just to see the current inputs of color
        if (Input.GetKeyDown(KeyCode.P))
        {
            ApplyDamage(5);
        }
        //if (Input.GetKey(KeyCode.O))
        //{
          //  a += 0.01f;
        //}
    }

    public void ApplyDamage(float damageToGive)
    {
        currentHP -= damageToGive;

        onHealthChanged.Invoke();
    }

    public void SetMaxHP()
    {
        currentHP = maxHP;
    }
}
