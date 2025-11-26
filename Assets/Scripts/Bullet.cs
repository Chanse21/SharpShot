using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;

    public float damage = 10f;   // how much damage this bullet deals

    public float lifetime = 5f;



    void Start()

    {

        Destroy(gameObject, lifetime);

    }



    void Update()

    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }



    private void OnTriggerEnter(Collider other)

    {

        if (other.CompareTag("Player"))

        {

            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();



            if (playerHealth != null)

            {

                playerHealth.TakeDamage(damage);

            }



            Destroy(gameObject);

        }

        else if (!other.CompareTag("Enemy")) // prevent bullets from deleting when touching enemy itself

        {

            Destroy(gameObject); 

        }

    }

}