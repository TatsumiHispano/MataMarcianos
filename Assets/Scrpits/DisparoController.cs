using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoController : MonoBehaviour
{
       public float Speed;

    private float timeOut = 3.0f;

    // Variables para el disparo cargado
    private bool cargandoDisparo = false;
    private float tiempoCarga = 0f;
    private float tiempoMaxCarga = 2.0f; // Tiempo máximo para cargar el disparo

    // Parámetros de potencia
    private float potenciaMin = 10f;
    private float potenciaMax = 30f;
    private float potenciaActual;

    void Start()
    {
        Speed = 16.0f;
        potenciaActual = potenciaMin;
    }

    void Update()
    {
        // Movimiento del disparo (por ejemplo hacia la derecha)
        transform.Translate(Vector3.right * Time.deltaTime * Speed);

        // Destruir después del tiempo de vida
        timeOut -= Time.deltaTime;
        if (timeOut < 0)
        {
            Destroy(gameObject);
        }

        // Lógica de carga de disparo (debe estar en el script que controla la nave o disparo principal)
        // Aquí solo muestro cómo se podría hacer:

        if (Input.GetKey("space"))
        {
            // Comenzar o seguir cargando el disparo
            cargandoDisparo = true;
            tiempoCarga += Time.deltaTime;

            // Limitar carga máxima
            if (tiempoCarga > tiempoMaxCarga)
                tiempoCarga = tiempoMaxCarga;

            // Calcular potencia proporcional
            potenciaActual = Mathf.Lerp(potenciaMin, potenciaMax, tiempoCarga / tiempoMaxCarga);

            // Aquí podrías agregar efectos visuales que indiquen carga (opcional)
        }

        if (Input.GetKeyUp("space") && cargandoDisparo)
        {
            // Al soltar la tecla, disparar con la potencia calculada
            Debug.Log($"Disparo lanzado con potencia: {potenciaActual}");

            // Aquí lanzar el disparo usando la potenciaActual (velocidad, daño, tamaño, etc.)

            // Reiniciar variables
            cargandoDisparo = false;
            tiempoCarga = 0f;
            potenciaActual = potenciaMin;

            // Ejemplo: podrías instanciar el proyectil aquí con la potenciaActual
            // Instantiate(proyectilPrefab, posicionDisparo.position, Quaternion.identity);
            // y pasarle potenciaActual para modificar su comportamiento
        }
    }
}
