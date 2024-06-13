//UIの操作処理

using UnityEngine;

public class UIOperationBase : MonoBehaviour
{
    private bool m_isSelect = false;    //連続移動を防ぐフラグ
    public int m_selectNum = 0;//選択されている番号

    public GameObject m_selectCursor;//操作するUI
    public GameObject[] m_itemUI;//選択項目のUI

    private RectTransform m_selectRectTransform;
    private RectTransform[] m_itemRectTransform;

    public void Start()
    {
        //変数の初期化
        m_isSelect=false;
        m_selectNum = 0;
        //配列の長さは選択項目数
        m_itemRectTransform = new RectTransform[m_itemUI.Length];
        m_selectRectTransform = m_selectCursor.GetComponent<RectTransform>();

        for (int UINum = 0; UINum < m_itemUI.Length; UINum++)
        {
            m_itemRectTransform[UINum] = m_itemUI[UINum].GetComponent<RectTransform>();
        }
    }

    //Updateに呼び出す関数
    public void UpdateFunction()
    {
        ItemCursorChange();
        SelectUIPosition();
    }


    /// <summary>
    /// 選択項目の変更処理
    /// </summary>
    public void ItemCursorChange()
    {
        //スティックの入力値を格納
        float LeftStick = Input.GetAxis("Vertical");

        //カーソルを下に動かす
        if (LeftStick <= -0.5f && !m_isSelect)
        {
            m_isSelect = true;
            m_selectNum++;
            if (m_selectNum > m_itemUI.Length - 1)
            {
                m_selectNum = 0;
            }
        }
        //カーソルを上に動かす
        else if (LeftStick >= 0.5f && !m_isSelect)
        {
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
        }
    }

    /// <summary>
    /// 操作するUIの座標処理
    /// </summary>
    public void SelectUIPosition()
    {
        //m_selectRectTransform.position = m_itemRectTransform[(int)m_selectNum].position;
        m_selectRectTransform.position = new Vector3(m_selectRectTransform.position.x,
            m_itemRectTransform[(int)m_selectNum].position.y, 0);
    }
}
