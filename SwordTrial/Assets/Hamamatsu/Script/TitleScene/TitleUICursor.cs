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
        if (Input.GetButtonDown("Bbutton") && m_selectNum == (int)SelectNum.kStart)
        {
            m_selectItem[(int)SelectNum.kStart] = true;
        }
        else if (Input.GetButtonDown("Bbutton") && m_selectNum == (int)SelectNum.kOption)
        {
            //説明や音声の調整とかできるようなウィンドウを展開
            Debug.Log("説明書開く");
        }
        else if (Input.GetButtonDown("Bbutton") && m_selectNum == (int)SelectNum.kEnd)
        {
            //ゲーム終了させる
            //End();
            Debug.Log("ゲーム終了");
        }
    }
}
