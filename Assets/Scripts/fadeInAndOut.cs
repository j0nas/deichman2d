using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class fadeInAndOut : MonoBehaviour {

    public float fadeInTime;
    public float fadeOutTime;

    public string levelName = "";

	// Use this for initialization
	void Start () {

        GetComponent<Text>().CrossFadeAlpha(0, 0, false);

    }

    // Update is called once per frame
    void Update () {

        if (Time.time < 5)
        {
            GetComponent<Text>().CrossFadeColor(Color.white, fadeInTime, true, true);
            fadeInTime -= fadeInTime / 20;
        }

        if (Time.time > 5)
        {
            GetComponent<Text>().CrossFadeAlpha(0, fadeOutTime, false);
            fadeOutTime -= fadeOutTime / 20;
        }
        if (Time.time > 7f)
            LoadLevel();
        if (Input.GetMouseButtonDown(0))
            LoadLevel();
	
	}

    void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
