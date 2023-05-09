using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoNPC : MonoBehaviour
{
    public PlayerMovementAI playerMovement;

    [Header("Navi")]
    public NavMeshAgent NPC1;
    private float timer;
    public Transform[] Fila;
    public Transform Salida;

    [Header("Raycast")]
    [SerializeField] private Transform objetoRaycast;
    public float rayoDistancia;
    public bool EnMesa;


    public void Start()
    {
        StartCoroutine(PasoNPC());
    }
    public IEnumerator PasoNPC()
    {
        NPC1.SetDestination(Fila[0].transform.position);
        while (NPC1.pathPending || NPC1.remainingDistance > NPC1.stoppingDistance)
        {
            yield return null;
        }
        EnMesa = true;
        yield return new WaitWhile(() => playerMovement.procesoIniciado == true);
        NPC1.SetDestination(Fila[1].transform.position);
        while (NPC1.pathPending || NPC1.remainingDistance > NPC1.stoppingDistance)
        {
            yield return null;
        }
        NPC1.SetDestination(Salida.transform.position);
    }
}
