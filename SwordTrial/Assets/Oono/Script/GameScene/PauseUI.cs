using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : UIOperationBase
{
    public enum SelectNum
    {
        kBack, //戻す
        kTitleBack,   //タイトルに戻る
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

    // Update is called once per frame
    void Update()
    {
        UpdateFunction();
        PauseUpdate();
    }
    /// <summary>
    /// ポーズ画面の処理
    /// </summary>
    private void PauseUpdate()
    {
        //ボタンを押した処理
        PressButton();

        if (m_isPress && m_selectNum == (int)SelectNum.kBack)
        {
            m_selectItem[(int)SelectNum.kBack] = true;
            SlectUIColorChenge();
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kTitleBack)
        {
            //説明や音声の調整とかできるようなウィンドウを展開
            Debug.Log("説明書開く");
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
