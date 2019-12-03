using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockedOutStars : MonoBehaviour {
    private int starCount = 0;
    private float currentAngle = 0f;
    private float currentEulerAngle = 0f;
    [SerializeField] private float distance = 1f;
    [SerializeField] private float rotationSpeed = 0.25f;
    [SerializeField] private float spinSpeed = 0.375f;

    void Update() {
        starCount = transform.childCount;
        currentAngle = (currentAngle + (Time.deltaTime * rotationSpeed * 360f)) % 360f;
        currentEulerAngle = (currentEulerAngle + (Time.deltaTime * spinSpeed * 360f)) % 360f;

        for (int i = 0; i < starCount; i++) {
            Transform child = transform.GetChild(i);
            float childAngle = ((currentAngle + ((360f / starCount) * i)) % 360f) * Mathf.Deg2Rad;

            child.localPosition = new Vector3(Mathf.Sin(childAngle), 0f, Mathf.Cos(childAngle)) * distance;
            child.localEulerAngles = new Vector3(0, currentEulerAngle + ((360f / starCount) * i));
        }
    }
}
