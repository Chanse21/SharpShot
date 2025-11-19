using UnityEngine;
using TMPro; // for TextMeshPro
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;



    [Header("UI References")]

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI enemyscoreText;

    public TextMeshProUGUI timerText;

    public TextMeshProUGUI gameOverText;



    [Header("Game Settings")]

    public int targetScore = 5;      // how many points needed to win

    public float timeLimit = 30f;     // seconds before failure

    private int score = 0;

    private int enemyscore = 0;

    private float timer;

    private bool gameEnded = false;

    void Awake()

    {

        if (instance == null)

            instance = this;

        else

            Destroy(gameObject);

    }

    void Start()

    {

        timer = timeLimit;

        UpdateScoreText();

        UpdateTimerText();

        gameOverText.gameObject.SetActive(false);

    }

    void Update()

    {

        if (gameEnded) return;

        timer -= Time.deltaTime;

        UpdateTimerText();

        if (timer <= 0)

        {
            timer = 0;

            GameOver(false);
        }

    }

    public void AddScore(int points)

    {

        if (gameEnded) return;

        score += points;

        UpdateScoreText();

        if (score >= targetScore)

        {

            GameOver(true);

        }

    }

    public void AddEnemyScore(int points)

        {

        if (gameEnded) return;



        enemyscore += points;

         UpdateEnemyScoreText();

        }

           // Update the enemy score UI

        void UpdateEnemyScoreText()

        {

         if (enemyscoreText != null)

             enemyscoreText.text = "Enemies: " + enemyscore;

        }

    void UpdateScoreText()

    {

        scoreText.text = "Score: " + score;

    }

    void UpdateTimerText()

    {

        timerText.text = "Time: " + Mathf.CeilToInt(timer);

    }

    void GameOver(bool won)

    {

        gameEnded = true;

        gameOverText.gameObject.SetActive(true);



        if (won)

            gameOverText.text = "You Win!";

        else

            gameOverText.text = "Wasted";

        // Wait 3 seconds, then load RestartScene
        Invoke("LoadRestartScene", 3f);

    }

    void LoadRestartScene()
    {
        SceneManager.LoadScene("Restart Game");
    }

}