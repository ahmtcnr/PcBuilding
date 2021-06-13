using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private Transform theDestination;
    public static GrabAnimation grabInstance;

    GameObject rightHand;
    

    public float edgeRight;
    public float edgeUp;
    void Start()
    {
        theDestination = GameObject.Find("Grab").GetComponent<Transform>();
        grabInstance = GameObject.Find("rightHand").GetComponent<GrabAnimation>();
        rightHand = GameObject.Find("rightHand");
        
    }


    void Update(){
        


    }



    IEnumerator waiter()
    {
        grabInstance.openHand();
        edgeRight = this.transform.position.x + (this.transform.localScale.x / 2f);
        edgeUp = this.transform.position.y + (this.transform.localScale.y * 2f);

        Vector3 pos = new Vector3(edgeRight, edgeUp + 0.08f, transform.position.z);

        grabInstance.handToObject(pos);

        yield return new WaitForSeconds(1);


        GetComponent<Rigidbody>().useGravity = false;


        this.transform.position = theDestination.position;
        this.transform.parent = GameObject.Find("rightHand").transform;


    }

    void OnMouseDown()
    {

        StartCoroutine(waiter());



    }

    void OnMouseUp()
    {

        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;

        grabInstance.closeHand();

    }

     
}
