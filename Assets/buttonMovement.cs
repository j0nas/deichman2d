using UnityEngine;
using DG.Tweening;
using System.Collections;

public class buttonMovement : MonoBehaviour {

    public float time = 1;
    public float positionX;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if (Time.time > time)
        {
            transform.DOMoveX(positionX, 1.5f, false).OnComplete(destroyThisScript);
        }

    }

    void destroyThisScript()
    {
        Destroy(this);
    }
}
