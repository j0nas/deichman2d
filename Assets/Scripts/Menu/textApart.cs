using UnityEngine;
using DG.Tweening;
using System.Collections;

public class textApart : MonoBehaviour {

    public float time = 5;
    public float moveX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Time.time > time)
        {
            transform.DOLocalMoveX(moveX, 900, false);
        }
	}
}
