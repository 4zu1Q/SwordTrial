//�T�E���h�̍X�V����
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static SoundManager;

public class SoundUICursor : UIOperationBase
{
    public enum SoundTypeNum
    {
        kMaster, //BGM
        kBGM, //BGM
        kSE,//SE
        kEnd,//�����
        kMaxNum
    }

    //�I������Ă��鍀��
    public bool[] m_selectItem;
    public bool m_isOptionCancellation;
    public bool m_isOptionClose;

    private bool m_istest;
    //���ꂼ��̃X���C�_�[������Ƃ��ł��B�B
    [SerializeField] private Slider[] m_slider;
    [SerializeField] private SoundManager m_soundManager;

    protected override void Start()
    {
        base.Start();
        m_selectItem = new bool[(int)SoundTypeNum.kMaxNum];
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
    /// �T�E���h�̉��ʒ���
    /// </summary>
    private void CursorTransition()
    {
        //�{�^��������������
        PressButton();

        if (m_selectNum == (int)SoundTypeNum.kMaster)
        {
            m_selectItem[(int)SoundTypeNum.kMaster] = true;
        }
        else if (m_selectNum == (int)SoundTypeNum.kBGM)
        {
            m_selectItem[(int)SoundTypeNum.kBGM] = true;
        }
        else if (m_selectNum == (int)SoundTypeNum.kSE)
        {
            //�����≹���̒����Ƃ��ł���悤�ȃE�B���h�E��W�J
            m_selectItem[(int)SoundTypeNum.kSE] = true;
        }
    }
    /// <summary>
    /// �{�^�����������Ƃ��̏���
    /// </summary>
    private void PressButton()
    {
        if (!m_istest) { return; }
        if (Input.GetButtonDown("Abutton"))
        {
            m_selectItem[(int)SoundTypeNum.kMaster] = false;
            m_selectItem[(int)SoundTypeNum.kBGM] = false;
            m_selectItem[(int)SoundTypeNum.kSE] = false;

            
            m_selectNum = 0;
            m_isOptionCancellation = false;
        }

    }
    /// <summary>
    /// �T�E���h��Volume�̍X�V����
    /// </summary>
    private void SoundVolumeUpdate()
    {
        // �T�E���h�̉��ʂ�ς��鏈��
        int selectNum = -1;
        Debug.Log(m_selectNum);
        if (m_selectItem[(int)SoundTypeNum.kMaster] && m_selectNum == (int)SoundTypeNum.kMaster)
        {
            selectNum = (int)SoundTypeNum.kMaster;
        }
        else if (m_selectItem[(int)SoundTypeNum.kBGM]&& m_selectNum == (int)SoundTypeNum.kBGM)
        {
            selectNum = (int)SoundTypeNum.kBGM;
        }
        else if (m_selectItem[(int)SoundTypeNum.kSE] && m_selectNum == (int)SoundTypeNum.kSE)
        {
            selectNum = (int)SoundTypeNum.kSE;
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
        if (selectNum == (int)SoundTypeNum.kMaster)
        {
            m_soundManager.SetVolume("Master", m_slider[selectNum].value);
        }
        else if (selectNum == (int)SoundTypeNum.kBGM)
        {
            m_soundManager.SetVolume("BGM", m_slider[selectNum].value);
        }
        else if (selectNum == (int)SoundTypeNum.kSE)
        {
            m_soundManager.SetVolume("SE", m_slider[selectNum].value);
        }
    }
}
