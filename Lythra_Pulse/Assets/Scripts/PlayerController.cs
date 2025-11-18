using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float moveSpeed = 100f;      // tu valor
    public float jumpForce = 30f;       // tu valor

    [Header("Configuración de Suelo")]
    public Transform groundCheck;           
    public LayerMask groundLayer;           
    public float groundCheckRadius = 0.3f;  // AGRANDADO para que sí detecte piso

    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isGrounded;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (groundCheck == null)
            Debug.LogError("⚠ Debes asignar 'groundCheck' en el Inspector.");
    }

    void Update()
    {
        // *** DEBUG PARA VER SI FUNCIONA LA DETECCIÓN ***
        Debug.Log("Grounded: " + isGrounded);

        // Movimiento horizontal (A, D, flechas)
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        FlipSprite();
    }

    void FixedUpdate()
    {
        // Detección de suelo
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        // Movimiento
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    void FlipSprite()
    {
        if (horizontalInput < 0 && isFacingRight)
        {
            isFacingRight = false;
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x),
                                                transform.localScale.y,
                                                transform.localScale.z);
        }
        else if (horizontalInput > 0 && !isFacingRight)
        {
            isFacingRight = true;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),
                                               transform.localScale.y,
                                               transform.localScale.z);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
