using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    GameObject varGameObject;
    public int maxHealth = 100;
    int currentHealth = 100;
    public Healthbar healthBar;


   void Start(){
       healthBar.SetMaxHealth(currentHealth);
       varGameObject = GameObject.Find("Main Camera");
       varGameObject.GetComponent<camerashake>().enabled = false;
   }

   public void TakeDamage (int damage)
   {
       currentHealth -= damage;
       healthBar.SetHealth(currentHealth);
       tremetela ();
       if(currentHealth <= 0){
           Die();
       }
   }

      public void takeCure (int cure)
   {
       currentHealth += cure;
       healthBar.SetHealth(currentHealth);
   }

    void Update()
    {
        /*
       if (Input.GetKeyDown(KeyCode.Space))
       {
           TakeDamage(10);
       }*/
    
        if (varGameObject.GetComponent<camerashake>().shakeDuration ==0f){
            varGameObject.GetComponent<camerashake>().enabled = false;
        }}
        
    void Die(){
        Debug.Log("HUGHGHG");
    }
    void tremetela(){
        
        varGameObject.GetComponent<camerashake>().enabled = true;
        varGameObject.GetComponent<camerashake>().shakeDuration = 0.3f;
       
    }
}
    
   

