using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    }

    // Update is called once per frame
    void Update()
    {
        if(textoPotencia != null)
        {
            textoPotencia.text = "Potencia: " + Mathf.Round(DispararBalas.potenciaDisparo);
        }
    }

    public static void ResetearBalas()
    {
        //Se resetea el texto del canva
        numBalas = 0;
        if (numBalasText != null)
        {
            TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Balas: " + numBalas;
        }
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
}
