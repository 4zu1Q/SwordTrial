// リザルト画面の結果を表示する処理

using UnityEngine;

public class TimerResult : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(Timer.m_countDownMinutes + "：" + Timer.m_countIntSeconds);
    }
}
