using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingBagOption : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<GloveManager>() != null) {
            if (this.name == "Start") {
                GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenu>().PlayGame();
            } else if (this.name == "Quit") {
				GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenu>().QuitGame();

				//GameObject.Find("Stars").GetComponent<KnockedOutStars>().KnockedDown();
            }
        }
    }
}
