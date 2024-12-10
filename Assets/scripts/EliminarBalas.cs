using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarBalas : MonoBehaviour
{
    GameObject[] balas; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        //Se encuentran todos los objetos con el tag "Bala" y se eliminan.
        balas = GameObject.FindGameObjectsWithTag("Bala");

        foreach(GameObject bala in balas)
        {
            Destroy(bala);
        }

        //Se llama al gamemanager para que resetee el numero de balas en el texto del canva.
        GameManager.ResetearBalas();
    }
}
