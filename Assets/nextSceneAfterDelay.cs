using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class nextSceneAfterDelay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("BackToMainMenu", 16);
	
	}
	
	// Update is called once per frame
	void BackToMainMenu() {
        SceneManager.LoadScene(0);

    }
}
