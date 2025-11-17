using UnityEngine;
using UnityEngine.UI; // Required for UI elements like Slider

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth;
    public GameObject healthBarUI; // Reference to the Canvas holding the health bar
    public Slider healthSlider; // Reference to the Slider component

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        //healthBarUI.SetActive(false); // Hide health bar initially
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays within bounds

        UpdateHealthBar();
        healthBarUI.SetActive(true); // Show health bar when damaged

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        // Implement enemy death logic here (e.g., play animation, destroy GameObject)
        Destroy(gameObject);
    }
}