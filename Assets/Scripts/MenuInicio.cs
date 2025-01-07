using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuInicio : MonoBehaviour
{
    public GameObject menuPrincipal;   // Contenedor del menú principal
    public GameObject textoCreditos;  // Contenedor del texto de créditos
    public GameObject botonAtras;     // Botón de regresar
    public static string dificultad = "Facil"; // Variable estática para la dificultad

    public TextMeshProUGUI textoDificultad;

    void Start()
    {
        // Mostrar solo el menú principal al inicio
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
        // Mostrar créditos y ocultar el menú principal
        menuPrincipal.SetActive(false);
        textoCreditos.SetActive(true);
        botonAtras.SetActive(true);
    }

    public void VolverAlMenu()
    {
        // Regresar al menú principal desde los créditos
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
