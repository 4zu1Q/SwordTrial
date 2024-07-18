using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ResultImg : MonoBehaviour
{
    [SerializeField] private Image m_img;//画像の取得
    private float m_imgAnimTime;//画像のアニメーションにかける時間
    private Vector3 m_defaultScale;//デフォルトの画像のサイズ
    [SerializeField]private Vector3 m_chengeScale;// 画像のサイズ
    private float m_colorTime;// 色のフェードにかける時間
    // Start is called before the first frame update
    void Start()
    {

        ImgAnim();
        ImgColorChenge();
    }
    /// <summary>
    /// 画像のサイズ変更処理
    /// </summary>
    private void ImgAnim()
    {
        // アニメーションの時間指定
        m_imgAnimTime = 2.0f;
        // デフォルトの画像の大きさを取得
        m_defaultScale = m_img.transform.localScale;
        // 画像の大きさを変更する
        m_img.transform.localScale = m_chengeScale;
        // 画像をイージングを使用し大きさを変更する
        m_img.transform.DOScale((m_defaultScale), m_imgAnimTime).SetEase(Ease.InOutSine);

    }
    /// <summary>
    /// 画像の色にフェードをかける処理
    /// </summary>
    private void ImgColorChenge()
    {
        // アニメーションの時間指定
        m_colorTime = 1.5f;
        // 色(アルファ値)を0にする
        Color color = Color.white;
        color.a = 0;
        m_img.color = color;
        // 画像のフェード処理
        m_img.DOFade(1, m_colorTime).SetEase(Ease.InOutQuint);
    }

}
