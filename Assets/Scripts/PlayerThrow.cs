using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public GameObject BoomerangPrefab; // Assign your boomerang prefab in the Inspector
    public Transform throwPoint; // Assign an empty GameObject as the throw point (e.g., in the player's hand)

    public Transform cameraTransform;

    public float spawnOffset = 1f;
    public bool hasBoomerangOut = false;

    public AudioClip boomerangThrowSound;

    private AudioSource audioSource;

    void Start()
    {
         audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Space button
        {
            ThrowBoomerang();
        }
    }

    void ThrowBoomerang()
    {
        //stop if boomerang is already out
        if (hasBoomerangOut)
            return;

        //mark that a boomerang is now active
        hasBoomerangOut = true;

        if (cameraTransform == null) return; // safety check

        // Spawn slightly in front of camera to avoid clipping

        Vector3 spawnPosition = cameraTransform.position + cameraTransform.forward * spawnOffset;

        Quaternion spawnRotation = Quaternion.LookRotation(cameraTransform.forward); // point in camera's direction

        if (audioSource && boomerangThrowSound)
            audioSource.PlayOneShot(boomerangThrowSound);

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
            //give boomerang a reference back to this thrower
            boomerangScript.thrower = this;
        }

    }

}