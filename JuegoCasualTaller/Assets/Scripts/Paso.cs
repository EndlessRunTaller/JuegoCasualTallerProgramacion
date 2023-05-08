using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Paso : MonoBehaviour
{
    public bool completado;
    public PlayerMovementAI playerMovement;
    public Transform Componente;
    public int tiempoDeEspera;

    bool llego = false;

    public GameObject barraTiempo;
    public Image barraImagen;

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
        barraTiempo.SetActive(llego);
        
        yield return new WaitForSeconds(tiempoDeEspera);
        barraTiempo.SetActive(false);
        llego = false;
        barraTiempo.SetActive(llego);

        completado = true;
    }

    public void Update()
    {
        playerMovement.RotarHaciaObjetivo(playerMovement.objetoRaycast, playerMovement.rotacion);
        playerMovement.RotarEnDireccionEjeYVisual(playerMovement.jugadorVisual, playerMovement.rotacion);
    }
}
