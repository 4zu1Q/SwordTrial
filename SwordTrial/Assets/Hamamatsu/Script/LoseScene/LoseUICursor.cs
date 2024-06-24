//敗北画面のカーソル操作

using UnityEngine;

public class LoseUICursor : UIOperationBase
{
    public enum SelectNum
    {
        kContinue, //コンテニュー
        kHome,//ホームへ
        kMaxNum
    }

    //選択されている項目
    public bool[] m_selectItem;

    protected override void Start()
    {
        base.Start();
        m_selectItem = new bool[(int)SelectNum.kMaxNum];
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
        //Aボタンを押したら
        if (Input.GetButton("Bbutton") && m_selectNum == (int)SelectNum.kContinue)
        {
            m_selectItem[(int)SelectNum.kContinue] = true;
        }
        else if (Input.GetButton("Bbutton") && m_selectNum == (int)SelectNum.kHome)
        {
            m_selectItem[(int)SelectNum.kHome] = true;
        }
    }
}
