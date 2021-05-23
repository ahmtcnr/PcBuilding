using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcInspect : MonoBehaviour
{
    public  GameObject PcPartInspect;
    Camera PlayerCam;
    void Start()
    {
        

        PlayerCam = GameObject.Find("PlayerCam").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            PlayerCam.gameObject.SetActive(false);
            PcPartInspect.SetActive(true);
            
        }
        if (Input.GetKeyUp("space"))
        {
            PcPartInspect.SetActive(false);
            PlayerCam.gameObject.SetActive(true);
        }
    }
}
