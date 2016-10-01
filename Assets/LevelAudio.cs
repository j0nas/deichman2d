using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelAudio : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name != "menu")
        {
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

    }
}
