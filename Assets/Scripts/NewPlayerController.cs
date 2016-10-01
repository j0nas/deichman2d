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

    public bool oneBoolToRuleThemAll;

    private Animator myAnim;
    private Animator theirAnim;
    private SpriteRenderer mySprt;
    private SpriteRenderer theirSprt;

    private bool moveMe = false;
    private bool moveInverted = false;


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
                    LerpMove();
                    break;
                case "a":
                    targetVector = transform.position + Vector3.left;
                    mySprt.flipX = true;
                    invertedTargetVector = inverted.transform.position + Vector3.right;
                    theirSprt.flipX = false;
                    LerpMove();
                    break;
                case "d":
                    targetVector = transform.position + Vector3.right;
                    mySprt.flipX = false;
                    invertedTargetVector = inverted.transform.position + Vector3.left;
                    theirSprt.flipX = true;
                    LerpMove();
                    break;
                case "s":
                    targetVector = transform.position + Vector3.down;
                    invertedTargetVector = inverted.transform.position + Vector3.up;
                    LerpMove();
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
                if(moveMe)
                transform.position = targetVector;
                if(moveInverted)
                inverted.transform.position = invertedTargetVector;
            }

            if (transform.position == targetVector)
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
        if (RaycastAll(gameObject, targetVector) != "wall")
        {
            moveMe = true;
        }
        if(RaycastAll(inverted, invertedTargetVector) != "wall")
        {
            moveInverted = true;
        }

        if(RaycastAll(gameObject,targetVector) == "wall" && oneBoolToRuleThemAll)
        {
            moveInverted = false;
        }


        isMoving = true;
        animTime = 0;
        myAnim.SetTrigger("startWalk");
        theirAnim.SetTrigger("startWalk");
    }

    string RaycastAll(GameObject obj, Vector3 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(obj.transform.position, dir, gridlenth);
        if(hit.collider != null)
        return hit.transform.tag;
        else
        {
            return "null";
        }
    }

}




