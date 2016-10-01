using UnityEngine;
using System.Collections;


public class NewPlayerController : MonoBehaviour {

    public GameObject inverted;

    public float gridlenth;

    public bool isMoving;

    private Vector3 targetVector;
    private Vector3 invertedTargetVector;
    private float animTime;
    public float animLenght;

    private Animator myAnim;
    private Animator theirAnim;
    private SpriteRenderer mySprt;
    private SpriteRenderer theirSprt;

    private bool moveMe = false;
    private bool moveInverted = false;

	private string currentDirection = "";
	private string inverseDirection = "";

    [SerializeField] LayerMask wallLayer;

	// Use this for initialization
	void Start () {
        myAnim = GetComponent<Animator>();
        theirAnim = inverted.GetComponent<Animator>();
        mySprt = GetComponent<SpriteRenderer>();
        theirSprt = inverted.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKey && !isMoving)
        {
            switch (Input.inputString)
            {
			case "w":
				targetVector = transform.position + Vector3.up;
				invertedTargetVector = inverted.transform.position + Vector3.down;
				currentDirection = "up";
				inverseDirection = "down";
                LerpMove();
                break;
			case "a":
				targetVector = transform.position + Vector3.left;
				mySprt.flipX = true;
				invertedTargetVector = inverted.transform.position + Vector3.right;
				theirSprt.flipX = false;
				currentDirection = "left";
				inverseDirection = "right";
                LerpMove();
                break;
			case "d":
				targetVector = transform.position + Vector3.right;
				mySprt.flipX = false;
				invertedTargetVector = inverted.transform.position + Vector3.left;
				theirSprt.flipX = true;
				currentDirection = "right";
				inverseDirection = "left";
                LerpMove();
                break;
			case "s":
				targetVector = transform.position + Vector3.down;
				invertedTargetVector = inverted.transform.position + Vector3.up;
				currentDirection = "down";
				inverseDirection = "up";
				LerpMove ();
                break;
            }
        }
			
        if (isMoving)
        {
            if(moveMe) 
				transform.position = Vector3.Lerp(transform.position, targetVector, animTime / animLenght);

            if(moveInverted)
            	inverted.transform.position = Vector3.Lerp(inverted.transform.position, invertedTargetVector, animTime / animLenght);

            if(Vector3.Distance(transform.position, targetVector) < 0.005)
            {
                if (moveMe) transform.position = targetVector;
                if (moveInverted) inverted.transform.position = invertedTargetVector;
            }

			if (transform.position == targetVector || inverted.transform.position == invertedTargetVector)
            {
                isMoving = false;
                moveMe = false;
                moveInverted = false;
            }
                
            animTime += Time.deltaTime;
        }
    }

    void LerpMove()
    {
		if (RaycastAll(gameObject, currentDirection) != "wall")
        {
            moveMe = true;
        }
		if(RaycastAll(inverted, inverseDirection) != "wall")
        {
            moveInverted = true;
        }

		isMoving = moveMe || moveInverted;
		if (isMoving) {
			animTime = 0;
			myAnim.SetTrigger ("startWalk");
			theirAnim.SetTrigger ("startWalk");
		}
    }

    string RaycastAll(GameObject obj, string direction)
    {
		Vector2 dir;
		switch (direction) {
			case "left":
				dir = Vector2.left;
				break;
			case "right": 
				dir = Vector2.right;
				break;
			case "up":
				dir = Vector2.up;
				break;
			case "down":
				dir = Vector2.down; 
				break;
			default:
				dir = Vector2.down;
				break;
		}

		RaycastHit2D hit = Physics2D.Raycast(obj.transform.position, dir, gridlenth, wallLayer);

		if (hit.collider != null) {
			return hit.transform.tag;
		}else{
            return "null";
        }
    }

}




