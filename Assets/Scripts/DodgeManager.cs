using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeManager : MonoBehaviour {
    public bool snapToAngle = false;
    public float maxLeanAngle = 45f; // Degrees
    public float leanXOffset = 0.25f;
    public float duckingYOffset = 0.1f;

    public float snapToDistance = 35f;
    public float snapAtDistance = 35f;
    public float duckingSnapToDistance = 0.35f;

    public GameObject player;
    public GameObject playerViewport;
    
    private Vector3 startPosition;
    private Vector3 startViewportPosition;
    private float playerHeight;

    private bool leaning = false;
    private bool crouching = false;

    void Start() {
        startViewportPosition = playerViewport.transform.position;
        playerHeight = this.transform.localScale.y / 2f;
        startPosition = this.transform.position - new Vector3(0, playerHeight, 0);
    }

    // Update is called once per frame
    void Update() {
        float angle = 0f;// playerViewport.transform.eulerAngles.z;

        float xOffset = (playerViewport.transform.position - startViewportPosition).x;

        if (xOffset > leanXOffset)
        {
            angle = 360f - snapToDistance;
        }
        else if (xOffset < -leanXOffset)
        {
            angle = snapToDistance;
        }
        else { }
        /*else
        {
            leanDirection = (Mathf.Abs(angle) > 180f) ? -1f : 1f;

            if (snapToAngle)
            {
                if (leanDirection == 1f)
                {
                    if (angle > snapAtDistance)
                    {
                        angle = snapToDistance * leanDirection;
                    }
                    else
                    {
                        angle = 0f;
                    }
                }
                else
                {
                    if (angle < 360f - snapAtDistance)
                    {
                        angle = snapToDistance * leanDirection;
                    }
                    else
                    {
                        angle = 0f;
                    }
                }
            }
            else
            {
                if (leanDirection == 1f)
                {
                    angle = Mathf.Min(angle, maxLeanAngle);
                }
                else
                {
                    angle = Mathf.Max(angle, 360f - maxLeanAngle);
                }
            }
        }*/

        
        if (!leaning && (playerViewport.transform.position - startViewportPosition).y < -duckingYOffset)
        {
            this.transform.localScale = new Vector3(1f, 1f - duckingSnapToDistance, 1f);
            this.playerHeight = 0.5f * (1f - duckingSnapToDistance);
            crouching = true;
        }
        else
        {
            this.transform.localScale = new Vector3(1f, 1f, 1f);
            this.playerHeight = 0.5f;
            crouching = false;
        }

        if (crouching)
            angle = 0f;

        leaning = angle != 0f;

        this.transform.rotation = Quaternion.Euler(0, 0, angle);
        angle *= Mathf.Deg2Rad;
        this.transform.position = this.startPosition + (new Vector3(-Mathf.Sin(angle), Mathf.Cos(angle)) * this.playerHeight);
    }
}
