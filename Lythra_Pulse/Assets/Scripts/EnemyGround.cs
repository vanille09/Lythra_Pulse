using UnityEngine;

public class EnemyGround : MonoBehaviour
{
    public float speed = 2f;
    public Transform groundCheck;
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;

    private bool movingRight = true;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * (movingRight ? 1 : -1));

        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);

        if (hit.collider == null)
        {
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
