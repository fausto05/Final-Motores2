using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        
        // Verificar que el objeto con el que colisionamos sea el jugador 
        if (other.gameObject.name != "Player")
        {
            return;
        }

        // Sumar puntaje del jugador
        GameManager.inst.IncrementScore();

        // Destruir la moneda
        Destroy(gameObject);
    }
    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed *  Time.deltaTime);
    }
}
