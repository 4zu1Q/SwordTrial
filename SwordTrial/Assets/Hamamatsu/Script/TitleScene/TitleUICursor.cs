//タイトル画面のカーソルの操作

using UnityEngine;

public class TitleUICursor : UIOperationBase
{
    public enum SelectNum
    {
        kStart, //スタート
        kOption,//オプション
        kEnd,   //終了
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
            m_fade.m_isFading = false;
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
