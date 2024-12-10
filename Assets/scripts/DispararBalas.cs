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

    //Cambiar el color del cañon
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
        balaInstanciada = Instantiate(prefabBala, posInicial.transform.position, Quaternion.identity);

        Rigidbody rb = balaInstanciada.GetComponent<Rigidbody>();

        Vector3 direccion = (posFinal.transform.position - posInicial.transform.position).normalized;

        rb.AddForce(direccion * fuerza, ForceMode.Impulse);

        GameManager.IncNumBalas();
    }
}
