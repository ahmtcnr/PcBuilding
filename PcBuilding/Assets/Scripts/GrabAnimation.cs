using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAnimation : MonoBehaviour
{

    public Animator handOpenClose;

    bool limiter = false;
    float animTimer = 0f;

    Vector3 rightHandPos;
    Vector3 pos1;
    private Vector3 originalPos;
    private Quaternion originalRot;
    public int deneme = 0;

    void Start()
    {
        handOpenClose = GetComponent<Animator>();
        
        

    }


    void Update()
    {

        if (limiter)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos1, 0.005f);
            transform.Rotate(new Vector3(0f, 0f, 90f) * 0.005f);
            animTimer += Time.deltaTime;

            if (animTimer > 1f)
            {
                limiter = false;
                animTimer = 0f;
            }
        }
    }

    public void openHand()
    {
        originalPos = this.transform.position;
        originalRot = this.transform.rotation;
        handOpenClose.SetBool("Open", true);


    }
    public void closeHand()
    {

        transform.localPosition = new Vector3(0.6f,0.1f,0.95f);
        transform.localEulerAngles = new Vector3(-2.5f,-15f,-70);
        handOpenClose.SetBool("Open", false);


    }


    public void handToObject(Vector3 pos)
    {



        pos1 = pos;
        limiter = true;



    }
}
