using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100f;

    private float currentHealth;



    public FloatingHealthBar healthBar;  // reference to your UI script



    void Start()

    {

        currentHealth = maxHealth;



        if (healthBar != null)

            healthBar.UpdateHealthBar(currentHealth, maxHealth);

    }



    public void TakeDamage(float amount)

    {

        currentHealth -= amount;

        if (currentHealth < 0) currentHealth = 0;



        // Update the floating health bar

        if (healthBar != null)

            healthBar.UpdateHealthBar(currentHealth, maxHealth);



        if (currentHealth <= 0)

        {

            Die();

        }

    }



    void Die()

    {

        Debug.Log("PLAYER DIED");

        // add respawn, game over, etc.

    }

}