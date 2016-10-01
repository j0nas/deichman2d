using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class checkForLevelComplete : MonoBehaviour {
	public string NextLevelName;

	public static bool playerColliding = false;
	public static bool partnerColliding = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D collObj) {
		if (collObj.gameObject.tag == "Player") {
			playerColliding = true;
			Debug.Log ("player colliding!");
		}
			
		if (collObj.gameObject.tag == "Partner") {
			partnerColliding = true;
			Debug.Log ("partner colliding!");
		}

		if (playerColliding && partnerColliding) {
			partnerColliding = false;
			playerColliding = false;
			SceneManager.LoadScene (NextLevelName, LoadSceneMode.Single);
		}
	}
}
