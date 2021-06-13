using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dolap : MonoBehaviour
{
    public GameObject player;
    public GameObject dolap;
    private bool checkCollision = false;
    private bool isDolapActive = false;
    [SerializeField] private GameObject dolapInfo;
    public GameObject graphCard;
    private bool isBuy = false;

   

    LeftHandIdle leftHandInstance;
    fillProgress fillProgressInstance;

    void Start()
    {
        leftHandInstance = GameObject.Find("leftHand").GetComponent<LeftHandIdle>();
        fillProgressInstance = GameObject.Find("msgFill").GetComponent<fillProgress>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isDolapActive && Input.GetKeyDown("r"))
        {
            if (isBuy)
            {
                Instantiate(graphCard, new Vector3(13.5f, 2, -8), Quaternion.Euler(0,-90,0));
                
                isBuy = false;
                fillProgressInstance.fillText();
            }
            Cursor.lockState = CursorLockMode.Locked;
            
            player.SetActive(true);
            dolap.SetActive(false);
            leftHandInstance.StartCoroutine(leftHandInstance.idleAnimation());
            
            isDolapActive = false;
            fillProgressInstance.makeAnim();

        }
        if (Input.GetKeyDown("e") && checkCollision)
        {
            
            Cursor.lockState = CursorLockMode.None;
            leftHandInstance.StopAllCoroutines();
            player.SetActive(false);
            dolap.SetActive(true);
            isDolapActive = true;


        }




    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            dolapInfo.SetActive(true);
            checkCollision = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dolapInfo.SetActive(false);
            checkCollision = false;


        }

    }


    public void buyObject()
    {
        isBuy = true;


    }
}
