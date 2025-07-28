using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    
    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 5;

    public float speedIncreasePerPoint = 0.1f;

    public float jumpForce = 400;
    private bool isGrounded;

    [SerializeField] LayerMask groundMask;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        if (anim != null)
        {
            anim.SetBool("isRunning", true); 
        }
    }

    private void FixedUpdate()
    {
        if (!alive) return;
        
        Vector3 fowardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position +  fowardMove + horizontalMove);
    }
    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        CheckGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (transform.position.y < -5)
        {
            Die();
        }
    }
    
    public void Die()
    {
        GameManager.inst.TakeDamage(); // Pierde vida si cae del mapa
        if (GameManager.inst.lives <= 0)
        {
            // GameManager manejará GameOver
            alive = false;
        }
    }
    
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    void Jump()
    {
        // Verificar si el jugador esta en el suelo
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        // Si el jugador esta en el suelo, que salte 
        rb.AddForce(Vector3.up * jumpForce);

        if (anim != null)
        {
            anim.SetTrigger("Jump"); 
        }
    }

    void CheckGrounded()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.2f, groundMask);
    }
}
