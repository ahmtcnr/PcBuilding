using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAnimation : MonoBehaviour
{

    public Animator handOpenClose;
    // Start is called before the first frame update
    void Start()
    {
        handOpenClose = GetComponent<Animator>();
    }


    public void openHand(){
        
        handOpenClose.SetBool("Open",true);
        Debug.Log("yo ?");

    }
    public void closeHand(){
        handOpenClose.SetBool("Open",false);
        
    }
}
