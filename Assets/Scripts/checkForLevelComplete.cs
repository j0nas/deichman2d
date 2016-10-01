using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class checkForLevelComplete : MonoBehaviour {
	public string NextLevelName;

	private bool playerColliding = false;
	private bool partnerColliding = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D collObj) {
		if (collObj.gameObject.tag == "Player") {
			playerColliding = true;
		}
			
		if (collObj.gameObject.tag == "Partner") {
			partnerColliding = true;
		}

		if (playerColliding && partnerColliding) {
			SceneManager.LoadScene (NextLevelName);
		}
	}
}
