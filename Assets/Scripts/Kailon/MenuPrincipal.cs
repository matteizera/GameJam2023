using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject MenuTutoriallUI ;
     public GameObject MenuPrincipallUI ;
    public void SairJogo()
    {
        Application.Quit();
    }
    public void BotaoIniciar()
    {
        MenuTutoriallUI.SetActive(true);
        MenuPrincipallUI.SetActive(false);
    }

}
