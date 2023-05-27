using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoNPC : MonoBehaviour
{
    public PlayerMovementAI playerMovement;

    [Header("Navi")]
    public Transform[] Fila;
    public Transform Salida;

    public bool EnMesa;
    public bool entregaGabinete;
    public bool pagado;


    public NavMeshAgent[] agentes; // Lista de agentes

    void Start()
    {
        StartCoroutine(CicloNPCs());
    }

    public IEnumerator CicloNPCs()
    {
        int currentIndex = 0;
        while (true) // Iterar infinitamente
        {
            // Obtener el NPC actual
            NavMeshAgent currentNPC = agentes[currentIndex];

            // Ejecutar la rutina del NPC actual
            yield return StartCoroutine(PasoNPC(currentNPC));

            // Aumentar el índice del NPC
            currentIndex++;
            if (currentIndex >= agentes.Length) // Si llegamos al último NPC, reiniciar
            {
                currentIndex = 0;
            }
        }
    }

    public IEnumerator PasoNPC(NavMeshAgent NPC)
    {
        NPC.SetDestination(Fila[0].transform.position);
        pagado = false;
        while (NPC.pathPending || NPC.remainingDistance > NPC.stoppingDistance)
        {
            yield return null;
        }
        EnMesa = true;
        while (!entregaGabinete)
        {
            yield return null;
        }
        //EnMesa = false;
        NPC.SetDestination(Fila[1].transform.position);

        while (!pagado)
        {
            yield return null;
        }
        pagado = true;
        entregaGabinete = false;
        NPC.SetDestination(Salida.transform.position);
    }
}
