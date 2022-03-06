using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_Handler : MonoBehaviour
{
    [SerializeField] float invokeTime = 1f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys(){
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C)){
            collisionDisabled = !collisionDisabled; //Toggle Collision
        }
    }
 void OnCollisionEnter(Collision collision)
 {
    if(isTransitioning || collisionDisabled) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Lift-Off!");
                break;
            
            case "Finish":
                StartSuccessSequence();
                break;
                 
            default:
                StartCrashSequence();
                break;            
        }
    
 }

     void StartSuccessSequence(){
         isTransitioning = true;
         audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;   
        Invoke("LoadNextLevel", invokeTime);
    }

    void StartCrashSequence(){
    isTransitioning = true;
    audioSource.Stop();
    audioSource.PlayOneShot(crash);
    crashParticles.Play();
    GetComponent<Movement>().enabled = false;
    Invoke("ReloadLevel", invokeTime);
 }

 void ReloadLevel(){

    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
 }
 void LoadNextLevel(){
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex + 1;
    if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){
        nextSceneIndex = 0;
    }
        SceneManager.LoadScene(nextSceneIndex);
 }
}
