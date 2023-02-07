
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTutorial2 : MonoBehaviour
{
    public GameObject TelaTutorial2;
    public GameObject TelaPrincipal;
    public GameObject Telaselectchar;

public void avancatelatutorial (){
TelaTutorial2.SetActive(false);
Telaselectchar.SetActive(true);
}
public void VoltarTela (){
TelaTutorial2.SetActive(false);
TelaPrincipal.SetActive(true);
}
        
  
}