using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager inst;

    [SerializeField] PlayerMovement playerMovement;

    public Text scoreText;
    public void IncrementScore()
    {
        score++;
        scoreText.text = "PUNTOS: " + score;
        
        // Aumentar la velocidad del jugador  
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }
    private void Awake()
    {
        inst = this;
    }
}
