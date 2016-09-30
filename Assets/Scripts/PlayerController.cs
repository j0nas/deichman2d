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
            if (Input.anyKeyDown)
            {
                Move(Input.inputString);
            }
        }

	
	}

    void Move(string button)
    {
        switch (button)
        {
            case "w":
                if(Physics2D.Raycast(transform.position, Vector2.up * invertedY, gridLenght))
                    return;
                
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, gridLenght * invertedY, 0), moveTime);
                break;
            case "a":
                if (Physics2D.Raycast(transform.position, Vector2.left * invertedX, gridLenght))
                    return;
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(gridLenght * invertedX * (-1), 0, 0), moveTime);
                break;
            case "d":
                if (Physics2D.Raycast(transform.position, Vector2.right * invertedX, gridLenght))
                    return;
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(gridLenght * invertedX, 0, 0), moveTime);
                break;
            case "s":
                if (Physics2D.Raycast(transform.position, Vector2.down * invertedY, gridLenght))
                    return;
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, gridLenght * invertedY * (-1), 0), moveTime);
                break;
        }
    }

    void RaycastForWalls()
    {
        Physics2D.Raycast(transform.position, Vector2.up, gridLenght);
    }


}
