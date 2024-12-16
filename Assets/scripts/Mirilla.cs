using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirilla : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad de la cruceta
    public Vector2 limitesX = new Vector2(-5f, 5f); // Limites en el eje X
    public Vector2 limitesY = new Vector2(-5f, 5f); // Limites en el eje Y
    public Transform cañon;

    void Start()
    {
        // Poner la cruceta delante del cañón 
        Vector3 posicionInicial = cañon.position + cañon.forward * 10f; 
        transform.position = new Vector3(
            Mathf.Clamp(posicionInicial.x, limitesX.x, limitesX.y),
            Mathf.Clamp(posicionInicial.y, limitesY.x, limitesY.y),
            posicionInicial.z
        );
    }

    void Update()
    {
        // Movimiento con las teclas
        float movimientoHorizontal = Input.GetAxis("Horizontal"); 
        float movimientoVertical = Input.GetAxis("Vertical");     

        Vector3 movimiento = new Vector3(movimientoHorizontal, movimientoVertical, 0) * velocidadMovimiento * Time.deltaTime;
        transform.position += movimiento;

        // límites de movimiento
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, limitesX.x, limitesX.y),
            Mathf.Clamp(transform.position.y, limitesY.x, limitesY.y),
            transform.position.z //no mover en z
        );
    }
}
