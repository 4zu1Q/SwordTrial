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
    //メニューの処理
    private PauseMenu m_menu;

    //カウントダウン終了フラグ
    private bool m_finishCountDown = false;

    void Start()
    {
        m_countDownMinutes = 3;
        m_timerText = GameObject.Find("TimerText").GetComponent<Text>();
        m_menu = GetComponent<PauseMenu>();
    }

    void Update()
    {
        //秒を減らす
        CountDown();

        m_countIntSeconds = IntConvert(m_countDownSeconds);

        if (m_countDownMinutes <= 0 && m_countDownSeconds <= 0)
        {
            m_timerText.text = string.Format("Time 00：00");

            //カウントダウン終了
            m_finishCountDown = true;
        }
        else 
        {
            m_timerText.text = string.Format("Time " + m_countDownMinutes + ":" + m_countIntSeconds);
        }
        
    }

    /// <summary>
    /// カウントダウンの処理
    /// </summary>
    private void CountDown()
    {
        if (m_menu.GetMenu()) return;


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

    public bool GetFinishCountDown() { return m_finishCountDown; }
}
