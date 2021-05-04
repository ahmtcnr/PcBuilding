using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Transform theDestination;
    public static GrabAnimation grabInstance;
    void Start(){

        grabInstance = GameObject.Find("acilan").GetComponent<GrabAnimation>();
        
    }



    IEnumerator waiter(){
        grabInstance.openHand();
        yield return new WaitForSeconds(1);
        
        
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theDestination.position;
        this.transform.parent = GameObject.Find("Grab").transform;
    }

    void OnMouseDown(){
        StartCoroutine(waiter());
        
        
        
    }

    void OnMouseUp(){

        this.transform.parent=null;
        GetComponent<Rigidbody>().useGravity = true;
        grabInstance.closeHand();
        
    }
}
