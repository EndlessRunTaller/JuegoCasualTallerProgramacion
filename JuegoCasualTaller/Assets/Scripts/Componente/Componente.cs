using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Componente : MonoBehaviour
{
    [Header("Animacion")]
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    bool activarAnimacion1;

    [Header("Objetos")]
    public PlayerMovementAI playerMovementAI;
    public GameObject[] cajas;
    public GameObject[] gabinetes;

    [Header("Dinero")]
    public float dinero;
    public TextMeshProUGUI dineroTexto;


    //Gabinete = 0
    public int nivelGabinete = 1;
    private int valorGabinete = 1;
    private int aumentoGabinete = 1;
    public bool gabineteRapida;
    private int valorDestornillador = 50;

    [Header("Gabinete")]
    public TextMeshProUGUI valorGabineteTexto;
    [SerializeField] private Image coloresMejoraGabinete;
    [SerializeField] private Image colorUpGabinete;
    public TextMeshProUGUI nivelTextoGabinete;
    [SerializeField] private GameObject mejoraDestornillador;

    //CPU = 1
    public int nivelCPU = 1;
    private int valorCPU = 1;
    private int aumentoCPU = 1;
    public bool CPURapida;
    private int valorPasta = 50;

    
    [Header("CPU")]
    public TextMeshProUGUI valorCPUTexto;
    [SerializeField] private Image coloresMejoraCPU;
    [SerializeField] private Image colorUpCPU;
    public TextMeshProUGUI nivelTextoCPU;
    [SerializeField] private GameObject mejoraPasta;
    //RAM = 2
    public int nivelRAM = 1;
    private int valorRAM = 1;
    private int aumentoRAM = 1;
    public bool RAMRapida;
    private int valorRamRapida = 50;

    [Header("RAM")]
    public TextMeshProUGUI valorRAMTexto;
    [SerializeField] private Image coloresMejoraRAM;
    [SerializeField] private Image colorUpRAM;
    public TextMeshProUGUI nivelTextoRAM;
    [SerializeField] private GameObject mejoraRAM;


    [Header("UI")]
    public GameObject[] flechaMejora;
    public GameObject[] subMenu;
    public GameObject panelTienda;

    // Start is called before the first frame update
    void Start()
    {
        flechaMejora[0].SetActive(true);
        flechaMejora[1].SetActive(true);
        flechaMejora[2].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Dinero
        dinero = dinero + 0 * Time.deltaTime;
        dineroTexto.text = "" + Mathf.Round(dinero);

        //Gabinete
        valorGabineteTexto.text = "" + Mathf.Round(valorGabinete);
        nivelTextoGabinete.text = "Nivel " + Mathf.Round(nivelGabinete);
        if (dinero < valorGabinete)
        {
            coloresMejoraGabinete.GetComponent<Image>().color = new Color32(102, 102, 102, 255);
            colorUpGabinete.GetComponent<Image>().color = new Color32(102, 102, 102, 255);
            anim1.SetBool("isActive", false);
        }
        else
        {
            coloresMejoraGabinete.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            colorUpGabinete.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            anim1.SetBool("isActive", true);
        }


        //CPU

        valorCPUTexto.text = "" + Mathf.Round(valorCPU);
        nivelTextoCPU.text = "Nivel " + Mathf.Round(nivelCPU);
        if (dinero < valorCPU)
        {
            coloresMejoraCPU.GetComponent<Image>().color = new Color32(102, 102, 102, 255);
            colorUpCPU.GetComponent<Image>().color = new Color32(102, 102, 102, 255);
            anim2.SetBool("isActive", false);
        }
        else
        {
            coloresMejoraCPU.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            colorUpCPU.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            anim2.SetBool("isActive", true);

        }

        //RAM

        valorRAMTexto.text = "" + Mathf.Round(valorRAM);
        nivelTextoRAM.text = "Nivel " + Mathf.Round(nivelRAM);
        if (dinero < valorRAM)
        {
            coloresMejoraRAM.GetComponent<Image>().color = new Color32(102, 102, 102, 255);
            colorUpRAM.GetComponent<Image>().color = new Color32(102, 102, 102, 255);
            anim3.SetBool("isActive", false);
        }
        else
        {
            coloresMejoraRAM.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            colorUpRAM.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            anim3.SetBool("isActive", true);
        }



    }



    //OTRO MENÚ

    public void SUBMENUGABINETE()
    {
        if (subMenu[0] != null)
        {
            bool IsActive = subMenu[0].activeSelf;
            subMenu[0].SetActive(!IsActive);
            if (!IsActive)
            {
                subMenu[1].SetActive(false);
                subMenu[2].SetActive(false);
            }
        }
    }
    public void SUBMENUCPU()
    {
        if (subMenu[1] != null)
        {
            bool IsActive = subMenu[1].activeSelf;
            subMenu[1].SetActive(!IsActive);
            if (!IsActive)
            {
                subMenu[0].SetActive(false);
                subMenu[2].SetActive(false);
            }
        }

    }
    public void SUBMENURAM()
    {
        if (subMenu[2] != null)
        {
            bool IsActive = subMenu[2].activeSelf;
            subMenu[2].SetActive(!IsActive);
            if (!IsActive)
            {
                subMenu[0].SetActive(false);
                subMenu[1].SetActive(false);
            }
        }

    }

    //Subir de nivel



    public void SUBIRGABINETE()
    {
        if (dinero >= valorGabinete)
        {
            valorGabinete += aumentoGabinete;
            aumentoGabinete++;
            nivelGabinete = nivelGabinete + 1;
            if (dinero >= valorGabinete)
            {
                dinero -= valorGabinete;
            }
            else
            {
                dinero = 0;
            }

        }
    }

    public void SUBIRCPU()
    {
        if (dinero >= valorCPU)
        {
            valorCPU += aumentoCPU;
            aumentoCPU++;
            nivelCPU = nivelCPU + 1;
            if (dinero >= valorCPU)
            {
                dinero -= valorCPU;
            }
            else
            {
                dinero = 0;
            }
        }
    }

    public void SUBIRRAM()
    {
        if (dinero >= valorRAM)
        {
            valorRAM += aumentoRAM;
            aumentoRAM++;
            nivelRAM = nivelRAM + 1;
            if (dinero >= valorRAM)
            {
                dinero -= valorRAM;
            }
            else
            {
                dinero = 0;
            }
        }
    }

    public void PANELTIENDAACTIVAR()
    {
        panelTienda.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PANELTIENDADESACTIVAR()
    {
        panelTienda.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MEJORARAPIDAGABINETE()
    {
        if(dinero >= valorDestornillador)
        {
            gabineteRapida = true;
            mejoraDestornillador.SetActive(!gabineteRapida);
            dinero = dinero - valorDestornillador;
        }
        
    }

    public void MEJORARAPIDACPU()
    {
        if(dinero >= valorPasta)
        {
            CPURapida = true;
            mejoraPasta.SetActive(!CPURapida);
            dinero = dinero - valorPasta;
        }       
    }

    public void MEJORARAPIDARAM()
    {
        if(dinero >= valorRamRapida)
        {
            RAMRapida = true;
            mejoraRAM.SetActive(!RAMRapida);
            dinero = dinero - valorRamRapida;
        }
    }
}
