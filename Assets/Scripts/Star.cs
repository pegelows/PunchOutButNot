using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
	private void OnTriggerEnter(Collider other) {
		GloveManager glove = other.GetComponent<GloveManager>();
		
		if (glove != null)
			if (glove.currentCharge >= glove.maxCharge / 2f) {
				glove.currentCharge = 0;
				glove.UpdateGloveGlow();

				Destroy(gameObject);
			}
    }
}
