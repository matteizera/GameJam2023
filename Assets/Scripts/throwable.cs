using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwable : MonoBehaviour
{
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = waitAndUpdate();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c){
        Debug.Log("Bateu");
        if(c.gameObject.tag=="Player"){
            Debug.Log("Player");

            c.gameObject.GetComponent<Health>().TakeDamage(20);
        }
        if(gameObject.tag != "Grabavel")
            UpdateStats();
    }

     private IEnumerator waitAndUpdate(){
        yield return new WaitForSeconds(2f);
        UpdateStats();

    }
    void UpdateStats(){
        gameObject.tag = "Grabavel";
        Destroy(GetComponent<Rigidbody>());
    }
}
