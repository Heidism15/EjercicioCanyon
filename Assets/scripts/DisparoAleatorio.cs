using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoAleatorio : MonoBehaviour
{
    public string action;

    public GameObject posInicial;
    public GameObject posFinal;

    public GameObject prefabBala;
    GameObject balaInstanciada;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnMouseDown()
    {
        if(action == "DispararAleatorio")
        {
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

        GameManager.IncNumBalas();
    }
}
