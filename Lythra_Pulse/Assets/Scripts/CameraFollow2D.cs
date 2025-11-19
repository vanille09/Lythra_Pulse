using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Target a seguir")]
    public Transform player;

    [Header("Límites en X (mundo)")]
    public float minX; // Límite izquierdo
    public float maxX; // Límite derecho

    [Header("Configuración")]
    public float smoothSpeed = 5f; // 0 = sin suavizado

    private float camHalfWidth;

    void Start()
    {
        // Calculamos el ancho visible de la cámara (útil para evitar que se vea fuera del nivel)
        Camera cam = Camera.main;
        camHalfWidth = cam.orthographicSize * cam.aspect;
    }

    void LateUpdate()
    {
        if (player == null)
            return;

        Vector3 pos = transform.position;

        // Objetivo X: seguimos al jugador
        float targetX = player.position.x;

        // Aplicamos los límites ajustados al tamaño de la cámara
        float minLimit = minX + camHalfWidth;
        float maxLimit = maxX - camHalfWidth;

        // Evita que la cámara vea fuera del nivel
        targetX = Mathf.Clamp(targetX, minLimit, maxLimit);

        // Movimiento suave o directo
        if (smoothSpeed > 0f)
            pos.x = Mathf.Lerp(pos.x, targetX, smoothSpeed * Time.deltaTime);
        else
            pos.x = targetX;

        transform.position = pos;
    }
}
