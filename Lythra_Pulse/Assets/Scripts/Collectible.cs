using UnityEngine;

public class Collectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        string t = gameObject.tag;

        if (t == "GemaMorada")
        {
            GameManager.instance.AddGem("GemaMorada", 1);
            Destroy(gameObject);
        }
        else if (t == "GemaRosa")
        {
            GameManager.instance.AddGem("GemaRosa", 2);
            Destroy(gameObject);
        }
        else if (t == "GemaDorada")
        {
            GameManager.instance.AddGem("GemaDorada", 0);
            Destroy(gameObject);
        }
        else if (t == "Río")
        {
            GameManager.instance.GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (gameObject.tag == "Enemy" && c.collider.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
}
