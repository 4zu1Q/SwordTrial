//タイトル画面のカーソルの操作

using UnityEngine;

public class TitleUICursor : UIOperationBase
{
    public enum SelectNum
    {
        kStart, //スタート
        kOption,//オプション
        kEnd,   //終了
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

        if (m_isPress && m_selectNum == (int)SelectNum.kStart)
        {
            m_selectItem[(int)SelectNum.kStart] = true;
            SlectUIColorChenge();
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kOption)
        {
            //説明や音声の調整とかできるようなウィンドウを展開
            Debug.Log("説明書開く");
            SlectUIColorChenge();
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kEnd)
        {
            //ゲーム終了させる
            //End();
            Debug.Log("ゲーム終了");
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
