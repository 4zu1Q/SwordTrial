//メインシーンのシーン遷移

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneTransition : MonoBehaviour
{
    void Update()
    {
        DebugSceneTransition();
    }

    /// <summary>
    /// デバッグ用シーン遷移
    /// </summary>
    private void DebugSceneTransition()
    {
        //Aボタンを押したら
        if (Input.GetButton("Abutton"))
        {
            //ゲームシーンに移動
            SceneManager.LoadScene("WinScene");
        }
        //Bボタンを押したら
        else if (Input.GetButton("Bbutton"))
        {
            //セレクトシーンに移行
            SceneManager.LoadScene("LoseScene");
        }
    }



}
