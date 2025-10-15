using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{

    public float throwSpeed = 20f;

    public float returnSpeed = 15f;

    public float maxDistance = 10f;

    public Transform playerTransform;



    private Rigidbody rb;

    private Vector3 initialPosition;

    private bool returning = false;



    void Start()

    {

        rb = GetComponent<Rigidbody>();

        rb.linearVelocity = transform.forward * throwSpeed;

        initialPosition = transform.position;

    }



    void Update()

    {

        if (!returning)

        {

            // Check if max distance reached

            if (Vector3.Distance(initialPosition, transform.position) >= maxDistance)

            {

                returning = true;

            }

        }

        else

        {

            // Move back toward player

            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

            rb.linearVelocity = directionToPlayer * returnSpeed;



            // Destroy boomerang when close to player

            if (Vector3.Distance(playerTransform.position, transform.position) < 1f)

            {

                Destroy(gameObject); // Destroy instead of SetActive(false)

            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //If the boomerang hits an object tagged as "Target"
        if (collision.gameObject.CompareTag("Target"))
        {
            Destroy(collision.gameObject);
            ScoreManager.instance.AddScore(1); // Add 1 Points (you can change this value)
        }
    }

}