using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class checkForLevelComplete : MonoBehaviour {
    public bool manualLoadWIthString;
    public string NextLevelName;

	public static bool playerColliding = false;
	public static bool partnerColliding = false;


	void OnTriggerExit2D(Collider2D collObj) {
		if (collObj.gameObject.tag == "Player") {
			playerColliding = false;
		}

		if (collObj.gameObject.tag == "Partner") {
			partnerColliding = false;
		}
	}

	void OnTriggerEnter2D(Collider2D collObj) {
		if (collObj.gameObject.tag == "Player") {
			playerColliding = true;
		}
			
		if (collObj.gameObject.tag == "Partner") {
			partnerColliding = true;
		}

		Debug.Log (partnerColliding + " " + playerColliding);
		if (playerColliding && partnerColliding) {
			partnerColliding = false;
			playerColliding = false;
            if (manualLoadWIthString)
            {
			SceneManager.LoadScene (NextLevelName, LoadSceneMode.Single);
            }
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}
}
