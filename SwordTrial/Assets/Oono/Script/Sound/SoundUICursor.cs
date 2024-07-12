//サウンドの更新処理
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static SoundManager;

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
    public bool m_isOptionCancellation;
    public bool m_isOptionClose;

    private bool m_istest;
    //それぞれのスライダーを入れるとこです。。
    [SerializeField] private Slider[] m_slider;
    [SerializeField] private SoundManager m_soundManager;

    protected override void Start()
    {
        base.Start();
        m_selectItem = new bool[(int)SelectNum.kMaxNum];
        m_isOptionCancellation = false;
        m_isOptionClose = true;
    }

    void Update()
    {
        SoundVolumeUpdate();
        if (m_isOptionClose)
        { 
            m_istest = false;
            ResetCursor();
            return;
        }
        CursorTransition();
        UpdateFunction();
        m_istest = true;
    }

    /// <summary>
    /// サウンドの音量調整
    /// </summary>
    private void CursorTransition()
    {
        //ボタンを押した処理
        PressButton();

        if (m_selectNum == (int)SelectNum.kMastar)
        {
            m_selectItem[(int)SelectNum.kMastar] = true;
        }
        else if (m_selectNum == (int)SelectNum.kBGM)
        {
            m_selectItem[(int)SelectNum.kBGM] = true;
        }
        else if (m_selectNum == (int)SelectNum.kSE)
        {
            //説明や音声の調整とかできるようなウィンドウを展開
            m_selectItem[(int)SelectNum.kSE] = true;
        }
    }
    /// <summary>
    /// ボタンを押したときの処理
    /// </summary>
    private void PressButton()
    {
        if (!m_istest) { return; }
        if (Input.GetButtonDown("Abutton"))
        {
            m_selectItem[(int)SelectNum.kMastar] = false;
            m_selectItem[(int)SelectNum.kBGM] = false;
            m_selectItem[(int)SelectNum.kSE] = false;

            
            m_selectNum = 0;
            m_isOptionCancellation = false;
        }

    }
    /// <summary>
    /// サウンドのVolumeの更新処理
    /// </summary>
    private void SoundVolumeUpdate()
    {
        // サウンドの音量を変える処理
        int selectNum = -1;
        Debug.Log(m_selectNum);
        if (m_selectItem[(int)SoundType.kMaster] && m_selectNum == (int)SoundType.kMaster)
        {
            selectNum = (int)SoundType.kMaster;
        }
        else if (m_selectItem[(int)SoundType.kBGM]&& m_selectNum == (int)SelectNum.kBGM)
        {
            selectNum = (int)SoundType.kBGM;
        }
        else if (m_selectItem[(int)SoundType.kSE] && m_selectNum == (int)SelectNum.kSE)
        {
            selectNum = (int)SoundType.kSE;
        }
        else
        {
            selectNum = -1;
        }
        if (selectNum == -1) { return; }

        //スティックの入力値を格納
        float RightStick = Input.GetAxis("Horizontal");

        //カーソルを下に動かす
        if (RightStick >= 0.5f)
        {
            m_slider[selectNum].value++;

        }
        else if (RightStick <= -0.5f)
        {
            m_slider[selectNum].value--;

        }
        if (selectNum == (int)SoundType.kMaster)
        {
            m_soundManager.SetVolume("Master", m_slider[selectNum].value);
        }
        else if (selectNum == (int)SoundType.kBGM)
        {
            m_soundManager.SetVolume("BGM", m_slider[selectNum].value);
        }
        else if (selectNum == (int)SoundType.kSE)
        {
            m_soundManager.SetVolume("SE", m_slider[selectNum].value);
        }
    }
}
