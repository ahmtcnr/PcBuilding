using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fillProgress : MonoBehaviour
{
    private Text filledText;
    private GameObject asd;
    private int progressCounter=0;

    [SerializeField] GameObject[] makeProgression;
    void Start(){
        filledText = GameObject.Find("filledText").GetComponent<Text>();
        asd=GameObject.Find("filledText");
        makeProgression[0].SetActive(true);
    }
    public void fillText(){
        
        filledText.text+="_";
        progressCounter++;
        switch (progressCounter)
        {
            
            case 1: makeProgression[1].SetActive(true);
            break;
            case 2: makeProgression[2].SetActive(true);
            break;
            case 3: makeProgression[3].SetActive(true);
            break;
            
        }
        
    }

    public void makeAnim(){
        StartCoroutine(fillAnim());

    }

    public IEnumerator fillAnim(){
        asd.SetActive(false);
        yield return new WaitForSeconds(0.6f);
        asd.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        asd.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        asd.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        asd.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        asd.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        
    }

}
