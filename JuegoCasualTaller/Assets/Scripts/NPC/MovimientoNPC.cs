using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoNPC : MonoBehaviour
{
    public PlayerMovementAI playerMovementAI;

    [Header("Navi")]
    public NavMeshAgent NPC1;
    private float timer;
    public Transform[] Fila;
    public Transform Salida;

    [Header("Raycast")]
    [SerializeField] private Transform objetoRaycast;
    public float rayoDistancia;
    bool EnMesa;

    private void Start()
    {
        NPC1.SetDestination(Fila[0].transform.position);
    }

    void Update()
    {
        //if(playerMovementAI.)
    }

    public bool MesaNPC()
    {
        Debug.DrawRay(objetoRaycast.position, objetoRaycast.forward * rayoDistancia, Color.red);
        RaycastHit hit;


        //Raycast
        if (Physics.Raycast(objetoRaycast.position, objetoRaycast.forward, out hit, rayoDistancia))
        {

        }
        if(hit.transform == null)
        {
            EnMesa = false;
        }
        else if (hit.transform.name == "MesaAtender")
        {
            EnMesa = true;
        }
        return EnMesa;
    }
}
