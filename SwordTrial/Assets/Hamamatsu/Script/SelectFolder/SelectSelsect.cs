using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン切り替えのため

public class SelectSelsect : MonoBehaviour
{
    public enum SelectNum
    {
        kStart, //スタート
        kOption,//説明
        kEnd,   //終了
    }

    private bool m_isSelect;        //連続
    private SelectNum m_selectNum;  //選択

    // Start is called before the first frame update
    void Start()
    {
        //変数初期化
        m_isSelect = false;
        m_selectNum = SelectNum.kStart;
    }

    // Update is called once per frame
    void Update()
    {
        //スティックの入力値を格納
        float input = Input.GetAxis("Vertical");

        if (input <= -0.5f && !m_isSelect)
        {
            m_isSelect = true;
            m_selectNum = SelectNum.kEnd;
            Debug.Log("end");
        }
        else m_isSelect = false;



        if (input >= 0.5f && !m_isSelect)
        {
            m_isSelect = true;
            m_selectNum = SelectNum.kStart;
            Debug.Log("start");
        }
        else m_isSelect = false;


        //長押しを回避するよう
        if (input >= -0.1f && input <= 0.1f)
        {
            m_isSelect = false;
        }

        //Bボタンを押したら
        if (Input.GetButton("Bbutton"))
        {
            //前のシーンに戻る
            SceneManager.LoadScene("TitleScene");
        }


        //Aボタンを押したら
        if (Input.GetButton("Abutton") && m_selectNum == SelectNum.kStart)
        {
            //セレクトシーンに移行
            SceneManager.LoadScene("GameScene");
        }


    }
}
