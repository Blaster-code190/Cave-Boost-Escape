using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_Handler : MonoBehaviour
{
 void OnCollisionEnter(Collision collision)
 {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Lift-Off!");
                break;
            
            case "Finish":
            Debug.Log("Level FInished");
                break;
            case "Fuel":
                Debug.Log("Picked Fuel");
                break;
                
            default:
                    ReloadLevel();
                break;            
        }
 }
 void ReloadLevel(){

    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
 }
}
