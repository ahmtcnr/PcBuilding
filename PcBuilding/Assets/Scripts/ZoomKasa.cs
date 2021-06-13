using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomKasa : MonoBehaviour
{

    public GameObject cnv;
    private bool isCollider = false;
    private bool isZoom = false,oneTime=true;
    public GameObject zoomKasa;
    public GameObject player;
    fillProgress fillProgressInstance;
    void Start()
    {
        fillProgressInstance = GameObject.Find("msgFill").GetComponent<fillProgress>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && isCollider )
        {
            player.SetActive(false);
            zoomKasa.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            
            isZoom = true;
            
        }

        if (isZoom && Input.GetKeyDown("r"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            isZoom = false;
            player.SetActive(true);
            zoomKasa.SetActive(false);
            fillProgressInstance.fillText();
            fillProgressInstance.makeAnim();
        }




    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
            cnv.SetActive(true);
            isCollider = true;
            if (oneTime)
            {
                
            fillProgressInstance.fillText();
            fillProgressInstance.makeAnim();
            oneTime=false;
            }
        }


    }
    void OnTriggerExit(Collider other){
        if (other.tag == "Player")
        {
            cnv.SetActive(false);
            isCollider = false;

        }


    }
}
