using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : UIOperationBase
{
    public enum SelectNum
    {
        kBack, //戻す
        kTitleBack,   //タイトルに戻る
        kMaxNum
    }
    private PauseMenu m_pauseMenu;//スクリプトの取得
    public Image m_pauseImage;//ポーズの画像取得
    public Image m_defaultPauseImage;//ポーズの画像取得

    //選択されている項目
    public bool[] m_pauseNum;
    private bool m_isPress;
    private bool m_isPauseOpen;

    protected override void Start()
    {
        base.Start();
        m_pauseMenu = GetComponent<PauseMenu>();
        m_pauseNum = new bool[(int)SelectNum.kMaxNum];
        m_isPress = false;
        m_isPauseOpen = false;
        m_defaultPauseImage = m_pauseImage;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateFunction();
        PauseUpdate();
        //SlectUIColorChenge(m_isPress);

    }
    /// <summary>
    /// ポーズ画面の処理
    /// </summary>
    private void PauseUpdate()
    {
        //ボタンを押した処理
        PressButton();
        //ポーズからゲームに戻る処理
        if (m_isPress && m_selectNum == (int)SelectNum.kBack)
        {
            //ポーズ画面を開くフラグを変更する
            m_pauseMenu.GetPauseFlag(false);
            //押したフラグを戻しておく
            m_isPress = false;
            //Debug.Log("もどるよ");
        }
        //ポーズからタイトルに戻る処理
        else if (m_isPress && m_selectNum == (int)SelectNum.kTitleBack)
        {
            //説明や音声の調整とかできるようなウィンドウを展開
            m_pauseNum[(int)SelectNum.kTitleBack] = true;
            //Debug.Log("説明書開く");
        }
        if(!m_pauseMenu.GetMenu())
        {
            PauseImgInit();
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
            m_isPress = false;
        }

        DecisionUpdate(m_isPress);
    }

    private void PauseOpenEffect()
    {
        if (!m_isPauseOpen)
        {
            m_pauseImage.transform.DOMoveX(10,
            10.2f).SetEase(Ease.OutCubic);
            m_isPauseOpen = true;
        }
    }
    public void PauseImgInit()
    {
        if (!m_isPauseOpen)
        {
            m_pauseImage = m_defaultPauseImage;
            m_isPauseOpen = false;
        }
    }
}
