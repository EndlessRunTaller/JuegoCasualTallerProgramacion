using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Paso : MonoBehaviour
{
    public bool completado;
    public PlayerMovementAI playerMovement;
    public Transform Componente;
    public int tiempoDeEspera;

    public IEnumerator Ejecutar()
    {
        NavMeshAgent agente = playerMovement.jugador1;
        agente.SetDestination(Componente.position);
        playerMovement.rotacion.position = Componente.position;

        while (agente.pathPending || agente.remainingDistance > agente.stoppingDistance)
        {
            yield return null;
        }

        yield return new WaitForSeconds(tiempoDeEspera);

        completado = true;
    }

    public void Update()
    {
        playerMovement.RotarHaciaObjetivo(playerMovement.objetoRaycast, playerMovement.rotacion);
        playerMovement.RotarEnDireccionEjeYVisual(playerMovement.jugadorVisual, playerMovement.rotacion);
    }
}
