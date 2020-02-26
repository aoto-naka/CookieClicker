using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// クッキーにアタッチ
public class CookieQuantityManager : MonoBehaviour
{

    [SerializeField] ulong cookiesQuantity;
    [SerializeField] double wholeCpS = 0;
    public int onStage = 0; // 現在どの施設まで作っているか示す。0~6
    public Text quantityText;
    public Text wholeCpSText;
    float timer;

    public AudioClip clickSound;
    private AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1){
            timer = 0;
            //　↓くそコードいずれ直す
            SubtractCookie((ulong)(-(int)wholeCpS));       
        }
    }
    public void OnClick(){
        string key;

        cookiesQuantity ++;
        key = cookiesQuantity.ToString("000,000");
        quantityText = quantityText.GetComponent<Text>();
        quantityText.text = key + "\nCookies";
        //Debug.Log(name + " is clicked");
        audioSource.PlayOneShot(clickSound);
    }
    public void SubtractCookie(ulong a){
        string key;

        cookiesQuantity -= a;
        key = cookiesQuantity.ToString("000,000");
        quantityText = quantityText.GetComponent<Text>();
        quantityText.text = key + "\nCookies";
    }
    public void AddCpS(ulong a){
        wholeCpS += a;
        wholeCpSText = wholeCpSText.GetComponent<Text>();
        wholeCpSText.text = wholeCpS + " CpS";
    }
    public int ReturnStage(){
        return onStage;
    }
    public void SetStage(int i){
        onStage = i;
    }
    public ulong ReturnCookiesQuantity(){
        return cookiesQuantity;
    }
    

}
