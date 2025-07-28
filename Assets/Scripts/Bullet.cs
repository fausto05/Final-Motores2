using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.inst.TakeDamage();  
            Destroy(gameObject);

            return;
        }

        if (other.CompareTag("Coin"))
        {
            return;
        }

        // Si toca cualquier otra cosa, solo se destruye la bala (no el otro objeto)
        Destroy(gameObject);
    }
}
