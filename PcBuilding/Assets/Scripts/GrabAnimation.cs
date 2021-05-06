using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAnimation : MonoBehaviour
{

    public Animator handOpenClose;

    bool limiter = false;
    float animTimer=0f;
    Vector3 pos1;
    // Start is called before the first frame update
    void Start()
    {
        handOpenClose = GetComponent<Animator>();
    }

    void Update(){

        if(limiter){
        transform.position =  Vector3.MoveTowards(transform.position,pos1,0.01f);;
        animTimer+=Time.deltaTime;

            if (animTimer > 1f)
            {
                limiter = false;
            }
        }
    }

    public void openHand(){
        
        handOpenClose.SetBool("Open",true);
        

    }
    public void closeHand(){
        handOpenClose.SetBool("Open",false);
        
    }


    public void handToObject(Vector3 pos){

        
        Debug.Log(pos);
        pos1 = pos;
        limiter = true;

        

    }
}
