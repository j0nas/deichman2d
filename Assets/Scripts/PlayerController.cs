﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int invertedX = 1;
    public int invertedY = 1;

    public int gridLenght;
    public float moveTime;

    private float animStartTime;
    private bool isMoving = false;
    private Animator anim;
    private SpriteRenderer sprt;

    private Vector3 currentMoveDirection;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        sprt = GetComponent<SpriteRenderer>();
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
        else
        {
            LerpMove(currentMoveDirection);
        }	
	}

    void Move(string button)
    {
        print("button");
        switch (button)
        {
            case "w":
                if(Physics2D.Raycast(transform.position, Vector2.up * invertedY, gridLenght))
                    return;               
                LerpMove(transform.position + new Vector3(0, gridLenght * invertedY, 0));
                anim.SetTrigger("startWalk");
                break;
            case "a":
                if (Physics2D.Raycast(transform.position, Vector2.left * invertedX, gridLenght))
                    return;
                sprt.flipX = true;
                LerpMove(transform.position + new Vector3(gridLenght * invertedX * (-1), 0, 0));
                anim.SetTrigger("startWalk");
                break;
            case "d":
                if (Physics2D.Raycast(transform.position, Vector2.right * invertedX, gridLenght))
                    return;
                    sprt.flipX = false;
                LerpMove(transform.position + new Vector3(gridLenght * invertedX, 0, 0));
                anim.SetTrigger("startWalk");
                break;
            case "s":
                if (Physics2D.Raycast(transform.position, Vector2.down * invertedY, gridLenght))
                    return;
                anim.SetTrigger("startWalk");
                LerpMove(transform.position + new Vector3(0, gridLenght * invertedY * (-1), 0));
                break;
        }

    }

    void RaycastForWalls()
    {
        Physics2D.Raycast(transform.position, Vector2.up, gridLenght);
    }

    void LerpMove(Vector3 target)
    {
        currentMoveDirection = target;
        if (!isMoving)
        {
            isMoving = true;
            animStartTime = 0;
        }
        transform.position = Vector3.Lerp(transform.position, target, (animStartTime / moveTime));
        animStartTime += Time.deltaTime;

        if(transform.position == target)
        {
            isMoving = false;
        }

    }


}
