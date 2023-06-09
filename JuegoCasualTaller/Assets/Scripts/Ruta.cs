using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruta : MonoBehaviour
{
    public Paso PasoFinal;
    public List<Paso> PasosEnRuta;
    public PlayerMovementAI playerMovement;
    public MovimientoNPC movimientoNPC;
    public Componente componente;

    public void Iniciar()
    {
        Reset();
        StartCoroutine(Ejecutar());
    }

    public IEnumerator Ejecutar()
    {
        UnityEngine.AI.NavMeshAgent agente = playerMovement.jugador1;
        foreach (Paso p in PasosEnRuta)
        {
            StartCoroutine(p.Ejecutar());
            yield return new WaitWhile(() => p.completado == false);
        }
        StartCoroutine(PasoFinal.Ejecutar());

        while (agente.pathPending || agente.remainingDistance > agente.stoppingDistance)
        {
            yield return null;
        }
        
        yield return new WaitWhile(() => PasoFinal.completado == false);
        componente.dinero = componente.dinero + 25 + (componente.nivelGabinete * 3) + (componente.nivelCPU * 3) + (componente.nivelRAM * 3);
        AudioManager.instance.PlayAudio(AudioManager.instance.Despide);

        movimientoNPC.pagado = true;
        playerMovement.procesoIniciado = false;
    }

    public void Reset()
    {
        PasoFinal.completado = false;
        foreach (Paso p in PasosEnRuta)
        {
            p.completado = false;
        }
    }

}
