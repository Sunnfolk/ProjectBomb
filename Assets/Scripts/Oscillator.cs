using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range (0,1)] float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPosition = transform.position;
    }

    
    void Update()
    {
        if (period <= Mathf.Epsilon) {return;} // this is to make sure that the period isnt 0 since that would mean that the cycles line bellow will try to divide by 0, which is mathematically impossible. Also, you shouldnt use float variables == 0 since its unpredictable since floats can vary by a very small margine. Thats why "Mathf.Epsilon" was used 
        float cycles = Time.time / period; // constantly growing over time as it is the number of cycles the object has ocilated
        
        const float tau = Mathf.PI * 2; // constant value of 6.283 (2 PI)
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1. Tau = one whole cycle, soo multiplying with number of cycles will make it continue 

        movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1 so the object will stop at its equilibrium position and not go bellow ground

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;

    }
}
