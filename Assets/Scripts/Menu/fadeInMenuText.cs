using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class fadeInMenuText : MonoBehaviour {

    public float time = 1f;
    public float fadeTime;

	// Use this for initialization
	void Start () {
        GetComponent<Text>().CrossFadeAlpha(0, 0, false);
    }

    // Update is called once per frame
    void Update () {

        if (Time.time > time)
        {
            GetComponent<Text>().CrossFadeColor(Color.white, fadeTime, true, true);
            fadeTime += -fadeTime / 10;
        }
	}
}
