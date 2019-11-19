using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthIndication : MonoBehaviour
{   
    public Image overlayImage;

    private float r;
    private float g;
    private float b;
    private float a;

    //the player's active health
    public int curHealth;
    public int maxHealth = 100;

    private void Start()
    {
        r = overlayImage.color.r;
        g = overlayImage.color.g;
        b = overlayImage.color.b;
        a = overlayImage.color.a;

        curHealth = maxHealth;
    }

    private void Update()
    {
        //just to see the current inputs of color
        if (Input.GetKey(KeyCode.P))
        {
            a -= 0.01f;
        }
        if (Input.GetKey(KeyCode.O))
        {
            a += 0.01f;
        }

        a = Mathf.Clamp(a, 0, 255f);
        AdjustColor();

        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if(curHealth <= 75)
        {
            a = 10;
        }
        if(curHealth <=50)
        {
            a = 20;
        }
        if (curHealth <= 50)
        {
            a = 30;
        }        
        if (curHealth <= 0)
        {
            a = 35;
        }
    }

    private void AdjustColor()
    {
        //The color value C is changed when the r,g,b,a are changed
        Color c = new Color(r, g, b, a);
        overlayImage.color = c;
    }
   
}
