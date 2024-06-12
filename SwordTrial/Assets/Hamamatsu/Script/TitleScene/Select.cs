using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン切り替えのため


public class Select : MonoBehaviour
{
    public enum SelectNum
    {
        kStart, //スタート
        kEnd,   //終了
    }

    private SelectNum m_selectNum;  //選択

    //初期化
    void Start()
    {
        m_selectNum = SelectNum.kStart;
    }

    //処理
    void Update()
    {
        //シーン名があれば切り替える
        //if (m_sceneName != "")
        //{
        //}

        //float i = Input.GetAxis("Vertical");

        //if (i && m_selectNum == SelectNum.kStart)
        //{

        //}

            //Aボタンを押したら
            if (Input.GetButton("Abutton") && m_selectNum == SelectNum.kStart)
            {
                SceneManager.LoadScene("SelectScene");
            }
            else if (Input.GetButton("Abutton") && m_selectNum == SelectNum.kEnd)
            {
            //ゲーム終了
            End();
            }

    }

    void End()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif

    }

}
