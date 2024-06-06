using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private int m_countDownMinutes = 3;
    private float m_countDownSeconds;
    private Text m_timerText;

    // Start is called before the first frame update
    void Start()
    {
        m_timerText = GetComponent<Text>();
        m_countDownSeconds = m_countDownMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        //秒を減らす
        

        //タイマーがゼロになったら
        if(m_countDownSeconds <= 0)
        {
            //ゲームオーバーシーンに移行

        }
    }
}
