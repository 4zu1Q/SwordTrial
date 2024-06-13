//タイトル画面のUIの操作

using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIOperation : MonoBehaviour
{
    public enum SelectNum
    {
        kStart, //スタート
        kOption,//オプション
        kEnd,   //終了
    }

    private bool m_isSelect;        //連続
    private SelectNum m_selectNum;  //選択

    [SerializeField] private GameObject m_selectUI;//操作するUI
    [SerializeField] private GameObject[] m_itemUI;//選択項目のUI

    private RectTransform m_selectRectTransform;
    private RectTransform[] m_itemRectTransform;

    //初期化
    void Start()
    {
        //変数初期化
        m_isSelect= false;
        m_selectNum = SelectNum.kStart;

        m_itemRectTransform = new RectTransform[m_itemUI.Length];//配列の長さは選択項目数

        m_selectRectTransform = m_selectUI.GetComponent<RectTransform>();


        for(int UInum = 0; UInum < m_itemUI.Length; UInum++)
        {
            m_itemRectTransform[UInum] = m_itemUI[UInum].GetComponent<RectTransform>();
        }
    }

    //処理
    void Update()
    {
        ItemChange();

        SelectUIPosition();
        



        //Aボタンを押したら
        if (Input.GetButton("Abutton") && m_selectNum == SelectNum.kStart)
        {
            //セレクトシーンに移行
            SceneManager.LoadScene("SelectScene");
        }
        else if (Input.GetButton("Abutton") && m_selectNum == SelectNum.kOption)
        {
            //説明や音声の調整とかできるようなウィンドウを展開
            Debug.Log("説明書開く");

        }
        else if (Input.GetButton("Abutton") && m_selectNum == SelectNum.kEnd)
        {
            //ゲーム終了させる
            //End();
            Debug.Log("ゲーム終了");
        }

    }

    /// <summary>
    /// 選択項目の変更処理
    /// </summary>
    private void ItemChange()
    {
        //スティックの入力値を格納
        float LeftStick = Input.GetAxis("Vertical");

#if true

        //カーソルを下に動かす
        if(LeftStick <= -0.5f && !m_isSelect)
        {
            m_isSelect = true;
            m_selectNum++;
            if(m_selectNum > SelectNum.kEnd) 
            {
                m_selectNum = SelectNum.kStart;
            }
        }
        //カーソルを上に動かす
        else if(LeftStick >= 0.5f && !m_isSelect)
        {
            m_isSelect=true;
            m_selectNum--;
            if(m_selectNum < SelectNum.kStart)
            {
                m_selectNum = SelectNum.kEnd;
            }
        }
        else if(LeftStick >= -0.1f && LeftStick <= 0.1f)
        {
            m_isSelect=false;
        }

#else

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

#endif
    }


    /// <summary>
    /// 操作するUIの座標処理
    /// </summary>
    private void SelectUIPosition()
    {
        //m_selectRectTransform.position = m_itemRectTransform[(int)m_selectNum].position;
        m_selectRectTransform.position = new Vector3(m_selectRectTransform.position.x, 
            m_itemRectTransform[(int)m_selectNum].position.y, 0);
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
