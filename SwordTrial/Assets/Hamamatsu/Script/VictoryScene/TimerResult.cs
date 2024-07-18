// リザルト画面の結果を表示する処理

using UnityEngine;
using UnityEngine.UI;

public class TimerResult : MonoBehaviour
{
    //時間の計測結果を表示するテキスト
    [SerializeField] private Sprite[] m_timeNum;//数字の画像取得
    [SerializeField] private Image[] m_timeImage;//表示する時間の画像取得

    void Start()
    {

    }

    void Update()
    {
        TimeResultView();
    }

    /// <summary>
    /// 勝利した時の時間を表示
    /// </summary>
    private void TimeResultView()
    {
        // 残り時間が10秒より多ければ
        if(Timer.m_countIntSeconds >= 10)
        {
            var num1 = Timer.m_countIntSeconds / 10;
            var num2 = Timer.m_countIntSeconds - num1 * 10;
            // 時間の画像変更
            TimeImageChenge(num1, num2);
        }
        //それ以外だったら
        else
        {
            // 時間の画像変更
            TimeImageChenge(0, Timer.m_countIntSeconds);
        }
    }
    /// <summary>
    ///  時間の画像の変更処理
    /// </summary>
    /// <param name="num1">秒数の10の位の数値</param>
    /// <param name="num2">秒数の1の位の数値</param>
    private void TimeImageChenge(int num1, int num2)
    {
        m_timeImage[0].sprite = m_timeNum[Timer.m_countDownMinutes];
        m_timeImage[1].sprite = m_timeNum[num1];
        m_timeImage[2].sprite = m_timeNum[num2];
    }
}