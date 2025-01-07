using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Diana : MonoBehaviour
{
    //Limites para la posición aleatoria de las dianas
    public float limiteXMin = -10f; // Limite izquierdo
    public float limiteXMax = 10f;  // Limite derecho
    public float limiteYMin = 1f;   // Limite inferior
    public float limiteYMax = 5f;   // Limite superior
    public float posicionZFija = 20f; // Siempre en el mismo eje z

    public AudioSource aciertoAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            //Se destruyen las balas que colisionan con la diana, ademas se decrementa el numero de balas en el texto del canva.
            Destroy(collision.gameObject);
            GameManager.DecNumBalas();

            //Añade tiempo extra al acertar la diana.
            GameManager.AddExtraTime(3f);

            // Se incrementa el contador de dianas acertadas.
            GameManager.IncrementarDianasAcertadas();

            if (aciertoAudio != null)
            {
                aciertoAudio.Play();
            }

            //Se mueve la diana y se cuenta un punto.
            MoverDianaAleatoria();
            GameManager.IncDianas();          
        }
    }

    private void MoverDianaAleatoria()
    {
        // Genera una posición aleatoria dentro de los límites establecidos.
        float posX = Random.Range(limiteXMin, limiteXMax);
        float posY = Random.Range(limiteYMin, limiteYMax);

        // Actualiza la posición de la diana.
        transform.position = new Vector3(posX, posY, posicionZFija);
    }
}