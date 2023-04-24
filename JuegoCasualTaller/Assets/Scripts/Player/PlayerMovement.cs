using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] private GameInput gameInput;
    
    private void Update()
    {
        Movimiento();
    }


    //Inputs del personaje
    public void Movimiento()
    {
        Vector3 inputVector = gameInput.GetMovementVectorNormalized();
        float rotateSpeed = 10f;
        
        transform.position += inputVector * Time.deltaTime* moveSpeed;
        transform.forward = Vector3.Slerp(transform.forward,inputVector,Time.deltaTime*rotateSpeed);
    }
}
