using UnityEngine;
using UnityEngine.UI;

public class TimeBase : MonoBehaviour
{
    //カウントダウン分
    [SerializeField] public static int m_countDownMinutes = 3;
    //カウントダウン秒(float)
    [SerializeField] public float m_countDownSeconds = 0;
    //カウントダウン秒(int)
    public static int m_countIntSeconds = 0;
    //時間の計測結果を表示するテキスト
    [SerializeField] private Sprite[] m_timeNum;//数字の画像取得
    [SerializeField] private Image[] m_timeImage;//表示する時間の画像取得
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 勝利した時の時間を表示
    /// </summary>
    public void TimeImgView()
    {
        // 残り時間が10秒より多ければ
        if (m_countIntSeconds >= 10)
        {
            var num1 = m_countIntSeconds / 10;
            var num2 = m_countIntSeconds - num1 * 10;
            // 時間の画像変更
            TimeImageChenge(num1, num2);
        }
        //それ以外だったら
        else
        {
            // 時間の画像変更
            TimeImageChenge(0, m_countIntSeconds);
        }
    }
    /// <summary>
    ///  時間の画像の変更処理
    /// </summary>
    /// <param name="num1">秒数の10の位の数値</param>
    /// <param name="num2">秒数の1の位の数値</param>
    private void TimeImageChenge(int num1, int num2)
    {
        m_timeImage[0].sprite = m_timeNum[m_countDownMinutes];
        m_timeImage[1].sprite = m_timeNum[num1];
        m_timeImage[2].sprite = m_timeNum[num2];
    }
}
