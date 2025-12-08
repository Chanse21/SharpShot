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

    public int targetScore = 5;      // points needed to win

    public int enemyscoreGoal = 3;   // points for enemy to win

    public float timeLimit = 30f;



    [HideInInspector] public int score = 0;

    [HideInInspector] public int enemy = 0;



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

        UpdateEnemyScoreText();

        UpdateTimerText();

        if (gameOverText != null)

            gameOverText.gameObject.SetActive(false);

    }



    void Update()

    {

        if (gameEnded) return;



        timer -= Time.deltaTime;

        if (timer <= 0) { timer = 0; GameOver(false); }



        UpdateTimerText();

    }



    public void AddScore(int points)

    {

        if (gameEnded) return;

        score += points;

        Debug.Log("Player score: " + score);

        UpdateScoreText();



        if (score >= targetScore) GameOver(true);

    }



    public void AddEnemyScore(int points)

    {

        if (gameEnded) return;

        enemy += points;

        Debug.Log("Enemy score: " + enemy);

        UpdateEnemyScoreText();



        if (enemy >= enemyscoreGoal) GameOver(true);

    }



    void UpdateScoreText()

    {

        if (scoreText != null)

            scoreText.text = "Score: " + score;

    }



    void UpdateEnemyScoreText()

    {

        if (enemyscoreText != null)

            enemyscoreText.text = "Enemy: " + enemy;

    }



    void UpdateTimerText()

    {

        if (timerText != null)

            timerText.text = "Time: " + Mathf.CeilToInt(timer);

    }



    void GameOver(bool won)

    {

        gameEnded = true;

        if (gameOverText != null)

        {

            gameOverText.gameObject.SetActive(true);

            gameOverText.text = won ? "You Win!" : "Wasted";

        }



        Invoke("LoadRestartScene", 3f);

    }

    public void ForceGameOverOnPlayerDeath()
    {
        if (gameEnded) return;
        GameOver(false); //player loses
    }



    void LoadRestartScene()

    {

        SceneManager.LoadScene("Restart Game");

    }

}