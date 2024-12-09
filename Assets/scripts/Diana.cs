using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Diana : MonoBehaviour
{
    private int cañonazos = 0;
    private Renderer dianaRenderer;
    public Color colorImpacto;
    public float velocidadRotacion = 50f;
    private bool rotar = false;

    // Start is called before the first frame update
    void Start()
    {
        dianaRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (rotar)
        {
            transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            cañonazos++;

            Destroy(collision.gameObject);
            GameManager.ResetearBalas();

            if (cañonazos == 1)
            {
                //Se cambia el color de la diana
                dianaRenderer.material.color = colorImpacto;
            }
            else if (cañonazos == 2)
            {
                rotar = true;
            }
            else if (cañonazos == 3)
            {
                //Se destruye la diana
                Destroy(gameObject);
            }
        }
                
    }
}