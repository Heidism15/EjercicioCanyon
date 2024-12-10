using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class DisparoAleatorio : MonoBehaviour
{
    public string action;

    public GameObject posInicial;
    public GameObject posFinal;
    public GameObject canyon;

    public GameObject prefabBala;
    GameObject balaInstanciada;

    private int cerca = 5;

    //Cambiar el color del cañon
    public Renderer canyonRenderer;
    public Color colorOriginal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (balaInstanciada != null)
        {
            //Se mide la distancia entre la bala y el cañon, y si esta muy cerca se cambia de color del cañon
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
        if(action == "DispararAleatorio")
        {
            //Se instancia una bala con diferentes parametros random (fuerza, color y tamaño). 
            balaInstanciada = Instantiate(prefabBala, posInicial.transform.position, Quaternion.identity);

            float randomSize = Random.Range(0.5f, 2f);
            balaInstanciada.transform.localScale = Vector3.one * randomSize;

            float randomForce = Random.Range(5f, 20f);
            Rigidbody rb = balaInstanciada.GetComponent<Rigidbody>();
            Vector3 direccion = (posFinal.transform.position - posInicial.transform.position).normalized;
            rb.AddForce(direccion * randomForce , ForceMode.Impulse);

            Renderer renderer = balaInstanciada.GetComponent<Renderer>();
            Color[] coloresBasicos = { Color.red, Color.green, Color.blue, Color.yellow, Color.magenta };
            renderer.material.color = coloresBasicos[Random.Range(0, coloresBasicos.Length)];
        }
        //Se llama al gamemanager para que incremente el numero de balas en el texto del canva.
        GameManager.IncNumBalas();
    }
}
