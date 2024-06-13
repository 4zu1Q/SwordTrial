//勝利画面のシーン遷移処理

using UnityEngine;
using UnityEngine.SceneManagement; //シーン切り替えのため

public class WinSceneTransition : MonoBehaviour
{
    void Update()
    {
        //Aボタンを押したら
        if (Input.GetButton("Abutton"))
        {
            //ゲームシーンに移動
            SceneManager.LoadScene("GameScene");
        }
        else if (Input.GetButton("Abutton"))
        {
            //セレクトシーンに移行
            SceneManager.LoadScene("TitleScene");
        }
    }
}
