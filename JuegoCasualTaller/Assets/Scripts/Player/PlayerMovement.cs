using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    
    private void Update()
    {
        Movimiento();
    }


    //Inputs del personaje
    public void Movimiento()
    {
        float rotateSpeed = 10f;
        Vector3 inputVector = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.z = +1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.z = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }
        //Trasladar al personaje
        inputVector = inputVector.normalized;
        transform.position += inputVector * Time.deltaTime* moveSpeed;
        transform.forward = Vector3.Slerp(transform.forward,inputVector,Time.deltaTime*rotateSpeed);
    }
}
