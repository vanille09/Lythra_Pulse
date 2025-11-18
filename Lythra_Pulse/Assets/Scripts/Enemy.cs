using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
}