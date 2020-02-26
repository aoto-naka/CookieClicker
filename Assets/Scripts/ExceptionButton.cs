using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExceptionButton : MonoBehaviour
{
    public GameObject[] exceptionPanels = new GameObject[7];
    // Start is called before the first frame update
    void Start()
    {
        OnClickException();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickException(){
        int i;
        for(i=0; i<7; i++){
            exceptionPanels[i].SetActive(true);
        }
    }

}

