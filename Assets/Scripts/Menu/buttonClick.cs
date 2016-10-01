using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;

public class buttonClick : MonoBehaviour {

    public GameObject other;
    public GameObject intro1;
    public GameObject intro2;
    public GameObject intro3;

    public float scaleX;
    public float scaleY;
    public float oldScaleX;
    public float oldScaleY;
    public float moveX;

    public AudioSource audio;
    public AudioSource audio2;

    public string levelName;

    public bool exitButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        audio.Play();
        audio2.GetComponent<fadeInPiano>().enabled = false;
        audio2.GetComponent<fadeOutPiano>().enabled = true;
        Destroy(GetComponent<BoxCollider2D>());
        Destroy (other.GetComponent<BoxCollider2D>());
        if (GetComponent<buttonMovement>())
            Destroy(GetComponent<buttonMovement>());
        if (other.GetComponent<buttonMovement>())
            Destroy(other.GetComponent<buttonMovement>());
        transform.DOScale(new Vector3(scaleX, scaleY, 1), 0.1f).OnComplete(Normalize);
    }

    void Normalize()
    {
        transform.DOScale(new Vector3(oldScaleX, oldScaleY, 1), 0.1f).OnComplete(PhaseOut);
    }

    void PhaseOut()
    {
        Destroy(intro1.GetComponent<fadeInMenuText>());
        intro1.GetComponent<fadeOutMenuText>().enabled = true;
        Destroy(intro2.GetComponent<fadeInMenuText>());
        intro2.GetComponent<fadeOutMenuText>().enabled = true;
        Destroy(intro3.GetComponent<fadeInMenuText>());
        intro3.GetComponent<fadeOutMenuText>().enabled = true;

        transform.DOMoveX(moveX, 1.5f, false);
        other.transform.DOMoveX(moveX, 1.5f, false).OnComplete(Remove);
    }
    void Remove()
    {
        Destroy(other.GetComponent<buttonClick>());
        if (exitButton)
            Application.Quit();
        else
            SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }

    void OnMouseOver()
    {
        transform.DOScale(new Vector3(0.42f, 0.42f, 0.2f), 1);
    }

    void OnMouseExit()
    {
        transform.DOScale(new Vector3(0.40f, 0.40f, 0.2f), 1);
    }
}
