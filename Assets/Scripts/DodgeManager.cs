using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeManager : MonoBehaviour {
    public bool snapToAngle = false;
    public float maxLeanAngle = 45f; // Degrees

    public float snapToDistance = 35f;
    public float snapAtDistance = 35f;

    public GameObject player;
    public GameObject playerViewport;
    
    private Vector3 startPosition;
    private float playerHeight;

    void Start() {
        playerHeight = this.transform.localScale.y / 2f;
        startPosition = this.transform.position - new Vector3(0, playerHeight, 0);
    }

    // Update is called once per frame
    void Update() {
        float angle = playerViewport.transform.eulerAngles.z;
        float leanDirection = (Mathf.Abs(angle) > 180f) ? -1f : 1f;

        if (snapToAngle) {
            if (leanDirection == 1f) {
                if (angle > snapAtDistance) {
                    angle = snapToDistance * leanDirection;
                } else {
                    angle = 0f;
                }
            } else {
                if (angle < 360f - snapAtDistance) {
                    angle = snapToDistance * leanDirection;
                } else {
                    angle = 0f;
                }
            }
        } else {
            if (leanDirection == 1f) {
                angle = Mathf.Min(angle, maxLeanAngle);
            } else {
                angle = Mathf.Max(angle, maxLeanAngle);
            }
        }

        this.transform.rotation = Quaternion.Euler(0, 0, angle);
        angle *= Mathf.Deg2Rad;
        this.transform.position = startPosition + (new Vector3(-Mathf.Sin(angle), Mathf.Cos(angle), 0f) * playerHeight);
    }
}
