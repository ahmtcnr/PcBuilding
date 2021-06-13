using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandIdle : MonoBehaviour
{
    bool animator = false;
    bool stopper = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("yo");
        animator = false;
        stopper = false;
        StartCoroutine(idleAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        if (stopper)
        {


            if (animator)
            {
                transform.Rotate(new Vector3(0f, 0f, 20f) * 0.003f);

            }
            else
            {
                transform.Rotate(new Vector3(0f, 0f, -20) * 0.003f);

            }

        }
    }

    void OnEnabled(){
        StartCoroutine(idleAnimation());
        

    }

    void OnDisabled(){
        StopCoroutine(idleAnimation());

    }
    public IEnumerator idleAnimation()
    {

        while (true)
        {
            stopper = true;
            animator = true;
            yield return new WaitForSeconds(4);

            stopper = false;
            yield return new WaitForSeconds(4);
            stopper = true;
            animator = false;
            yield return new WaitForSeconds(4);
        }





    }
}
