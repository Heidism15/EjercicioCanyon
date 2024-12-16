using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararBalas : MonoBehaviour
{
    public GameObject posInicial;
    public GameObject posFinal;
    public GameObject canyon;
    Rigidbody rb;

    public GameObject prefabBala;
    GameObject balaInstanciada;

    // Distancia y fuerza
    private int cerca = 5;

    // Cambiar el color del cañón
    public Renderer canyonRenderer;
    public Color colorOriginal;

    // Potencia de disparo (controlada en este script)
    public static float potenciaDisparo = 0f;  // Static para que GameManager lo pueda acceder

    private bool isMouseDown = false;

    // Start is called before the first frame update
    void Start()
    {
        colorOriginal = canyonRenderer.material.color;
    }

    void Update()
    {
        if (balaInstanciada != null)
        {
            // Se mide la distancia entre la bala y el cañón, y si está muy cerca, cambiamos el color del cañón
            float distancia = Vector3.Distance(balaInstanciada.transform.position, canyon.transform.position);

            if (distancia <= cerca)
            {
                canyonRenderer.material.color = Color.red;
            }
            else
            {
                canyonRenderer.material.color = colorOriginal;
            }
        }

        // Si el mouse está presionado, aumentamos la potencia
        if (isMouseDown)
        {
            // Aumentamos la potencia gradualmente hasta un valor máximo
            potenciaDisparo += Time.deltaTime * 10f; // Se incrementa la potencia con el tiempo
            if (potenciaDisparo > 30f) potenciaDisparo = 30f;  // Limitar potencia
        }
    }

    private void OnMouseDown()
    {
        // Iniciar el disparo si el mouse está presionado
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        // Al soltar el mouse, disparar la bala con la potencia actual
        isMouseDown = false;

        // Se instancia una bala y se hace que siga una trayectoria predeterminada. 
        balaInstanciada = Instantiate(prefabBala, posInicial.transform.position, Quaternion.identity);
        Rigidbody rb = balaInstanciada.GetComponent<Rigidbody>();

        Vector3 direccion = (posFinal.transform.position - posInicial.transform.position).normalized;
        rb.AddForce(direccion * potenciaDisparo, ForceMode.Impulse); // Usamos la potencia de disparo para el impulso

        // Se llama al GameManager para que incremente el número de balas en el texto del canvas
        GameManager.IncNumBalas();

        // Reiniciamos la potencia
        potenciaDisparo = 0f;  // Resetear la potencia

        // Actualizamos el texto en GameManager
        if (GameManager.textoPotencia != null)
        {
            GameManager.textoPotencia.text = "Potencia: " + potenciaDisparo;
        }
    }
}
