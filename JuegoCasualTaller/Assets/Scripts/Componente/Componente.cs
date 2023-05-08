using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Componente : MonoBehaviour
{
    public PlayerMovementAI playerMovementAI;
    public GameObject[] Barras; //Gabinete = 0, CPU = 1, RAM = 2
    public Image[] barrasImagenes;  //Gabinete = 0, CPU = 1, RAM = 2
    private float timerGabinete;
    private float timerCPU;
    private float timerRAM;

    //Minijuego
    public GameObject[] miniJuegosPanel;
    public Image[] miniJuegosImagenBarra;

    public float dinero;
    public TextMeshProUGUI dineroTexto;


    // Start is called before the first frame update
    void Start()
    {
        Barras[0].SetActive(false);
        Barras[1].SetActive(false);
        Barras[2].SetActive(false);
        miniJuegosPanel[0].SetActive(false);
        dinero = dinero + 0;

    }

    // Update is called once per frame
    void Update()
    {
    }

    void Condiciones()
    {
        Barras[0].SetActive(playerMovementAI.enGabinete);
        Barras[1].SetActive(playerMovementAI.enCPU);
        Barras[2].SetActive(playerMovementAI.enRAM);
        miniJuegosPanel[0].SetActive(playerMovementAI.enMesaDeTrabajo);

    }

    void Temporizador()
    {
        if (playerMovementAI.enGabinete)
        {
            timerGabinete = timerGabinete + 1 * Time.deltaTime;
            barrasImagenes[0].fillAmount = timerGabinete / 10;
        }
        else
        {
            timerGabinete = 0;
        }

        if (playerMovementAI.enCPU)
        {
            timerCPU = timerCPU + 1 * Time.deltaTime;
            barrasImagenes[1].fillAmount = timerCPU / 10;
        }
        else
        {
            timerCPU = 0;
        }
        if (playerMovementAI.enRAM)
        {
            timerRAM = timerRAM + 1 * Time.deltaTime;
            barrasImagenes[2].fillAmount = timerRAM / 10;
        }
        else
        {
            timerRAM = 0;
        }
    }

    void DineroNivel1()
    {

        if (!playerMovementAI.enMesaVenta)
        {
            dinero = dinero + 0 * Time.deltaTime;
            dineroTexto.text = "" + Mathf.Round(dinero);

        }
        else
        {
            dinero = dinero + 5 * Time.deltaTime;
            dineroTexto.text = "" + Mathf.Round(dinero);
        }
    }
}
