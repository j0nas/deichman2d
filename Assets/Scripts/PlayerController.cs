using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int invertedX = 1;
    public int invertedY = 1;

    public int gridLenght;
    public float moveTime;

    private bool isMoving = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (!isMoving)
        {
            CheckForPress();
        }

	
	}

    void CheckForPress()
    {
        if (Input.GetButtonDown("Up"))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0,0, gridLenght * invertedY), moveTime);
        }

        if(Input.GetButtonDown("Left"))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(gridLenght * invertedX * (-1), 0, 0), moveTime);
        }

        if(Input.GetButtonDown("Right"))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(gridLenght * invertedX , 0, 0), moveTime);
        }

        if(Input.GetButtonDown("Down"))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 0, gridLenght * invertedY * (-1)), moveTime);
        }
    }


}
