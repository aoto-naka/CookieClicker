using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDestroy : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickDestory(){
        Destroy(gameObject);
    }
    public void OnClickResetTimeScale(){
        Time.timeScale = 1;
    }
    public void OnClickNonActive(){
        this.gameObject.SetActive(false);
    }
    public void OnClickStopTime(){
        Time.timeScale = 0;
    }
    public void playPageSE(){
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clickSound);
    }
}
