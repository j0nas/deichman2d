using UnityEngine;
using System.Collections;

public class fadeInPiano : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (GetComponent<AudioSource>().volume < 0.2)
        {
            GetComponent<AudioSource>().volume += 0.0003f;
        }
	
	}
}
