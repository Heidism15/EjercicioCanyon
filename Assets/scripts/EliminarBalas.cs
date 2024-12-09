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
        balas = GameObject.FindGameObjectsWithTag("Bala");

        foreach(GameObject bala in balas)
        {
            Destroy(bala);
        }
        
        GameManager.ResetearBalas();
    }
}
