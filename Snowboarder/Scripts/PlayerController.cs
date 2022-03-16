using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;

    SurfaceEffector2D surfaceEffector;

    [SerializeField] float torque = 1f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float slowSpeed = 10f;

    bool canMove = true;
    void Start()
    {
        canMove = true;
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector.speed = boostSpeed;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector.speed = slowSpeed;
        }
        else
        {
            surfaceEffector.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torque * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torque * Time.deltaTime);
        }
    }
}
