using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン切り替えのため

public class TitleSelect : MonoBehaviour
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
