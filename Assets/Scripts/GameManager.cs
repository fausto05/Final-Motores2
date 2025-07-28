using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;

    public int score;
    public int lives = 3; 
    public int targetCoins = 50;
    public int currentLevel = 1;

    [SerializeField] PlayerMovement playerMovement;

    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Text livesText; 
    public UnityEngine.UI.Text levelText;

    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        UpdateUI();
    }

    public void IncrementScore()
    {
        score++;
        UpdateUI();

        // Si alcanza el objetivo, pasa de nivel
        if (score >= targetCoins)
        {
            LevelComplete();
        }
        else
        {
            // Aumenta velocidad
            playerMovement.speed += playerMovement.speedIncreasePerPoint;
        }
    }

    public void TakeDamage()
    {
        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Monedas: " + score + "/" + targetCoins;
        livesText.text = "Vidas: " + lives;
        levelText.text = "Nivel: " + currentLevel;
    }

    void GameOver()
    {
        // Mostrar pantalla de derrota
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    void LevelComplete()
    {
        if (currentLevel == 1)
        {
            // Avanzar a Nivel 2
            currentLevel = 2;
            targetCoins = 100;
            score = 0; // Volver a 0 en el contador de monedas
            
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
        }
        else
        {
            // Pantalla de victoria
            UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
        }
    }
}
