using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuInicio : MonoBehaviour
{
    public GameObject menuPrincipal;   // Contenedor del men� principal
    public GameObject textoCreditos;  // Contenedor del texto de cr�ditos
    public GameObject botonAtras;     // Bot�n de regresar
    public static string dificultad = "Facil"; // Variable est�tica para la dificultad

    public TextMeshProUGUI textoDificultad;

    void Start()
    {
        // Mostrar solo el men� principal al inicio
        menuPrincipal.SetActive(true);
        textoCreditos.SetActive(false);
        botonAtras.SetActive(false);
    }

    public void IniciarJuego()
    {
        // Cargar la escena principal
        SceneManager.LoadScene("Juego");
    }

    public void MostrarCreditos()
    {
        // Mostrar cr�ditos y ocultar el men� principal
        menuPrincipal.SetActive(false);
        textoCreditos.SetActive(true);
        botonAtras.SetActive(true);
    }

    public void VolverAlMenu()
    {
        // Regresar al men� principal desde los cr�ditos
        menuPrincipal.SetActive(true);
        textoCreditos.SetActive(false);
        botonAtras.SetActive(false);
    }

    public void SeleccionarDificultad(string nivel)
    {
        // Asignar la dificultad seleccionada
        dificultad = nivel;

        if(textoDificultad != null)
        {
            textoDificultad.text = "Dificultad: " + dificultad;
        }
    }
}
