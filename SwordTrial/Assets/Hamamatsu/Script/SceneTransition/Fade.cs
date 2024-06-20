//フェード処理

using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image m_image;//フェードの画像
    //フェードをしているかどうか
    public bool m_isFading = true;
    public bool m_fadeEnd = false;

    //フェードの画像の透明度
    private byte m_colorA = 0;
    //フェードインスピード
    private byte m_fadeInSpeed = 0;
    //フェードイン終了時の透明度
    private float m_fadeInFinish = 0.01f;
    //フェードアウトスピード
    private byte m_fadeOutSpeed = 0;
    //フェードアウト終了時の透明度
    private float m_fadeOutFinish = 0.99f;



    void Start()
    {
        m_image = GetComponent<Image>();
        m_isFading = true;
        m_colorA = 255;
    }

    void Update()
    {
        FadeUpdate();
    }

    /// <summary>
    /// フェード処理
    /// </summary>
    private void FadeUpdate()
    {
        FadeColor();

        // フェードイン.
        if (m_isFading)
        {
            FadeIn();
        }
        // フェードアウト.
        else
        {
            FadeOut();
        }
    }

    /// <summary>
    /// フェードイン
    /// </summary>
    private void FadeIn()
    {
        //透明度が0の時はスキップ
        if(m_image.color.a <= m_fadeInFinish)
        {
            m_colorA = 0;

            return;
        }
        m_colorA -= m_fadeInSpeed;
    }

    /// <summary>
    /// フェードアウト
    /// </summary>
    private void FadeOut()
    {
        if(m_image.color.a >= m_fadeOutFinish)
        {
            m_colorA = 255;
            m_fadeEnd = true;
            return;
        }
        m_colorA += m_fadeOutSpeed;
    }

    /// <summary>
    /// 現在のフェード画面の色
    /// </summary>
    private void FadeColor()
    {
        m_image.color = new Color32(0, 0, 0, m_colorA);
    }

}
