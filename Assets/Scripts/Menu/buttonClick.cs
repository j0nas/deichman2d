using UnityEngine;
using DG.Tweening;
using System.Collections;

public class buttonClick : MonoBehaviour {

    public GameObject other;
    public GameObject intro1;
    public GameObject intro2;

    public float scaleX;
    public float scaleY;
    public float oldScaleX;
    public float oldScaleY;
    public float moveX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
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
        transform.DOMoveX(moveX, 1.5f, false);
        other.transform.DOMoveX(moveX, 1.5f, false).OnComplete(Remove);
    }
    void Remove()
    {
        Destroy(other.GetComponent<buttonClick>());
        Destroy(this);
    }
}
