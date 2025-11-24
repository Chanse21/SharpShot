using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 3f;

    public GameObject player;



    void Update()

    {

        if (player == null) return;



        // move toward player

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

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

}