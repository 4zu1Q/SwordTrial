// リザルト画面の結果を表示する処理

using UnityEngine;
using UnityEngine.UI;

public class TimerResult : MonoBehaviour
{
    //時間の計測結果を表示するテキスト
    [SerializeField] private Text m_resultText;

    void Start()
    {

    }

    void Update()
    {
        TimeResultView();
        //Debug.Log(Timer.m_countDownMinutes + "：" + Timer.m_countIntSeconds);
    }

    /// <summary>
    /// 勝利した時の時間を表示
    /// </summary>
    private void TimeResultView()
    {
        Debug.Log(Timer.m_countIntSeconds);
        m_resultText.text = "Time:" + Timer.m_countDownMinutes + ":" + Timer.m_countIntSeconds;
    }
}