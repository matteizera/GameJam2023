
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTutorial : MonoBehaviour
{
    public GameObject TelaTutorial;
    public GameObject TelaPrincipal;
    public GameObject TelasTutorial2;

public void avancatelatutorial (){
//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
TelaTutorial.SetActive(false);
TelasTutorial2.SetActive(true);
}
public void VoltarTela (){
TelaTutorial.SetActive(false);
TelaPrincipal.SetActive(true);
}
        
  
}
