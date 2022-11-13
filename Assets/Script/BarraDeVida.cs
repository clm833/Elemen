using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    //public Image barraDeVida;
    //public string vidaActual;
    //public float vidaMaxima;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void actualizar(string texto)
    {
        //barraDeVida.fillAmount = vidaActual / vidaMaxima;
        GetComponent<Text>().text = texto;
    }
}
