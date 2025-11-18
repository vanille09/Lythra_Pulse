using UnityEngine;

public class GemCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        string gemType = gameObject.tag;
        int points = 0;

        if (gemType == "GemaMorada") points = 1;
        else if (gemType == "GemaRosa") points = 2;
        else if (gemType == "GemaDorada") points = 0;

        GameManager.instance.AddGem(gemType, points);

        Destroy(gameObject);
    }
}