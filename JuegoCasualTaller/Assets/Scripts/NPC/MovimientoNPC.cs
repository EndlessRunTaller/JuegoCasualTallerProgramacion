using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoNPC : MonoBehaviour
{
    public PlayerMovementAI playerMovement;

    [Header("Navi")]
    public NavMeshAgent NPC1;
    public NavMeshAgent NPC2;
    public Transform[] Fila;
    public Transform Salida;

    public bool EnMesa;
    public bool entregaGabinete;
    public bool pagado;




    public void Start()
    {
        StartCoroutine(PasoNPC0());
    }
    public IEnumerator PasoNPC0()
    {    
        NPC1.SetDestination(Fila[0].transform.position);
        while (NPC1.pathPending || NPC1.remainingDistance > NPC1.stoppingDistance)
        {
            yield return null;
        }
        EnMesa = true;
        while (!entregaGabinete)
        {
            yield return null;
        }
        //EnMesa = false;
        NPC1.SetDestination(Fila[1].transform.position);

        while (!pagado)
        {
            yield return null;
        }
        pagado = true;
        NPC1.SetDestination(Salida.transform.position);
    }
}
