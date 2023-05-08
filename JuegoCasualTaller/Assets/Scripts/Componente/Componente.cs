using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Componente : MonoBehaviour
{
    public PlayerMovementAI playerMovementAI;
    //Minijuego
    public GameObject[] miniJuegosPanel;
    public Image[] miniJuegosImagenBarra;

    public float dinero;
    public TextMeshProUGUI dineroTexto;


    // Start is called before the first frame update
    void Start()
    {
        dinero = dinero + 0;
    }

    // Update is called once per frame
    void Update()
    {
        dinero = dinero + 0 * Time.deltaTime;
        dineroTexto.text = "" + Mathf.Round(dinero);
    }
}
