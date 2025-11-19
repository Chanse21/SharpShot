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

                Destroy(gameObject);

            }

        }

    }



    private void OnCollisionEnter(Collision collision)

    {

        // 1. Check if it hit an enemy

        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemy != null)

        {

            enemy.TakeDamage(2f); // Apply damage



            // Check if enemy is dead now

            if (enemy.currentHealth <= 0)

            {

                ScoreManager.instance.AddScore(1); // Add points for defeating enemy

            }



            return; // Stop here so we don’t also check "Target"

        }



        // 2. Check if it hit a Target object

        if (collision.gameObject.CompareTag("Target"))

        {

            Destroy(collision.gameObject);

            ScoreManager.instance.AddScore(1); // Add points for target

        }

    }

}