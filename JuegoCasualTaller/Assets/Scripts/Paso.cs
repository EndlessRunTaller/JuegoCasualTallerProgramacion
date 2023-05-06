using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paso : MonoBehaviour
{
    public bool completado;
    public PlayerMovementAI playerMovement;
    public Transform Componente;
    public float TiempoDeEjecucion;

    public IEnumerator Ejecutar()
    {
        playerMovement.jugador1.SetDestination(Componente.position);
        playerMovement.rotacion.position = Componente.position;
        playerMovement.tiempoReal = TiempoDeEjecucion - playerMovement.timer;

        yield return new WaitForSeconds(playerMovement.tiempoReal);

        completado = true;
    }

    public void Update()
    {

        playerMovement.RotarHaciaObjetivo(playerMovement.objetoRaycast, playerMovement.rotacion);
        playerMovement.RotarEnDireccionEjeYVisual(playerMovement.jugadorVisual, playerMovement.rotacion);
    }
}
