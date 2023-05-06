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
        playerMovement.RotarHaciaObjetivo(playerMovement.objetoRaycast, Componente);
        playerMovement.RotarEnDireccionEjeYVisual(playerMovement.jugadorVisual, Componente);
        playerMovement.tiempoReal = TiempoDeEjecucion - playerMovement.timer;
        Debug.Log(playerMovement.tiempoReal);
        yield return new WaitForSeconds(playerMovement.tiempoReal);
        completado = true;
    }

}
