using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occerlator : MonoBehaviour
{
    Vector3 startingpos;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    float movementFactor;
    void Start()
    {
        startingpos = transform.position;
        Debug.Log(startingpos);    
    }

    
    void Update()
    {
     if(period == 0f) return;
     float cycles = Time.time / period;
     const float tau = Mathf.PI * 2;
     float rawSinWave = Mathf.Sin(cycles*tau);

     movementFactor = (rawSinWave + 1f) / 2f;
     Vector3 offset = movementVector * movementFactor;
     transform.position = startingpos+ offset;
    }
}
