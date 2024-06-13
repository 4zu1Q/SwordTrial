//タイマー処理

using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // 1分の長さ
    private const float m_oneMinute = 60;

    //カウントダウン分
    [SerializeField] public static int m_countDownMinutes = 3;
    //カウントダウン秒(float)
    [SerializeField] private float m_countDownSeconds = 0;
    //カウントダウン秒(int)
    public static int m_countIntSeconds = 0;
    //現在の時間を表示するテキスト
    private Text m_timerText;

    void Start()
    {
        m_countDownMinutes = 3;
        m_timerText = GameObject.Find("TimerText").GetComponent<Text>();
    }

    void Update()
    {
        //秒を減らす
        CountDown();

        m_countIntSeconds = IntConvert(m_countDownSeconds);

        if (m_countDownMinutes <= 0 && m_countDownSeconds <= 0)
        {
            m_timerText.text = string.Format("Time 00：00");
        }
        else 
        {
            m_timerText.text = string.Format("Time " + m_countDownMinutes + "：" + m_countIntSeconds);
        }
        


        //タイマーがゼロになったら
        if (m_countDownSeconds <= 0)
        {
            //ゲームオーバーシーンに移行

        }
    }

    /// <summary>
    /// カウントダウンの処理
    /// </summary>
    private void CountDown()
    {
        // タイムオーバーになると処理を止める
        //if(m_countDownMinutes < 0 && m_countDownSeconds < 0)
        //{
        //    m_countDownMinutes = 0; 
        //    m_countDownSeconds = 0;
        //    return;
        //}
        //else
        //{
            
        //}

        //カウントを減らす
        m_countDownSeconds -= Time.deltaTime;

        //分を更新
        if (m_countDownSeconds <= 0 && m_countDownMinutes >= 1)
        {
            m_countDownMinutes -= 1;
            m_countDownSeconds = m_oneMinute;
        }
    }

    /// <summary>
    /// int型に変換
    /// </summary>
    private int IntConvert(float floatNum)
    {
        int result = 0;

        result = Mathf.FloorToInt(floatNum);

        return result;
    }
}
