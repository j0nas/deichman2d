using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class fadeInAndOut : MonoBehaviour {

    public float fadeInTime;
    public float fadeOutTime;

    public bool manualLoadWIthString;
    public string levelName = "";

	// Use this for initialization
	void Start () {

        GetComponent<Text>().CrossFadeAlpha(0, 0, false);

    }

    // Update is called once per frame
    void Update () {

        if (Time.timeSinceLevelLoad < 2.5f)
        {
            GetComponent<Text>().CrossFadeColor(Color.white, fadeInTime, true, true);
            fadeInTime -= fadeInTime / 10;
        }

        if (Time.timeSinceLevelLoad > 2.5f)
        {
            GetComponent<Text>().CrossFadeAlpha(0, fadeOutTime, false);
            fadeOutTime -= fadeOutTime / 15;
        }
        if (Time.timeSinceLevelLoad > 4f)
            LoadLevel();
        if (Input.GetMouseButtonDown(0))
            LoadLevel();
	
	}

    void LoadLevel()
    {
        if (manualLoadWIthString)
        {
            SceneManager.LoadScene(levelName);
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
