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
        //Rota el raycast
        playerMovement.RotarHaciaObjetivo(playerMovement.objetoRaycast, Componente);
        //Rota la visual del jugador
        playerMovement.RotarEnDireccionEjeYVisual(playerMovement.jugadorVisual, Componente);
        yield return new WaitForSeconds(TiempoDeEjecucion);
        completado = true;
    }

}
