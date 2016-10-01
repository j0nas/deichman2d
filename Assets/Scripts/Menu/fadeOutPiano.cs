using UnityEngine;
using System.Collections;

public class fadeOutPiano : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<AudioSource>().volume += -0.002f;
	
	}
}
