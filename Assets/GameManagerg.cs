using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score;
    public int lives = 3;

    public Text scoreText;
    public GameObject gameOverPanel;

    private int comboCounter = 0;
    private float comboTimer = 0f;
    private float comboTimeLimit = 0.5f;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (comboCounter > 0)
        {
            comboTimer += Time.deltaTime;
            if (comboTimer > comboTimeLimit)
            {
                comboCounter = 0;
                comboTimer = 0f;
            }
        }
    }

    public void AddScore()
    {
        comboCounter++;
        comboTimer = 0f;

        int multiplier = comboCounter >= 3 ? comboCounter : 1;
        int addedScore = 10 * multiplier;

        score += addedScore;
        scoreText.text = "Score: " + score;
    }

    public void HitBomb()
    {
        lives--;
        if (lives <= 0)
        {
            EndGame();
        }
        else
        {
            FruitSpawner.Instance.DelaySpawnForSeconds(2f);
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
}
