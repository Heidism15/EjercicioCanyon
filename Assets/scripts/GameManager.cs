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
        //Se cambia el texto del canva
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
}
