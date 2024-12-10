using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Diana : MonoBehaviour
{
    //Numero de cañonazos dados a la diana.
    private int cañonazos = 0;

    //Color de la diana.
    private Renderer dianaRenderer;
    public Color colorImpacto;

    //Rotacion de la diana.
    public float velocidadRotacion = 50f;
    private bool rotar = false;

    // Start is called before the first frame update
    void Start()
    {
        //Se consigue el color de la diana.
        dianaRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (rotar)
        {
            //Se rota la diana en el eje y.
            transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            cañonazos++;

            //Se destruyen las balas que colisionan con la diana, ademas se decrementa el numero de balas en el texto del canva.
            Destroy(collision.gameObject);
            GameManager.DecNumBalas();

            if (cañonazos == 1)
            {
                //Se cambia el color de la diana.
                dianaRenderer.material.color = colorImpacto;
            }
            else if (cañonazos == 2)
            {
                //Se hace que la diana rote.
                rotar = true;
            }
            else if (cañonazos == 3)
            {
                //Se destruye la diana.
                Destroy(gameObject);
            }
        }
                
    }
}