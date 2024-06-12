using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDebug : MonoBehaviour
{
    public enum SelectNum
    {
        kRetry, //スタート
        kOption,//説明
        kSelect,   //終了
    }

    private bool m_isSelect;        //連続
    private SelectNum m_selectNum;  //選択

    // Start is called before the first frame update
    void Start()
    {
        //変数初期化
        m_isSelect = false;
        m_selectNum = SelectNum.kRetry;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{name}");

        //スティックの入力値を格納
        float input = Input.GetAxis("Vertical");

        if (input <= -0.5f && !m_isSelect)
        {
            m_isSelect = true;
            m_selectNum = SelectNum.kSelect;
            Debug.Log("Win");
        }
        else m_isSelect = false;



        if (input >= 0.5f && !m_isSelect)
        {
            m_isSelect = true;
            m_selectNum = SelectNum.kRetry;
            Debug.Log("Lose");
        }
        else m_isSelect = false;


        //長押しを回避するよう
        if (input >= -0.1f && input <= 0.1f)
        {
            m_isSelect = false;
        }



        //Aボタンを押したら
        if (Input.GetButton("Abutton") && m_selectNum == SelectNum.kRetry)
        {
            //ゲームシーンに移動
            SceneManager.LoadScene("WinScene");
        }
        else if (Input.GetButton("Abutton") && m_selectNum == SelectNum.kSelect)
        {
            //セレクトシーンに移行
            SceneManager.LoadScene("LoseScene");
        }
    }
}
