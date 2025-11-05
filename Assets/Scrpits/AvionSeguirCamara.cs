using UnityEngine;

public class AvionSeguirCamara : MonoBehaviour
{
    [Header("Velocidad automática")]
    [Tooltip("Velocidad constante hacia adelante (eje X)")]
    public float velocidadAvance = 0.5f;
    
    void FixedUpdate()
    {
        // Movimiento automático hacia la derecha
        Vector3 movimiento = Vector3.right * velocidadAvance * Time.deltaTime;
        transform.Translate(movimiento);
    }
}
