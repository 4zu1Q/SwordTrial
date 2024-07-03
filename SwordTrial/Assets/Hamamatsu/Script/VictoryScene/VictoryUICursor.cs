//勝利画面のカーソル操作

using UnityEngine;

public class VictoryUICursor : UIOperationBase
{
    public enum SelectNum
    {
        KRetry, //スタート
        kHome,//タイトル
        kMaxNum
    }

    //選択されている項目
    public bool[] m_selectItem;
    private bool m_isPress;

    protected override void Start()
    {
        base.Start();
        m_selectItem = new bool[(int)SelectNum.kMaxNum];
        m_isPress = false;
    }

    void Update()
    {
        UpdateFunction();
        SceneTransition();
    }

    /// <summary>
    /// シーン遷移
    /// </summary>
    private void SceneTransition()
    {
        //ボタンを押した処理
        PressButton();
        //Aボタンを押したら
        if (m_isPress && m_selectNum == (int)SelectNum.KRetry)
        {
            m_selectItem[(int)SelectNum.KRetry] = true;
            SlectUIColorChenge();
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kHome)
        {
            m_selectItem[(int)SelectNum.kHome] = true;
            SlectUIColorChenge();
        }
    }
    /// <summary>
    /// ボタンを押したときの処理
    /// </summary>
    private void PressButton()
    {
        //ボタンを押した処理
        if (Input.GetButtonDown("Bbutton"))
        {
            m_isPress = true;
        }

        DecisionUpdate(m_isPress);
    }
}
