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

    //Distancia y fuerza
    public float fuerza = 10f;
    private int cerca = 5;

    //Cambiar el color del ca�on
    public Renderer canyonRenderer;
    public Color colorOriginal;

    // Start is called before the first frame update
    void Start()
    {
        //canyonRenderer = canyon.GetComponent<Renderer>();
        colorOriginal = canyonRenderer.material.color;
    }
    void Update()
    {
        if (balaInstanciada != null)
        {
            //Se mide la distancia entre la bala y el ca�on, y si esta muy cerca se cambia de color del ca�on 
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
    }

    private void OnMouseDown()
    {
        //Se instancia una bala y se hace que siga una trayectoria predeterminada. 
        balaInstanciada = Instantiate(prefabBala, posInicial.transform.position, Quaternion.identity);

        Rigidbody rb = balaInstanciada.GetComponent<Rigidbody>();

        Vector3 direccion = (posFinal.transform.position - posInicial.transform.position).normalized;

        rb.AddForce(direccion * fuerza, ForceMode.Impulse);

        //Se llama al gamemanager para que incremente el numero de balas en el texto del canva.
        GameManager.IncNumBalas();
    }
}
