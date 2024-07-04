//UIの操作処理

using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIOperationBase : MonoBehaviour
{
    private bool m_isSelect = false;    //連続移動を防ぐフラグ
    public int m_selectNum = 0;//選択されている番号

    public GameObject m_selectCursor;//操作するUI
    public GameObject[] m_itemUI;//選択項目のUI

    private RectTransform m_selectRectTransform;
    private RectTransform[] m_itemRectTransform;

    private Image m_selectUIImg;
    private float m_selectCursorPosX;//カーソルのポジション取得
    private int m_prevSelectNum;//前に選択した番号
    private float m_moveCursorSpeed;//カーソルの移動速度
    private bool m_isDecision;//決定を押したかどうか
    private Vector3[] m_itemDefaultRectTransform;//もともとの画像のサイズ取得
    private float m_scaleChengeSize;//変更する大きさのサイズ
    private float m_scaleChengeSpeed;//スケールを変更する時間
    private float m_scaleChengeRestoreSpeed;
    private int m_pressTime;//押したままの時間の取得
    private int m_pressTimeMax;//押したままの時間の最大値

    public bool _isUIScaleChenge = false;
    protected virtual void Start()
    {
        //変数の初期化
        m_isSelect=false;
        m_selectNum = 0;
        //配列の長さは選択項目数
        m_itemRectTransform = new RectTransform[m_itemUI.Length];
        m_itemDefaultRectTransform = new Vector3[m_itemUI.Length];
        m_selectRectTransform = m_selectCursor.GetComponent<RectTransform>();
        for (int UINum = 0; UINum < m_itemUI.Length; UINum++)
        {
            m_itemRectTransform[UINum] = m_itemUI[UINum].GetComponent<RectTransform>();
            m_itemDefaultRectTransform[UINum] = m_itemRectTransform[UINum].localScale;
        }
        m_selectUIImg = m_selectCursor.GetComponent<Image>();
        m_prevSelectNum = -1;
        m_moveCursorSpeed = 0.2f;
        m_selectCursorPosX = m_selectRectTransform.position.x;
        m_scaleChengeSize = 1.3f;
        m_scaleChengeSpeed = 1.0f;
        m_scaleChengeRestoreSpeed = 0.1f;
        m_pressTime = 0;
        m_pressTimeMax = 20;

        UIScalseChengeLoop();
    }

    //Updateに呼び出す関数
    public void UpdateFunction()
    {
        ItemCursorChange();
        SelectUIPosition();
        UIScaleChengeUpdate();
    }


    /// <summary>
    /// 選択項目の変更処理
    /// </summary>
    private void ItemCursorChange()
    {
        //決定ボタンを押されていたら移動できなくする
        if (m_isDecision) { return; }
        //前の選んでいた番号の取得
        m_prevSelectNum = m_selectNum;

        //スティックの入力値を格納
        float LeftStick = Input.GetAxis("Vertical");

        //カーソルを下に動かす
        if (LeftStick <= -0.5f)
        {
            if(!IsPressButtom() && m_isSelect) return;
            m_isSelect = true;
            m_selectNum++;
            if (m_selectNum > m_itemUI.Length - 1)
            {
                m_selectNum = 0;
            }
        }
        //カーソルを上に動かす
        else if (LeftStick >= 0.5f)
        {
            if (!IsPressButtom() && m_isSelect) return;
            m_isSelect = true;
            m_selectNum--;
            if (m_selectNum < 0)
            {
                m_selectNum = m_itemUI.Length - 1;
            }
        }
        else if (LeftStick >= -0.1f && LeftStick <= 0.1f)
        {
            m_isSelect = false;
            m_pressTime = 0;
        }
    }
    /// <summary>
    /// ボタンおしっぱの時の処理
    /// </summary>
    /// <returns>おしっぱで一定時間経過したかどうか</returns>
    private bool IsPressButtom()
    {
        m_pressTime++;
        if(m_pressTime >m_pressTimeMax)
        {
            m_pressTime = 0;
            return true;
        }
        return false;
    }

    /// <summary>
    /// 操作するUIの座標処理
    /// </summary>
    private void SelectUIPosition()
    {
        // 前のフレームと選んでいたものが異なるときのみ処理を行う
        if (m_selectNum != m_prevSelectNum)
        {
            //指定した座標にm_moveCursorSpeed秒かけて移動する
            m_selectRectTransform.transform.DOMove(new Vector3(m_selectCursorPosX,
                m_itemRectTransform[(int)m_selectNum].position.y, 0), m_moveCursorSpeed).SetEase(Ease.OutCubic);
        }
    }
    /// <summary>
    /// UIの画像のスケールの更新処理
    /// </summary>
    private void UIScaleChengeUpdate()
    {
        // 前のフレームと選んでいたものが異なるときのみ処理を行う
        if (m_selectNum != m_prevSelectNum)
        {
            //前に選択していた画像の処理を止める
            m_itemRectTransform[(int)m_prevSelectNum].DOKill();
            //m_itemRectTransform[(int)m_prevSelectNum].transform.localScale = m_itemDefaultRectTransform[m_prevSelectNum];
            m_itemRectTransform[(int)m_prevSelectNum].DOScale((m_itemDefaultRectTransform[m_prevSelectNum]), m_scaleChengeRestoreSpeed)
                .SetEase(Ease.InOutSine);
            UIScalseChengeLoop();
        }
    }
    /// <summary>
    /// 選んでいる画像が拡大縮小する処理
    /// </summary>
    private void UIScalseChengeLoop()
    {
        if(_isUIScaleChenge) { return; }
        //指定した座標にm_moveCursorSpeed秒かけて移動する
        m_itemRectTransform[(int)m_selectNum].transform.DOScale(new Vector3(m_scaleChengeSize,
            m_scaleChengeSize, 0), m_scaleChengeSpeed)
            .SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
    }
    /// <summary>
    /// 決定を押されたときに色の変更処理
    /// </summary>
    public void SlectUIColorChenge(bool isPress)
    {
        if(isPress && m_selectUIImg.color != Color.red)
        { 
            m_selectUIImg.color = Color.red;
        }
        else if (!isPress && m_selectUIImg.color != Color.white)
        {
            m_selectUIImg.color = Color.white;
        }
    }
    /// <summary>
    /// 決定を押したかどうかを取得する
    /// </summary>
    /// <param name="decison"></param>
    public void DecisionUpdate(bool decison)
    {
        m_isDecision = decison;
    }
}
