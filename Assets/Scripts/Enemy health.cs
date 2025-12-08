using UnityEngine;
using UnityEngine.UI; // Required for UI elements like Slider

public class EnemyHealth : MonoBehaviour
{

    [Header("Health Settings")]

    public float maxHealth = 10f;

    [HideInInspector] public float currentHealth;



    [Header("UI")]

    public GameObject healthBarUI; // Canvas for health bar

    public Slider healthSlider;



    [Header("UI Smoothing")]

    public float smoothSpeed = 5f;



    private float displayedHealth;

    private bool isDead = false;



    void Start()

    {

        currentHealth = maxHealth;



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

        if (healthSlider != null)

        {

            displayedHealth = Mathf.Lerp(displayedHealth, currentHealth, Time.deltaTime * smoothSpeed);

            healthSlider.value = displayedHealth;

        }

    }



    public void TakeDamage(float damage)

    {
        if (isDead) return; // prevent duplicate death calls
        currentHealth -= damage;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);



        Debug.Log(gameObject.name + " TakeDamage called. CurrentHealth: " + currentHealth);



        if (currentHealth <= 0)

            HandleDeath();

    }



    private void HandleDeath()

    {
        if (isDead) return; // make 100% sure
        isDead = true;

        Debug.Log(gameObject.name + " died → adding enemy score");

        if (healthBarUI != null)

            healthBarUI.SetActive(false);


        print("Test");
        ScoreManager.instance.AddEnemyScore(1);



        Destroy(gameObject);

    }

}