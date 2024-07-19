//タイマー処理

using UnityEngine;
using UnityEngine.UI;

public class Timer : TimeBase
{
    // 1分の長さ
    private const float m_oneMinute = 60;

    //メニューの処理
    private PauseMenu m_menu;

    //カウントダウン終了フラグ
    private bool m_finishCountDown = false;

    void Start()
    {
        m_countDownMinutes = 3;
        m_menu = GetComponent<PauseMenu>();
    }

    void Update()
    {
        //秒を減らす
        CountDown();

        m_countIntSeconds = IntConvert(m_countDownSeconds);

        if (m_countDownMinutes <= 0 && m_countDownSeconds <= 0)
        {
            //カウントダウン終了
            m_finishCountDown = true;
        }
        TimeImgView();
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

    /// <summary>
    /// カウントダウン終了下かを取得
    /// </summary>
    /// <returns></returns>
    public bool GetFinishCountDown() { return m_finishCountDown; }
}
