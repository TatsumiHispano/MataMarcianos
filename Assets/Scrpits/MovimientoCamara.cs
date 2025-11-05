using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    
    public GameObject jugador;

    [SerializeField] private float velocidadCamara = 0.5f;

    [Header("Márgenes de cámara")]
    [SerializeField] private float margenIzquierdo = 0.2f;
    [SerializeField] private float margenDerecho = 0.2f;
    [SerializeField] private float margenSuperior = 0.1f;
    [SerializeField] private float margenInferior = 0.0f;

    [SerializeField] private float suavizado = 1f; // control de interpolación

    void FixedUpdate()
    {
        // Avanzar la cámara hacia la derecha
        transform.position += new Vector3(velocidadCamara * Time.fixedDeltaTime, 0, 0);

        // Calcular límites de la cámara
        Camera cam = Camera.main;
        float camAltura = cam.orthographicSize;
        float camAncho = camAltura * cam.aspect;

        float limiteIzquierdo = transform.position.x - camAncho + margenIzquierdo;
        float limiteDerecho = transform.position.x + camAncho - margenDerecho;
        float limiteSuperior = transform.position.y + camAltura - margenSuperior;
        float limiteInferior = transform.position.y - camAltura + margenInferior;

        // Obtener posición actual del jugador
        Vector3 jugadorPos = jugador.transform.position;
        Vector3 jugadorPosCorregida = jugadorPos;

        // Limitar jugador en X (márgenes izquierdo y derecho)
        if (jugadorPos.x < limiteIzquierdo)
        {
            jugadorPosCorregida.x = limiteIzquierdo;
        }
        else if (jugadorPos.x > limiteDerecho)
        {
            jugadorPosCorregida.x = limiteDerecho;
        }

        // Limitar jugador en Y (márgenes superior/inferior)
        if (jugadorPos.y > limiteSuperior)
        {
            jugadorPosCorregida.y = limiteSuperior;
        }
        else if (jugadorPos.y < limiteInferior)
        {
            jugadorPosCorregida.y = limiteInferior;
        }

        // Mover suavemente hacia la posición corregida
        jugador.transform.position = Vector3.Lerp(jugador.transform.position, jugadorPosCorregida, suavizado);
    }
}

