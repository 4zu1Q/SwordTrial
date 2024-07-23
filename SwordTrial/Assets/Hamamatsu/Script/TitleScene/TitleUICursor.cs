//タイトル画面のカーソルの操作

using UnityEngine;
using UnityEngine.UI;
using static SoundManager;

public class TitleUICursor : UIOperationBase
{
    public enum SelectNum
    {
        kStart, //スタート
        kOption,//オプション
        kEnd,   //終了
        kMaxNum
    }

    //選択されている項目
    public bool[] m_selectItem;
    private bool m_isPress;
    [SerializeField] private GameObject m_soundImgObj;
    [SerializeField] private SoundUICursor m_soundCursor;
    private bool m_isOptionOpen;
    protected override void Start()
    {
        base.Start();
        m_selectItem = new bool[(int)SelectNum.kMaxNum];
        m_isPress = false;
        m_isOptionOpen = false;
        m_soundImgObj.SetActive(false);
    }

    void Update()
    {
        if (OptionCancellation()) {return; }
        UpdateFunction();
        SceneTransition();
        SlectUIColorChenge(m_isPress);
    }

    /// <summary>
    /// シーン遷移
    /// </summary>
    private void SceneTransition()
    {
        //ボタンを押した処理
        PressButton();

        if (m_isPress && m_selectNum == (int)SelectNum.kStart)
        {
            m_selectItem[(int)SelectNum.kStart] = true;
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kOption)
        {
            m_soundCursor.m_isOptionCancellation = true;
            m_soundCursor.m_isOptionClose = false;
            m_isOptionOpen = true;
            m_soundImgObj.SetActive(true);
            m_isOptionOpen = true;
            //説明や音声の調整とかできるようなウィンドウを展開
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kEnd)
        {
            //ゲーム終了させる
            EndGame();
            //Debug.Log("ゲーム終了");
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
            m_soundManager.PlaySoundSE(SoundSEName.Decision);
        }
        if (Input.GetButtonDown("Abutton"))
        {
            m_soundManager.PlaySoundSE(SoundSEName.Cancel);
            m_isPress = false;
        }

        DecisionUpdate(m_isPress);
    }
    /// <summary>
    /// オプションの解除処理
    /// </summary>
    public bool OptionCancellation()
    {
        if(m_soundCursor == null) { return false; }
        if (!m_soundCursor.m_isOptionCancellation && m_isOptionOpen)
        {
            m_soundImgObj.SetActive(false);
            m_isPress = false;
            m_soundCursor.m_isOptionClose = true;
            m_isOptionOpen = false;
            return true;
        }
        else if (m_soundCursor.m_isOptionCancellation && m_isOptionOpen)
        { 
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// ゲームを終了するときの処理
    /// </summary>
    private void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
