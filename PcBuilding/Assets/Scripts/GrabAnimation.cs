using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAnimation : MonoBehaviour
{

    public Animator handOpenClose;

    bool limiter = false;
    float animTimer=0f;
    Vector3 pos1;
    Vector3 originalPos;
    Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        handOpenClose = GetComponent<Animator>();
    }

    void Update(){

        if(limiter){
        transform.position =  Vector3.MoveTowards(transform.position,pos1,0.005f);
        transform.Rotate(new Vector3(0f,0f,90f) * 0.005f);
        animTimer+=Time.deltaTime;

            if (animTimer > 1f)
            {
                limiter = false;
                animTimer = 0f;
            }
        }
    }

    public void openHand(){
        originalPos = transform.position;
        originalRotation = transform.rotation;
        handOpenClose.SetBool("Open",true);
        

    }
    public void closeHand(){
        handOpenClose.SetBool("Open",false);
        transform.position = originalPos;
        transform.rotation = originalRotation;
        
    }


    public void handToObject(Vector3 pos){

        
       
        pos1 = pos;
        limiter = true;

        

    }
}
