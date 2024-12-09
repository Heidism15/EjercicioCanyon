using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    static public GameObject numBalasText;
    static int numBalas = 0;

    // Start is called before the first frame update
    void Start()
    {
        numBalasText = GameObject.Find("TextoBalas");

        if (numBalasText != null)
        {
            TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Balas: " + numBalas;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //int contadorBalas = GameObject.FindGameObjectsWithTag("Bala").Length;

        //contadorBalasTexto.text = "Balas: " + contadorBalas.ToString();
    }

    public static void ResetearBalas()
    {
        numBalas = 0;
        if (numBalasText != null)
        {
            TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Balas: " + numBalas;
        }
    }

    public static void IncNumBalas()
    {
        numBalas++;
        if (numBalasText != null)
        { 
            TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Balas: " + numBalas;
        }
    }

    public static void DecNumBalas()
    {
        numBalas--;
        if (numBalasText != null)
        { 
            TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Balas: " + numBalas;
        }
    }
}
