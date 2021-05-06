using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Transform theDestination;
    public static GrabAnimation grabInstance;

     

    public float edgeRight1;
    public float edgeUp;    
    void Start(){

        grabInstance = GameObject.Find("acilan").GetComponent<GrabAnimation>();
        
    }



    IEnumerator waiter(){
        grabInstance.openHand();
        edgeRight1 = this.transform.position.x + (this.transform.localScale.x / 2f); 
        edgeUp = this.transform.position.y + (this.transform.localScale.y / 2f); 
        Debug.Log(edgeRight1);
        Vector3 pos = new Vector3(edgeRight1+0.1f,edgeUp,transform.position.z);
        grabInstance.handToObject(pos);

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
