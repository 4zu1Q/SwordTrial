//�^�C�g����ʂ̃J�[�\���̑���

using UnityEngine;
using UnityEngine.UI;

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

    protected override void Start()
    {
        base.Start();
        m_selectItem = new bool[(int)SelectNum.kMaxNum];
        m_isPress = false;
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
            m_soundImgObj.SetActive(true);
            //�����≹���̒����Ƃ��ł���悤�ȃE�B���h�E��W�J
            Debug.Log("�������J��");
        }
        else if (m_isPress && m_selectNum == (int)SelectNum.kEnd)
        {
            //�Q�[���I��������
            //End();
            Debug.Log("�Q�[���I��");
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
        }
        if (Input.GetButtonDown("Abutton"))
        {
            m_isPress = false;
        }

        DecisionUpdate(m_isPress);
    }
    /// <summary>
    /// �I�v�V�����̉�������
    /// </summary>
    public bool OptionCancellation()
    {
        if(!m_soundCursor.m_isOptionCancellation)
        {
            m_soundImgObj.SetActive(false);
            m_isPress = false;
            m_soundCursor.CursorReset();
            return false;
        }
        else
        {
            return true;
        }
    }
}
