using UnityEngine;
using UnityEngine.UI; // Required for UI elements like Slider

public class EnemyHealth : MonoBehaviour
{

    public float maxHealth = 10f;

    public float currentHealth;



    [Header("UI")]

    public GameObject healthBarUI; // Canvas object

    public Slider healthSlider; // Slider component



    [Header("UI Smoothness")]

    public float smoothSpeed = 5f; // Higher = faster bar update



    private float displayedHealth; // The health shown on the slider



    void Start()

    {

        currentHealth = maxHealth;



        // Auto-find slider if not assigned

        if (healthSlider == null && healthBarUI != null)

            healthSlider = healthBarUI.GetComponentInChildren<Slider>();



        if (healthSlider != null)

        {

            healthSlider.maxValue = maxHealth;

            healthSlider.value = maxHealth;

        }



        displayedHealth = currentHealth;

    }



    void Update()

    {

        // Smoothly interpolate displayedHealth to currentHealth

        if (healthSlider != null)

        {

            displayedHealth = Mathf.Lerp(displayedHealth, currentHealth, Time.deltaTime * smoothSpeed);

            healthSlider.value = displayedHealth;

        }

    }



    public void TakeDamage(float damage)

    {

        currentHealth -= damage;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);



        if (currentHealth <= 0)

        {

            if (healthBarUI != null) healthBarUI.SetActive(false);
            ScoreManager.instance.AddEnemyScore(1);

            Destroy(gameObject);

        }

    }

}