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

    public HealthManager healthManager;

    private void Start()
    {
        r = overlayImage.color.r;
        g = overlayImage.color.g;
        b = overlayImage.color.b;
        a = overlayImage.color.a;

       
    }

    private void Update()
    {
        
    }

    public void AdjustColor()
    {
        a = (healthManager.maxHP - healthManager.currentHP) / healthManager.maxHP;
        
        //The color value C is changed when the r,g,b,a are changed
        Color c = new Color(r, g, b, a);
        overlayImage.color = c;
    }
   
}
