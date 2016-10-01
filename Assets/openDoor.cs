using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour {

    public GameObject door;

    private AudioSource _audio;

	// Use this for initialization
	void Start () {
        _audio = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Partner")
        {
            _audio.Play();
            Destroy(door);
            //Destroy(this.gameObject);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<openDoor>().enabled = false;

        }

    }
}
