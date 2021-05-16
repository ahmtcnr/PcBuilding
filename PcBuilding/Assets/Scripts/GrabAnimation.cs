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
    public int deneme = 0;

    void Start()
    {
        handOpenClose = GetComponent<Animator>();
        originalPos = transform.position;
        

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

        handOpenClose.SetBool("Open", true);


    }
    public void closeHand()
    {

        transform.position = originalPos;
        handOpenClose.SetBool("Open", false);


    }


    public void handToObject(Vector3 pos)
    {



        pos1 = pos;
        limiter = true;



    }
}
