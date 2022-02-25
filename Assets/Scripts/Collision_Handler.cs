using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_Handler : MonoBehaviour
{
    [SerializeField] float invokeTime = 1f;
 void OnCollisionEnter(Collision collision)
 {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Lift-Off!");
                break;
            
            case "Finish":
                StartFinishSequence();
                break;
                 
            default:
                StartCrashSequence();
                break;            
        }
 }

     void StartFinishSequence()
    {
        GetComponent<Movement>().enabled = false;   
        Invoke("LoadNextLevel", invokeTime);
    }

    void StartCrashSequence(){
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
