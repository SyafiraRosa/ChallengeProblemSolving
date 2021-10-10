﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public enum ballState
    {
        aim,
        fire,
        wait,
        endShot,
        endGame
    }

    public ballState currentBallState;

    public Rigidbody2D ball;
    private Vector2 mouseStartPosition;
    private Vector2 mouseEndPosition;
    public Vector2 tempVelocity;
    public Vector3 ballLaunchPosition;
    private float ballVelocityX;
    private float ballVelocityY;
    public float constantSpeed;
    public GameObject arrow;
    //private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = FindObjectOfType<GameManager>();
        currentBallState = ballState.aim;
        //gameManager.ballsInScene.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentBallState)
        {
            case ballState.aim:
                if (Input.GetMouseButtonDown(0))
                {
                    MouseClicked();
                }
                if (Input.GetMouseButton(0))
                {
                    MouseDragged();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    ReleaseMouse();
                }
                break;
            case ballState.fire:
                break;
            case ballState.wait:
                //currentBallState = ballState.endShot;
                //if(gameManager.ballsInScene.Count == 1)
                //{
                //    currentBallState = ballState.endShot;
                //}
                //break;
            case ballState.endShot:
                //for(int i = 0; i < gameManager.bricksInScene.Count; i++)
                //{
                //    gameManager.bricksInScene[i].GetComponent<BrickMovementController>().currentState = BrickMovementController.brickState.move;
                //}
                //gameManager.PlaceBricks();
                currentBallState = ballState.aim;
                break;
            case ballState.endGame:
                break;
            default:
                break;
        }

        
    }

    public void MouseClicked()
    {
        mouseStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mouseStartPosition);
    }

    public void MouseDragged()
    {
        //Move the Arrow
        arrow.SetActive(true);
        Vector2 tempMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float diffX = mouseStartPosition.x - tempMousePosition.x;
        float diffY = mouseStartPosition.y - tempMousePosition.y;
        if(diffY <= 0)
        {
            diffY = .01f;
        }
        float theta = Mathf.Rad2Deg * Mathf.Atan(diffX / diffY);
        arrow.transform.rotation = Quaternion.Euler(0f, 0f, -theta);
    }

    public void ReleaseMouse()
    {
        arrow.SetActive(false);
        mouseEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ballVelocityX = (mouseStartPosition.x - mouseEndPosition.x);
        ballVelocityY = (mouseStartPosition.y - mouseEndPosition.y);
        tempVelocity = new Vector2(ballVelocityX, ballVelocityY).normalized;
        ball.velocity = constantSpeed * tempVelocity;
        
        if(ball.velocity == Vector2.zero)
        {
            return;
        }
        ballLaunchPosition = transform.position;
        currentBallState = ballState.fire;
    }
}
