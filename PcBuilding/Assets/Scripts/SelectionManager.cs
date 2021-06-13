using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTarget = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private GameObject correctObj;
    [SerializeField] private GameObject graphCard;

    [SerializeField] private GameObject errorCnv;
    private Transform _selection;

    GameObject newObject;

    private bool isPut=true;
    private void Update()
    {

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            
            var selencionRenderer = selection.GetComponent<Renderer>();
            if (selection.CompareTag(selectableTarget))
            {

                if (Input.GetMouseButton(0) && isPut)
                {
                    if (correctObj.transform==hit.transform)
                    {
                        newObject = Instantiate(graphCard, new Vector3(correctObj.transform.position.x+0.1f,correctObj.transform.position.y,correctObj.transform.position.z+0.025f), Quaternion.Euler(90,90,0)) as GameObject; 
                        newObject.transform.localScale = new Vector3(0.003f,0.003f,0.003f);
                        isPut = false;
                        
                    }else
                    {
                        Transform falseObj;
                        falseObj = hit.transform;
                        newObject = Instantiate(graphCard, new Vector3(falseObj.transform.position.x+0.1f,falseObj.transform.position.y,falseObj.transform.position.z+0.025f), Quaternion.Euler(90,90,0)) as GameObject; 
                        newObject.transform.localScale = new Vector3(0.003f,0.003f,0.003f);
                        isPut = false;
                        falseTrigger();
                        
                        
                    }
                    
                }
                if (selencionRenderer != null)
                {
                    selencionRenderer.material = highlightMaterial;
                }
                _selection = selection;
            }
        }

    }

    private void falseTrigger()
    {
        StartCoroutine(idleAnimation());
        Debug.Log("dddd");
    }


    public IEnumerator idleAnimation(){

        yield return new WaitForSeconds(0.5f); 
        errorCnv.SetActive(true);
        yield return new WaitForSeconds(0.5f); 
        errorCnv.SetActive(false);
        yield return new WaitForSeconds(0.5f); 
        errorCnv.SetActive(true);
        yield return new WaitForSeconds(0.5f); 
        errorCnv.SetActive(false);
        


        Destroy(newObject);
        isPut=true;
        
        

    }
}
