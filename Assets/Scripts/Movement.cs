using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float roatationThrust = 100f;
     Rigidbody rb;
     AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
    rb = GetComponent<Rigidbody>();
    audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        
        ProcessRotation();
    }

    void ProcessThrust(){
        
        if(Input.GetKey(KeyCode.Space)){
           rb.AddRelativeForce(UnityEngine.Vector3.up * mainThrust * Time.deltaTime);
           if(!audioSource.isPlaying){
           audioSource.Play();
           }
        }else{
            audioSource.Stop();
        }
    }
    void ProcessRotation(){
        
        if(Input.GetKey(KeyCode.A))
        {
            applyRotation(roatationThrust);
        }
        else if (Input.GetKey(KeyCode.D)){  
            applyRotation(-roatationThrust);
        }
    }

    void applyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // Freezing Rotation for manual control
        transform.Rotate(UnityEngine.Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // Unfreezing Rotation after manual control
    }
}
