using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movespeed = 5f;

    public Transform orientation; // assign the orientation object from Cameramovement

    Rigidbody rb;

    float health, maxHealth = 100f;
    public FloatingHealthBar healthBar;


    void Start()

    {

        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true; // prevents tipping over

    }



    void FixedUpdate()

    {

        // get input

        float horizontal = 0f;

        float vertical = 0f;



        if (Input.GetKey("d")) horizontal = 1f;

        if (Input.GetKey("a")) horizontal = -1f;

        if (Input.GetKey("w")) vertical = 1f;

        if (Input.GetKey("s")) vertical = -1f;



        // calculate move direction relative to camera orientation

        Vector3 moveDirection = orientation.forward * vertical + orientation.right * horizontal;

        moveDirection.y = 0f; // prevent moving up/down



        moveDirection.Normalize(); // prevent faster diagonal movement



        // move player

        rb.MovePosition(rb.position + moveDirection * movespeed * Time.fixedDeltaTime);

    }

}

