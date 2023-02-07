using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuPause;
    public static bool gamepaused = false;
    public void BotaoVoltar(){
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
   Time.timeScale = 1f;
    }
     void Start()
    {
       Time.timeScale = 1f; 
    }
    public void BotaoVoltajogo(){
        resume();
    }
       
    void FixedUpdate()
    {

    }

    public void Pause(InputAction.CallbackContext context){
        // if (gamepaused==true)
        //     {
        //         Debug.Log ("gamepaused3");
        //     resume();
        //     }
        //     else {
        //         pause();
                
        //     }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
void resume(){
    menuPause.SetActive(false);
    Time.timeScale = 1f;
    gamepaused = false;
}
void pause(){
   
               Time.timeScale = 0f;
                Debug.Log ("gamepaused2");
                 gamepaused = true;
        menuPause.SetActive(true);
                
}
}
