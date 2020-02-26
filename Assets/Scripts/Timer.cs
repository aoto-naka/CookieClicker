using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerText = timerText.GetComponent<Text>();
        time += Time.deltaTime;
        timerText.text = (time.ToString("F2") + "秒");
    }
}
