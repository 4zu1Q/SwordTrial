//�T�E���h�̍X�V����
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
        kEnd,//�����
        kMaxNum
    }

    //�I������Ă��鍀��
    public bool[] m_selectItem;
    private bool m_isPress;
    public bool m_isOptionCancellation;
    public bool m_isOptionClose;

    private bool m_istest;
    //���ꂼ��̃X���C�_�[������Ƃ��ł��B�B
    [SerializeField] private Slider[] m_slider;
    [SerializeField] private SoundManager m_soundManager;

    protected override void Start()
    {
        base.Start();
        m_selectItem = new bool[(int)SelectNum.kMaxNum];
        m_isPress = false;
        m_isOptionCancellation = false;
        m_isOptionClose = true;

        //// �{�����[���̃Z�b�g
        //m_slider[(int)SoundType.kMaster].value = mastarVolume;
        //m_slider[(int)SoundType.kBGM].value = bgmVolume;
        //m_slider[(int)SoundType.kSE].value = seVolume;
    }

    void Update()
    {
        SoundVolumeUpdate();
        if (m_isOptionClose)
        { 
            m_istest = false;
            return;
        }
        CursorTransition();
        SlectUIColorChenge(m_isPress);
        UpdateFunction();
        m_istest = true;
    }

    /// <summary>
    /// �V�[���J��
    /// </summary>
    private void CursorTransition()
    {
        //�{�^��������������
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
            //�����≹���̒����Ƃ��ł���悤�ȃE�B���h�E��W�J
            m_selectItem[(int)SelectNum.kSE] = true;
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kEnd)
        {
            //�I��������
            Debug.Log("�Ƃ���");
            m_isOptionCancellation = false;
        }
    }
    /// <summary>
    /// �{�^�����������Ƃ��̏���
    /// </summary>
    private void PressButton()
    {
        if (!m_istest) { return; }
        //�{�^��������������
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
    /// <summary>
    /// �T�E���h��Volume�̍X�V����
    /// </summary>
    private void SoundVolumeUpdate()
    {
        // �T�E���h�̉��ʂ�ς��鏈��
        int selectNum = -1;
        Debug.Log(m_slider[(int)SoundType.kSE].value);
        if (m_selectItem[(int)SoundType.kMaster])
        {
            selectNum = (int)SoundType.kMaster;
        }
        else if (m_selectItem[(int)SoundType.kBGM])
        {
            selectNum = (int)SoundType.kBGM;
        }
        else if (m_selectItem[(int)SoundType.kSE])
        {
            selectNum = (int)SoundType.kSE;
        }
        else
        {
            selectNum = -1;
        }
        if (selectNum == -1) { return; }

        //�X�e�B�b�N�̓��͒l���i�[
        float RightStick = Input.GetAxis("Horizontal");

        //�J�[�\�������ɓ�����
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
