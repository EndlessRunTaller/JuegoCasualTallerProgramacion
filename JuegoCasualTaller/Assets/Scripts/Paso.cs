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

    public GameObject miniJuego;
    public mingameLogic mingameLogic;

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
        if(nombre == "Dinero")
        {
            componente.gabinetes[0].SetActive(true);
            movimientoNPC.entregaGabinete = true;
        }
        if(componente.gabineteRapida && nombre == "Gabinete")
        {
            tiempoDeEspera = 1;          
        }
        if(componente.CPURapida && nombre == "CPU")
        {
            tiempoDeEspera = 1;
        }
        if(componente.RAMRapida && nombre == "RAM")
        {
            tiempoDeEspera = 1;
        }

        while (timer < tiempoDeEspera && llego)
        {
            timer = timer + 1 * Time.deltaTime;
            barraTiempo.SetActive(llego);
            barraImagen.fillAmount = timer / tiempoDeEspera;
            yield return null;
        }
        if (nombre == "CPU")
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.Agarrar);
        }
        if (nombre == "RAM")
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.Agarrar);
        }
        if (nombre == "Gabinete")
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.Agarrar);
        }


        if (nombre == "Trabajo")
        {
            miniJuego.SetActive(true);
            mingameLogic.minijuegoTornillos[0].SetActive(true);
            mingameLogic.minijuegoTornillos[1].SetActive(true);
            mingameLogic.minijuegoTornillos[2].SetActive(true);
            mingameLogic.minijuegoTornillos[3].SetActive(true);
            yield return new WaitWhile(() => mingameLogic.screwsRemoved < 4);
        }

        miniJuego.SetActive(false);
        mingameLogic.screwsRemoved = 0;
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
