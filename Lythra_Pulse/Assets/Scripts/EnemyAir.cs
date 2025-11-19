using UnityEngine;

public class EnemyAir : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;

    private float startX;
    private int direction = 1;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        if (transform.position.x > startX + distance)
            direction = -1;
        else if (transform.position.x < startX - distance)
            direction = 1;
    }
}
