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



        // Automatically find player in scene

        if (playerTransform == null)

        {

            GameObject playerObj = GameObject.FindWithTag("Player");

            if (playerObj != null)

                playerTransform = playerObj.transform;

        }

    }



    void Update()

    {

        if (!returning)

        {

            if (Vector3.Distance(initialPosition, transform.position) >= maxDistance)

                returning = true;

        }

        else

        {

            if (playerTransform != null)

            {

                Vector3 dir = (playerTransform.position - transform.position).normalized;

                rb.linearVelocity = dir * returnSpeed;



                if (Vector3.Distance(playerTransform.position, transform.position) < 1f)

                    Destroy(gameObject);

            }

        }

    }



    private void OnCollisionEnter(Collision collision)

    {
        Debug.Log("Boomerang hit: " + collision.gameObject.name);

        // Damage enemy only

        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemy != null)

        {
            Debug.Log("EnemyHealth found: " + enemy.gameObject.name);
            enemy.TakeDamage(.5f);
            Debug.Log("After TakeDamage, enemy currentHealth: " + enemy.currentHealth);
            return;

        }



        // Score targets

        if (collision.gameObject.CompareTag("Target"))

        {

            Destroy(collision.gameObject);

            ScoreManager.instance.AddScore(1);

        }

    }

}