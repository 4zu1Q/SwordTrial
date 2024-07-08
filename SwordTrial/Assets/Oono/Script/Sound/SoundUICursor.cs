//サウンドの更新処理
using UnityEngine;

public class SoundUICursor : UIOperationBase
{
    public enum SelectNum
    {
        kMastar, //BGM
        kBGM, //BGM
        kSE,//SE
        kEnd,//おわる
        kMaxNum
    }

    //選択されている項目
    public bool[] m_selectItem;
    private bool m_isPress;
    public bool m_isOptionCancellation;

    protected override void Start()
    {
        base.Start();
        m_selectItem = new bool[(int)SelectNum.kMaxNum];
        m_isPress = false;
        m_isOptionCancellation = false;
    }

    void Update()
    {
        if(!m_isOptionCancellation) { return; }
        CursorTransition();
        SlectUIColorChenge(m_isPress);
        UpdateFunction();
    }

    /// <summary>
    /// シーン遷移
    /// </summary>
    private void CursorTransition()
    {
        //ボタンを押した処理
        PressButton();

        if (m_isPress && m_selectNum == (int)SelectNum.kMastar)
        {
            m_selectItem[(int)SelectNum.kMastar] = true;
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kBGM)
        {
            m_selectItem[(int)SelectNum.kBGM] = true;
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kSE)
        {
            //説明や音声の調整とかできるようなウィンドウを展開
            m_selectItem[(int)SelectNum.kSE] = true;
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kEnd)
        {
            m_isOptionCancellation = false;
            //終了させる
            Debug.Log("とじる");
        }
    }
    /// <summary>
    /// ボタンを押したときの処理
    /// </summary>
    private void PressButton()
    {
        //ボタンを押した処理
        if (Input.GetButtonDown("Bbutton"))
        {
            m_isPress = true;
        }
        if (Input.GetButtonDown("Abutton"))
        {
            m_selectItem[(int)SelectNum.kMastar] = false;
            m_selectItem[(int)SelectNum.kBGM] = false;
            m_selectItem[(int)SelectNum.kSE] = false;

            m_isPress = false;
        }

        DecisionUpdate(m_isPress);
    }
    public void CursorReset()
    {
        m_isPress = false;
        m_selectNum = 0;
    }
}
