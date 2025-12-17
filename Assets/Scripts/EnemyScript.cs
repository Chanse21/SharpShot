using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{

    public float speed = 3f;

    public GameObject player;



    [Header("Shooting")]

    public GameObject bulletPrefab;     // Your bullet prefab

    public Transform shootPoint;        // Your empty spawn point

    public float fireRate = 1.5f;       // Seconds between shots

    private float nextFireTime = 0f;    // Timer for when enemy can shoot again

    public AudioClip shootSound;

    private AudioSource audioSource;


    void Start()
    {
         audioSource = GetComponent<AudioSource>();
    }



    void Update()

    {

        if (player == null) return;



        // Move toward player

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);



        // Aim at player (optional)

        transform.LookAt(player.transform);



        // Shoot at player

        HandleShooting();

    }



    void HandleShooting()

    {

        if (Time.time >= nextFireTime)

        {

            Shoot();

            nextFireTime = Time.time + fireRate;

        }

    }



    void Shoot()

    {

        if (bulletPrefab != null && shootPoint != null)

        {
            if (audioSource && shootSound)
            audioSource.PlayOneShot(shootSound);

            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        }

    }

}

   // private void OnCollisionEnter(Collision collision)

   // {

      //  if (collision.gameObject.CompareTag("Boomerang"))
      
       // {
           // EnemyHealth health = GetComponent<EnemyHealth>();
         // if (health != null)
           // {
           //     health.TakeDamage(2);
          //  }

       // }

    //}