using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // necesario para usar Slider e Image

public class AvionController : MonoBehaviour
{
    [Header("Movimiento")]
    public float Speed = 4.0f;

    [Header("Disparo")]
    public GameObject posicion;
    public GameObject disparoNormal;
    public GameObject disparoCargado;
    public GameObject particulasDisparoCargadoPrefab;

    [Header("Referencias")]
    public Transform camara;
    public Slider barraCarga; // referencia a la barra de carga

    [Header("Márgenes")]
    public float margenIzquierdo = 0.02f;
    public float margenDerecho = 0.02f;
    public float margenSuperior = 0.01f;
    public float margenInferior = 0.01f;

    [Header("Tiempos de carga")]
    public float tiempoMinCarga = 0.5f;
    public float tiempoMaxCarga = 2.0f;

    private bool cargandoDisparo = false;
    private float tiempoCarga = 0f;
    private GameObject particulasInstanciadas = null;

    void Update()
    {
        // --- Movimiento con límites ---
        Camera cam = Camera.main;
        float camAltura = cam.orthographicSize;
        float camAncho = camAltura * cam.aspect;

        float limiteIzquierdo = camara.position.x - camAncho + margenIzquierdo;
        float limiteDerecho = camara.position.x + camAncho - margenDerecho;
        float limiteSuperior = camara.position.y + camAltura - margenSuperior;
        float limiteInferior = camara.position.y - camAltura + margenInferior;

        Vector3 movimiento = Vector3.zero;

        if (Input.GetKey("right") && transform.position.x < limiteDerecho)
            movimiento += Vector3.right;

        if (Input.GetKey("left") && transform.position.x > limiteIzquierdo)
            movimiento += Vector3.left;

        if (Input.GetKey("up") && transform.position.y < limiteSuperior)
            movimiento += Vector3.up;

        if (Input.GetKey("down") && transform.position.y > limiteInferior)
            movimiento += Vector3.down;

        transform.Translate(movimiento.normalized * Speed * Time.deltaTime);

        // --- Lógica de disparo cargado ---
        if (Input.GetKey("space"))
        {
            if (!cargandoDisparo)
            {
                cargandoDisparo = true;
                tiempoCarga = 0f;

                // Instanciar partículas solo una vez
                if (particulasDisparoCargadoPrefab != null && particulasInstanciadas == null)
                {
                    particulasInstanciadas = Instantiate(particulasDisparoCargadoPrefab, posicion.transform.position, posicion.transform.rotation);
                }
            }

            // Aumentar carga
            tiempoCarga += Time.deltaTime;
            if (tiempoCarga > tiempoMaxCarga)
                tiempoCarga = tiempoMaxCarga;

            // Actualizar posición de las partículas
            if (particulasInstanciadas != null)
                particulasInstanciadas.transform.position = posicion.transform.position;

            // --- Actualizar barra de carga ---
            if (barraCarga != null)
            {
                float carga = tiempoCarga / tiempoMaxCarga;
                barraCarga.value = carga;

                Image fillImage = barraCarga.fillRect.GetComponent<Image>();

                if (carga >= 1f)
                {
                    //Cuando está completamente cargada → azul neón
                    fillImage.color = new Color(0.0f, 0.8f, 1.0f); // azul neón (RGB)
                }
                else
                {
                    // De verde → rojo mientras carga
                    fillImage.color = Color.Lerp(Color.green, Color.red, carga);
                }
            }
        }

        // --- Cuando suelta el espacio ---
        if (Input.GetKeyUp("space") && cargandoDisparo)
        {
            if (tiempoCarga < tiempoMinCarga)
            {
                // Disparo normal
                Instantiate(disparoNormal, posicion.transform.position, posicion.transform.rotation);
                Debug.Log("Disparo normal");
            }
            else
            {
                // Disparo cargado
                Instantiate(disparoCargado, posicion.transform.position, posicion.transform.rotation);
                Debug.Log($"Disparo cargado (tiempo de carga: {tiempoCarga:F2}s)");
            }

            // Destruir partículas
            if (particulasInstanciadas != null)
            {
                Destroy(particulasInstanciadas);
                particulasInstanciadas = null;
            }

            // Reiniciar barra
            if (barraCarga != null)
            {
                barraCarga.value = 0f;
                Image fillImage = barraCarga.fillRect.GetComponent<Image>();
                fillImage.color = Color.green;
            }

            cargandoDisparo = false;
            tiempoCarga = 0f;
        }
    }
}
