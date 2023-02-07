using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthItem : MonoBehaviour
{
    public GameObject gm;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag=="Player2"|| collider.tag=="Player"){
            collider.gameObject.GetComponent<Health>().takeCure(20);
            Destroy(gm);
        }
    }
}
