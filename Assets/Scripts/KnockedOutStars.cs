using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockedOutStars : MonoBehaviour {
    private int starCount = 0;
    private float currentAngle = 0f;
    private float currentEulerAngle = 0f;
    private int knockedDownStage = 0;
	private bool isKnockedDown = false;

	private Transform mainCamera;

    [SerializeField] private GameObject starPrefab;
    [SerializeField] private int starsPerStage = 2;
    [SerializeField] private float distance = 1f;
	[SerializeField] private float heightOffset = 0.25f;
    [SerializeField] private float rotationSpeed = 0.25f;
    [SerializeField] private float spinSpeed = 0.375f;

	public void Start() {
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		transform.parent = mainCamera;
	}

	public void Restart() {
		for (int i = 0; i < transform.childCount; i++)
			Destroy(transform.GetChild(i));

		starCount = 0;
		knockedDownStage = 0;
		currentAngle = 0f;
		currentEulerAngle = 0f;
	}

    void Update() {
		if (isKnockedDown) {
			if (transform.childCount > 0)
			{
				transform.position = mainCamera.position + new Vector3(0, heightOffset, 0);
				transform.rotation = Quaternion.identity;

				currentAngle = (currentAngle + (Time.deltaTime * rotationSpeed * 360f)) % 360f;
				currentEulerAngle = (currentEulerAngle + (Time.deltaTime * spinSpeed * 360f)) % 360f;

				for (int i = 0; i < transform.childCount; i++)
				{
					Transform child = transform.GetChild(i);
					float childAngle = ((currentAngle + ((360f / starCount) * int.Parse(child.name))) % 360f) * Mathf.Deg2Rad;

					child.localPosition = new Vector3(Mathf.Sin(childAngle), 0f, Mathf.Cos(childAngle)) * distance;
					child.localEulerAngles = new Vector3(0, currentEulerAngle + ((360f / starCount) * i));
				}
			} else { GetUp(); }
		}
    }

    private void GetUp() {
		starCount = 0;
		isKnockedDown = false;
    }

    public void KnockedDown() {
		if (!isKnockedDown)
		{
			isKnockedDown = true;
			knockedDownStage++;

			for (int i = 0; i < transform.childCount; i++)
				Destroy(transform.GetChild(i));

			for (int i = 0; i < (knockedDownStage * starsPerStage); i++)
			{
				GameObject newStar = Instantiate(starPrefab);
				newStar.name = i.ToString();
				newStar.transform.parent = transform;
			}

			starCount = knockedDownStage * starsPerStage;
		}
    }
}
