using UnityEngine;
using System.Collections;

public class checkForLevelComplete : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collObj) {
		if (collObj.gameObject.tag == "Partner") {
			Debug.Log ("PARTNER COLLIDE!");
		}
	}
}
