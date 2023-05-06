using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementAI : MonoBehaviour
{
    public MovimientoNPC movimientoNPC;

    private int numeroGenerado;

    public NavMeshAgent jugador1; //Navi
    [Header("Navi")]
    public Transform[] Componentes; //Posicion de los componentes, 0 = Gabinete, 1 = CPU, 2 = RAM, 3 MesaArmado, 4 Venta 
    public float timer; //Temporizador
    public float tiempoArmado = 0f; // Tiempo para armar

    //Raycast
    [Header("Raycast")]
    [SerializeField] public Transform objetoRaycast;
    public float rayoDistancia;

    [Header("Personaje Visual")]
    public Transform jugadorVisual;

    public bool enGabinete;
    public bool enCPU;
    public bool enRAM;
    public bool enMesaDeTrabajo;
    public bool enMesaVenta;
    public bool ventaLista;

    public Ruta Ruta1;
    public Ruta Ruta2;
    public Ruta Ruta3;

    public bool procesoIniciado = false;

    void Start()
    {
        jugador1 = GetComponent<NavMeshAgent>();
        numeroGenerado = Comportamiento();
    }

    void Update()
    {
        if (movimientoNPC.MesaNPC() == true && procesoIniciado == false)
        {
            Ruta1.Iniciar();
            procesoIniciado = true;
            Contador();
        }

        
        

    }

    public void MovimientoGabinete()
    {
        jugador1.SetDestination(Componentes[0].transform.position);
    }
    public void MovimientoCPU()
    {
        jugador1.SetDestination(Componentes[1].transform.position);
    }

    public void MovimientoRAM()
    {
        jugador1.SetDestination(Componentes[2].transform.position);
    }
    public void MovimientoMesaTrabajo()
    {
        jugador1.SetDestination(Componentes[3].transform.position);
    }
    public void MovimientoMesaVenta()
    {
        jugador1.SetDestination(Componentes[4].transform.position);
    }
    void Contador()
    {
        Debug.DrawRay(objetoRaycast.position, objetoRaycast.forward * rayoDistancia, Color.red);
        RaycastHit hit;
        

        //Raycast
        if (Physics.Raycast(objetoRaycast.position, objetoRaycast.forward, out hit, rayoDistancia))
        {
            
        }
        if (hit.transform == null)
        {
            Debug.Log("Nada");
            enGabinete = false;
            enCPU = false;
            enRAM = false;
            enMesaDeTrabajo = false;
            enMesaVenta = false;
        }
        else if (hit.transform.name == "Gabinete (0)")
        {

            timer = timer + 1 * Time.deltaTime;
            Debug.Log(timer);
            enGabinete = true;
            enCPU = false;
            enRAM = false;
            enMesaDeTrabajo = false;
            enMesaVenta = false;

        }
        else if(hit.transform.name == "CPU (0)")
        {
            timer = timer + 1 * Time.deltaTime;
            Debug.Log(timer);
            enGabinete = false;
            enCPU = true;
            enRAM = false;
            enMesaDeTrabajo = false;
            enMesaVenta = false;
        }
        else if(hit.transform.name == "RAM (0)")
        {
            timer = timer + 1 * Time.deltaTime;
            Debug.Log(timer);
            enGabinete = false;
            enCPU = false;
            enRAM = true;
            enMesaDeTrabajo = false;
            enMesaVenta = false;
        }
        else if(hit.transform.name == "MesaTrabajo")
        {
            timer = timer + 1 * Time.deltaTime;
            Debug.Log(timer);
            enGabinete = false;
            enCPU = false;
            enRAM = false;
            enMesaDeTrabajo = true;
            enMesaVenta = false;
        }
        else if (hit.transform.name == "MesaVenta")
        {
            timer = timer + 1 * Time.deltaTime;
            Debug.Log(timer);
            enGabinete = false;
            enCPU = false;
            enRAM = false;
            enMesaDeTrabajo = false;
            enMesaVenta = true;
        }
    }

    public void RotarHaciaObjetivo(Transform objetoRotar, Transform objetivo)
    {
        Vector3 direccion = (objetivo.transform.position - objetoRotar.transform.position).normalized;
        objetoRotar.transform.rotation = Quaternion.LookRotation(direccion);
    }

    public void RotarEnDireccionEjeYVisual(Transform objetoRotar, Transform objetivo)
    {
        Vector3 direccion = (objetivo.transform.position - objetoRotar.transform.position).normalized;
        Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
        float rotacionY = rotacionObjetivo.eulerAngles.y;
        objetoRotar.transform.rotation = Quaternion.Euler(0, rotacionY, 0);
    }

    public int Comportamiento()
    {
        int[] numerosPosibles = new int[] { 1, 2,3};
        int indiceAleatorio = Random.Range( 0, numerosPosibles.Length);
        return numerosPosibles[indiceAleatorio];

    }
}




