using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float roatationThrust = 100f;
    [SerializeField] AudioClip EngineClip;
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] ParticleSystem maineBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;
    bool isAlive;

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

    void ProcessThrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(UnityEngine.Vector3.up * mainThrust * Time.deltaTime);

            if (!maineBooster.isPlaying){
                maineBooster.Play();
            }else{
                maineBooster.Stop();
            }
            if (!audioSource.isPlaying){
                audioSource.PlayOneShot(EngineClip);
            }
        }else
        {
            audioSource.Stop();

        }
    }
    void ProcessRotation()
    {

        if (Input.GetKey(KeyCode.A))
        {
            applyRotation(roatationThrust);
              if (!rightBooster.isPlaying)
            {
                rightBooster.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            applyRotation(-roatationThrust);
               if (!leftBooster.isPlaying)
            {
                leftBooster.Play();
            }
        } else{
            rightBooster.Stop();
            leftBooster.Stop();
        }
    }

    void applyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // Freezing Rotation for manual control
        transform.Rotate(UnityEngine.Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // Unfreezing Rotation after manual control
    }
}
