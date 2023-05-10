using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Paso : MonoBehaviour
{
    public bool completado;
    public PlayerMovementAI playerMovement;
    public MovimientoNPC movimientoNPC;
    public Componente componente;
    public Transform Componente;
    public int tiempoDeEspera;
    public string nombre;

    bool llego = false;

    public GameObject barraTiempo;
    public Image barraImagen;
    private float timer =0;

    public IEnumerator Ejecutar()
    {
        NavMeshAgent agente = playerMovement.jugador1;
        agente.SetDestination(Componente.position);
        playerMovement.rotacion.position = Componente.position;

        while (agente.pathPending || agente.remainingDistance > agente.stoppingDistance)
        {
            yield return null;
        }
        llego = true;
        if (nombre == "Trabajo")
        {
            componente.cajas[0].SetActive(true);
            componente.cajas[1].SetActive(true);
            componente.cajas[2].SetActive(true);
        }
        if(nombre == "Dinero")
        {
            componente.gabinetes[0].SetActive(true);
        }
        if(componente.gabineteRapida && nombre == "Gabinete")
        {
            tiempoDeEspera = tiempoDeEspera - 2;
        }
        if(componente.CPURapida && nombre == "CPU")
        {
            tiempoDeEspera = tiempoDeEspera - 2;
        }
        if(componente.RAMRapida && nombre == "RAM")
        {
            tiempoDeEspera = tiempoDeEspera - 2;
        }
        while (timer < tiempoDeEspera && llego)
        {
            timer = timer + 1 * Time.deltaTime;
            barraTiempo.SetActive(llego);
            barraImagen.fillAmount = timer / tiempoDeEspera;
            yield return null;
        }

        componente.cajas[0].SetActive(false);
        componente.cajas[1].SetActive(false);
        componente.cajas[2].SetActive(false);

        componente.gabinetes[0].SetActive(false);

        llego = false;
        barraTiempo.SetActive(llego);
        timer = 0;
        completado = true;
    }

    public void Update()
    {
        playerMovement.RotarHaciaObjetivo(playerMovement.objetoRaycast, playerMovement.rotacion);
        playerMovement.RotarEnDireccionEjeYVisual(playerMovement.jugadorVisual, playerMovement.rotacion);
    }
}
