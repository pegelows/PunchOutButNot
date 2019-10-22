using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeManager : MonoBehaviour {
    public bool snapToAngle = false;
    public float maxLeanAngle = 45f; // Degrees

    public float snapToDistance = 35f;
    public float snapAtDistance = 15f;

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
        float angle = playerViewport.transform.rotation.z;
        float leanDirection = Mathf.Abs(angle) / angle;

        if (snapToAngle) {
            if (Mathf.Abs(angle) > snapAtDistance) {
                angle = snapToDistance * leanDirection;
            } else {
                angle = 0f;
            }
        }

        this.transform.localRotation = Quaternion.Euler(0, 0, angle);
        this.transform.position = startPosition + (new Vector3(-leanDirection * Mathf.Sin(angle), Mathf.Cos(angle), 0f) * playerHeight);
    }
}
