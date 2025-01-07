using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispararBalas : MonoBehaviour
{
    public GameObject prefabBala;
    public GameObject posInicial;
    public GameObject posFinal;
    public GameObject canyon;
    public AudioSource disparoAudio;
    GameObject balaInstanciada;

    // Distancia y fuerza
    private int cerca = 5;

    // Cambiar el color del cañón
    public Renderer canyonRenderer;
    public Color colorOriginal;

    // Potencia de disparo
    public static float potenciaDisparo = 0f; // Static para que GameManager pueda acceder
    private bool incrementarPotencia = false;

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
        if (incrementarPotencia)
        {
            potenciaDisparo += Time.deltaTime * 10f; // Incrementar potencia
            if (potenciaDisparo > 30f) potenciaDisparo = 30f; // Limitar la potencia
        }
    }
    public void IncPotencia()
    {
        // Comienza a aumentar la potencia al presionar el botón
        incrementarPotencia = true;
    }

    public void Disparar()
    {
        // Deja de aumentar la potencia y dispara la bala
        incrementarPotencia = false;

        // Instanciar la bala
        balaInstanciada = Instantiate(prefabBala, posInicial.transform.position, Quaternion.identity);
        Rigidbody rb = balaInstanciada.GetComponent<Rigidbody>();

        Vector3 direccion = (posFinal.transform.position - posInicial.transform.position).normalized;
        rb.AddForce(direccion * potenciaDisparo, ForceMode.Impulse); // Aplicar fuerza

        if (disparoAudio != null)
        {
            disparoAudio.Play();
        }

        // decirle al GameManager que se ha disparado una bala
        GameManager.IncNumBalas();

        //Reiniciar la potencia
        potenciaDisparo = 0f;

        // Actualizamos el texto en GameManager
        if (GameManager.textoPotencia != null)
        {
            GameManager.textoPotencia.text = " " + potenciaDisparo;
        }
    }
}
