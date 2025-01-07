using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //Texto balas
    static public GameObject numBalasText;
    static int numBalas = 0;

    //Texto diana
    static public GameObject numDianaText;
    static int numDiana = 0;

    // Texto de la potencia
    static public TextMeshProUGUI textoPotencia;

    // Texto de la cuenta atras
    static public TextMeshProUGUI textoTiempo;

    // Tiempo de la cuenta atras (20 segundos)
    static private float tiempoRestante = 20f;

    // UI del menu de fin de juego
    public GameObject finJuegoMenu;
    public GameObject finJuegoVictoria;
    public GameObject finJuegoDerrota;
    public TextMeshProUGUI textoFinalDianas;
    public TextMeshProUGUI textoFinalBalas;
    public TextMeshProUGUI textoFinalPrecision;
    public TextMeshProUGUI textoVictoria;
    public TextMeshProUGUI textoDerrota;

    // Referencias para los objetos que quieres desactivar
    public GameObject diana;  
    public GameObject boton;  
    public GameObject mirilla;  

    // Variables para el cálculo de precisión
    static int dianasAcertadas = 0;

    //Referencia para las animaciones
    public Animator animFinPartida;

    public AudioSource musicaVictoria;
    public AudioSource musicaDerrota;

    // Start is called before the first frame update
    void Start()
    {
        //Se cambia el texto del canva de las balas
        numBalasText = GameObject.Find("TextoBalas");

        if (numBalasText != null)
        {
            TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Balas: " + numBalas;
        }

        //Se cambia el texto del canva de las dianas
        numDianaText = GameObject.Find("TextoDiana");

        if (numDianaText != null)
        {
            TextMeshProUGUI textoTMP2 = numDianaText.GetComponent<TextMeshProUGUI>();
            textoTMP2.text = "Dianas: " + numDiana;
        }

        //Se cambia el texto de la potencia
        textoPotencia = GameObject.Find("TextoPotencia").GetComponent<TextMeshProUGUI>();

        //Se cambia el texto del tiempo
        textoTiempo = GameObject.Find("TextoTiempo").GetComponent<TextMeshProUGUI>();

        // Buscar y ocultar el menu de fin de juego y el texto al principio
        finJuegoMenu.SetActive(false);
        finJuegoVictoria.SetActive(false);
        finJuegoDerrota.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Reducimos el tiempo restante
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime; // Se disminuye el tiempo

            // Actualizamos el texto de la cuenta atrás
            if (textoTiempo != null)
            {
                textoTiempo.text = "Tiempo: " + Mathf.Round(tiempoRestante).ToString() + "s";
            }
        }
        else
        {
            // Si el tiempo se ha agotado, mostrar el menú de fin de juego
            if (!finJuegoMenu.activeSelf)
            {
                MostrarFinJuego();
            }
        }


        if (textoPotencia != null)
        {
            textoPotencia.text = " " + Mathf.Round(DispararBalas.potenciaDisparo);
        }
    }

    // Método para agregar tiempo extra a la cuenta atrás
    public static void AddExtraTime(float tiempoExtra)
    {
        tiempoRestante += tiempoExtra;
    }
        
    public static void IncNumBalas()
    {
        //Se incrementa el numero del texto del canva
        numBalas++;
        if (numBalasText != null)
        { 
            TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Balas: " + numBalas;
        }
    }

    public static void DecNumBalas()
    {
        //Se decrementa el numero del texto del canva
        numBalas--;
        if (numBalasText != null)
        { 
            TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Balas: " + numBalas;
        }
    }

    public static void IncDianas()
    {
        //Se incrementa el numero del texto del canva de las dianas
        numDiana++;

        if (numDianaText != null)
        {
            TextMeshProUGUI textoTMP2 = numDianaText.GetComponent<TextMeshProUGUI>();
            textoTMP2.text = "Dianas: " + numDiana;
        }
    }

    public static void IncrementarDianasAcertadas()
    {
        // Aumenta el contador de dianas acertadas
        dianasAcertadas++;
    }

    // cuando el tiempo se agota se muestra el menú de fin de juego
    private void MostrarFinJuego()
    {
        // Calcular el porcentaje de precisión
        float porcentajePrecision = 0f;
        if (numBalas > 0)
        {
            porcentajePrecision = (float)dianasAcertadas / numBalas * 100f;
        }

        // Mostrar las estadísticas en el menú de fin de juego
        textoFinalDianas.text = "Dianas Acertadas: " + dianasAcertadas;
        textoFinalBalas.text = "Balas Disparadas: " + numBalas;
        textoFinalPrecision.text = "Precisión: " + Mathf.Round(porcentajePrecision) + "%";

        //Se muestran las animaciones dependiendo de si has conseguido buena puntuacion o no
        bool victoria = dianasAcertadas > 3 && porcentajePrecision > 50f;
        if (victoria)
        {
            finJuegoVictoria.SetActive(true);    
            textoVictoria.text = "!Victoria!";
            animFinPartida.SetTrigger("Ganar");

            if(musicaVictoria != null)
            {
                musicaVictoria.Play();
            }
        }
        else
        {
            finJuegoDerrota.SetActive(true); 
            textoDerrota.text = "Derrota :(";
            animFinPartida.SetTrigger("Perder");

            if (musicaDerrota != null)
            {
                musicaDerrota.Play();
            }
        }

        // Mostrar el menú de fin de juego
        finJuegoMenu.SetActive(true);

        // Desactivar los objetos del juego (dianas, botones, mirilla)
        if (diana != null) diana.SetActive(false);
        if (boton != null) boton.SetActive(false);
        if (mirilla != null) mirilla.SetActive(false);
    }

    public void ReiniciarPartida()
    {
        // Resetear el tiempo
        tiempoRestante = 20f;

        // Resetear las dianas, balas y otros elementos
        numBalas = 0;
        numDiana = 0;
        dianasAcertadas = 0;

        // Resetear texto
        textoTiempo.text = "Tiempo: " + Mathf.Round(tiempoRestante).ToString() + "s";
        TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
        textoTMP1.text = "Balas: " + numBalas;
        TextMeshProUGUI textoTMP2 = numDianaText.GetComponent<TextMeshProUGUI>();
        textoTMP2.text = "Dianas: " + numDiana;

        // Recargar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VolverAlMenu()
    {
        // Cargar la escena del menú principal
        SceneManager.LoadScene("MenuPrincipal");  // Asegúrate de que el nombre de tu escena principal sea correcto
    }
}
