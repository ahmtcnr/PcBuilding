using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectObject : MonoBehaviour
{
    
    float mouseSens = 100f;
    float rotationSpeed = 2f;

    GameObject Inspecter;

    public List<GameObject> selectedPrefabs;
    void Start()
    {
        Inspecter = GameObject.Find("InspectObject");
    }

    
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime*rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime*rotationSpeed;

        this.transform.Rotate(mouseY,mouseX,0,Space.World);
    }
}
