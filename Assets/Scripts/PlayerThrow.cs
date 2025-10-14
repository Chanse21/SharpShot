using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public GameObject BoomerangPrefab; // Assign your boomerang prefab in the Inspector
    public Transform throwPoint; // Assign an empty GameObject as the throw point (e.g., in the player's hand)

    public Transform cameraTransform;

    public float spawnOffset = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Space button
        {
            ThrowBoomerang();
        }
    }

    void ThrowBoomerang()
    {

        if (cameraTransform == null) return; // safety check

        // Spawn slightly in front of camera to avoid clipping

        Vector3 spawnPosition = cameraTransform.position + cameraTransform.forward * spawnOffset;

        Quaternion spawnRotation = Quaternion.LookRotation(cameraTransform.forward); // point in camera's direction

        GameObject newBoomerang = Instantiate(BoomerangPrefab, spawnPosition, spawnRotation);

        // Ignore collision with player

        Collider boomerangCollider = newBoomerang.GetComponent<Collider>();

        Collider playerCollider = GetComponent<Collider>();

        if (boomerangCollider != null && playerCollider != null)

        {

            Physics.IgnoreCollision(boomerangCollider, playerCollider);

        }



        // Pass player reference to the boomerang

        Boomerang boomerangScript = newBoomerang.GetComponent<Boomerang>();

        if (boomerangScript != null)

        {

            boomerangScript.playerTransform = transform;

        }

    }

}