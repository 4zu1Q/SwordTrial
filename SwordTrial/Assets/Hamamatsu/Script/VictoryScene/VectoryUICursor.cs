//勝利画面のカーソル操作

using UnityEngine;
using UnityEngine.SceneManagement;

public class VectoryUICursor : UIOperationBase
{
    public enum SelectNum
    {
        KRetry, //スタート
        kHome,//オプション
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
        if (Input.GetButton("Bbutton") && m_selectNum == (int)SelectNum.KRetry)
        {
            //セレクトシーンに移行
            SceneManager.LoadScene("GameScene");
        }
        else if (Input.GetButton("Bbutton") && m_selectNum == (int)SelectNum.kHome)
        {
            //説明や音声の調整とかできるようなウィンドウを展開
            SceneManager.LoadScene("TitleScene");

        }
    }
}
