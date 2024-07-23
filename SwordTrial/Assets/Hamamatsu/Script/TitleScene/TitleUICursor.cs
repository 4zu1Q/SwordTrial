//�^�C�g����ʂ̃J�[�\���̑���

using UnityEngine;
using UnityEngine.UI;
using static SoundManager;

public class TitleUICursor : UIOperationBase
{
    public enum SelectNum
    {
        kStart, //�X�^�[�g
        kOption,//�I�v�V����
        kEnd,   //�I��
        kMaxNum
    }

    //�I������Ă��鍀��
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
    /// �V�[���J��
    /// </summary>
    private void SceneTransition()
    {
        //�{�^��������������
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
            //�����≹���̒����Ƃ��ł���悤�ȃE�B���h�E��W�J
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kEnd)
        {
            //�Q�[���I��������
            EndGame();
            //Debug.Log("�Q�[���I��");
        }
    }
    /// <summary>
    /// �{�^�����������Ƃ��̏���
    /// </summary>
    private void PressButton()
    {
        //�{�^��������������
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
    /// �I�v�V�����̉�������
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
    /// �Q�[�����I������Ƃ��̏���
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
