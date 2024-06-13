//敗北画面のカーソル操作

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseUICursor : UIOperationBase
{
    public enum SelectNum
    {
        kContinue, //コンテニュー
        kHome,//ホームへ
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
            //セレクトシーンに移行
            SceneManager.LoadScene("GameScene");
        }
        else if (Input.GetButton("Bbutton") && m_selectNum == (int)SelectNum.kHome)
        {
            //タイトル画面へ
            SceneManager.LoadScene("TitleScene");
        }
    }
}
