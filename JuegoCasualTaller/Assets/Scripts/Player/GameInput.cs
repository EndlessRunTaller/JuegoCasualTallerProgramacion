using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private Inputs inputs;

    private void Awake()
    {
        inputs = new Inputs();
        inputs.Player.Enable();
    }

    public Vector3 GetMovementVectorNormalized()
    {
        Vector3 inputVector = inputs.Player.Move.ReadValue<Vector3>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
}