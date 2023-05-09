using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Componente : MonoBehaviour
{
    public PlayerMovementAI playerMovementAI;
    public GameObject[] cajas;
    public GameObject[] gabinetes;

    public float dinero;
    public TextMeshProUGUI dineroTexto;

    private int nivelGabinete;
    private int nivelCPU;
    private int nivelRAM;

    private int valorGabinete;
    private int valorCPU;
    private int valorRAM;

    public GameObject[] flechaMejora;
    public GameObject[] subMenu;





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
        GABINETEMEJORA();
        CPUMEJORA();
        RAMMEJORA();


    }

    //MEJORAS
    void GABINETEMEJORA()
    {
        if (dinero > valorGabinete)
        {
            flechaMejora[0].SetActive(true);
        }
        else
        {
            flechaMejora[0].SetActive(false);
        }
    }
    void CPUMEJORA()
    {
        if (dinero > valorCPU)
        {
            flechaMejora[1].SetActive(true);
        }
        else
        {
            flechaMejora[1].SetActive(false);
        }
    }
    void RAMMEJORA()
    {
        if (dinero > valorRAM)
        {
            flechaMejora[2].SetActive(true);
        }
        else
        {
            flechaMejora[2].SetActive(false);
        }
    }


    //OTRO MENÚ

    public void SUBMENUGABINETE()
    {
        if(subMenu[0] != null)
        {
            bool IsActive = subMenu[0].activeSelf;
            subMenu[0].SetActive(!IsActive);
        }
    }
    public void SUBMENUCPU()
    {
        if (subMenu[1] != null)
        {
            bool IsActive = subMenu[1].activeSelf;
            subMenu[1].SetActive(!IsActive);
        }
    }
    public void SUBMENURAM()
    {
        if (subMenu[2] != null)
        {
            bool IsActive = subMenu[2].activeSelf;
            subMenu[2].SetActive(!IsActive);
        }
    }
}
