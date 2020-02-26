using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/*
UnitNo---初期コスト------初期CpSは
1, 15,            1
2, 100,           10
3, 1,100,         80
4, 12,000,        470
5, 130,000,       2,600
6, 1,400,000,     14,000
7, 20,000,000,    78,000
8, 330,000,000,   440,000
9, 5,100,000,000, 2,600,000
 */
public class GameOverButtonClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] int unitNumber;
    public GameObject UnitText;
    //public ulong unitCpS;         // このUnitのCookie Per Second
    //private const float priceIncrease = 1.15f;
    //private ulong unitNum = 0; // このUnitが出ている個数
    public double price;    //　現在の価格、Inspectorからは最初の価格を設定
    //public Text numText;  // 今のこのUnitの個数
    //public Text priceText;  // 今のこのUnitの価格
    public GameObject cookie; // CookieQuantityManagerがアタッチされたcokkieのオブジェクト
    public GameObject clearTextObject;

    public AudioClip faultSound;
    public AudioClip clickSound;
    private AudioSource audioSource;

    void start(){
        //price = firstPrice;
        //Debug.Log(price);
        // startメソッド実行されない, なぜ!
        //priceText = priceText.GetComponent<Text>();
        //priceText.text = ("" + price.ToString("N0"));
    }
    void Update(){
        if(cookie.GetComponent<CookieQuantityManager>().ReturnCookiesQuantity() < (ulong)price){
            // 所持クッキー < 価格だったらボタンを赤色
            this.GetComponent<Image>().color = new Color(190f/255f, 60f/255f, 60f/255f);
        }
        else{
            // 黄色に
            this.GetComponent<Image>().color = new Color(255f/255f, 212f/255f, 69f/255f);
        }
    }

    // オブジェクトの範囲内にマウスポインタが入った時に呼び出される
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log(name);
        UnitText.SetActive(true);
    }

    // オブジェクトの範囲内からマウスポインタが出た際に呼び出されます。
    public void OnPointerExit( PointerEventData eventData )
    {
        UnitText.SetActive(false);
    }
 
    // button側のInspectorからこの関数を指定するのを忘れていた
    public void OnClick()
    {
        audioSource = GetComponent<AudioSource>();
        if(cookie.GetComponent<CookieQuantityManager>().ReturnCookiesQuantity() < (ulong)price){
            //this.GetComponent<Image>().color = new Color(120/255, 120/255, 120/255);
            audioSource.PlayOneShot(faultSound);
        }
        else{
        //this.GetComponent<Image>().color = new Color(255, 255, 255);
        cookie.GetComponent<CookieQuantityManager>().SubtractCookie((ulong)price);
        //cookie.GetComponent<CookieQuantityManager>().AddCpS(unitCpS);
        //Debug.Log(name + " is clicked!!!");
        //numText = numText.GetComponent<Text>();
        //priceText = priceText.GetComponent<Text>();
        //unitNum ++;
        //price *= priceIncrease;
        //numText.text = ("" + unitNum);
        //priceText.text = ("" + price.ToString("N0"));
        clearTextObject.SetActive(true);
        audioSource.PlayOneShot(clickSound);
        Time.timeScale = 0;

        
        }    
    }
}
 