﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBallMovement : MonoBehaviour
{
    private GameObject blackBall;
    private GameObject ball;
    public Table table;
    public BallMovement ballMovement;
    public Vector2 blackBallForce;
    private float aux;

    void Start()
    {
        blackBall = this.gameObject;
        ball = GameObject.Find("White-Ball");
        blackBallForce.x = 0.0f;
        blackBallForce.y = 0.0f;
    }

    void Update()
    {
        this.transform.Translate(blackBallForce);

        if (Vector3.Distance(ball.transform.position, blackBall.transform.position) <= ball.transform.lossyScale.x / 2.0f + blackBall.transform.lossyScale.x / 2.0f /*&& collides ==true*/)
        {
            blackBallForce = -ballMovement.force;
        }

        if (blackBall.transform.position.x >= (table.limitRight - blackBall.transform.lossyScale.x / 2) && blackBallForce.x > 0) blackBallForce.x *= -1;
        if (blackBall.transform.position.x <= table.limitLeft + blackBall.transform.lossyScale.x / 2 && blackBallForce.x < 0) blackBallForce.x *= -1;
        if (blackBall.transform.position.y >= table.limitUp - blackBall.transform.lossyScale.y / 2 && blackBallForce.y > 0) blackBallForce.y *= -1;
        if (blackBall.transform.position.y <= table.limitDown + blackBall.transform.lossyScale.y / 2 && blackBallForce.y < 0) blackBallForce.y *= -1;

        if (blackBallForce.x != 0.0f)
        {
            blackBallForce.x /= ballMovement.friction;
        }
        if (blackBallForce.y != 0.0f)
        {
            blackBallForce.y /= ballMovement.friction;
        }
        if (Mathf.Abs(blackBallForce.x) < ballMovement.minSpeed && Mathf.Abs(blackBallForce.x) != 0)
        {
            blackBallForce.x = 0.0f;
            Debug.Log((Vector2)ball.transform.position);
        }
        if (Mathf.Abs(blackBallForce.y) < ballMovement.minSpeed && Mathf.Abs(blackBallForce.y) != 0)
        {
            blackBallForce.y = 0.0f;
        }
    }
}
