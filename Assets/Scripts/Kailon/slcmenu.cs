using UnityEngine.SceneManagement;
using UnityEngine;

public class slcmenu : MonoBehaviour
{
    public GameObject Telaslc;
    public GameObject TelaPrincipal;
 public void startgame (){
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

 }
 public void saidatelaslc (){
     Telaslc.SetActive(false);
TelaPrincipal.SetActive(true);
 }
 
}
