//�^�C�}�[����

using UnityEngine;
using UnityEngine.UI;

public class NumbersUI : NumbersUIBase
{
    // 1���̒���
    private const float m_oneMinute = 60;

    //���j���[�̏���
    private PauseMenu m_menu;

    //�J�E���g�_�E���I���t���O
    private bool m_finishCountDown = false;

    [SerializeField] private Player m_player;
    void Start()
    {
        m_countDownMinutes = 3;
        m_menu = GetComponent<PauseMenu>();
    }

    void Update()
    {
        //�b�����炷
        CountDown();

        m_countIntSeconds = IntConvert(m_countDownSeconds);

        if (m_countDownMinutes <= 0 && m_countDownSeconds <= 0)
        {
            //�J�E���g�_�E���I��
            m_finishCountDown = true;
        }
        TimeImgView();

        if(m_isItem) 
        {
            m_ItemNum = m_player.m_itemNum;
            ItemImgView();
        }
    }

    /// <summary>
    /// �J�E���g�_�E���̏���
    /// </summary>
    private void CountDown()
    {
        if (m_menu.GetMenu()) return;


        //�J�E���g�����炷
        m_countDownSeconds -= Time.deltaTime;

        //�����X�V
        if (m_countDownSeconds <= 0 && m_countDownMinutes >= 1)
        {
            m_countDownMinutes -= 1;
            m_countDownSeconds = m_oneMinute;
        }
    }

    /// <summary>
    /// int�^�ɕϊ�
    /// </summary>
    private int IntConvert(float floatNum)
    {
        int result = 0;

        result = Mathf.FloorToInt(floatNum);

        return result;
    }

    /// <summary>
    /// �J�E���g�_�E���I���������擾
    /// </summary>
    /// <returns></returns>
    public bool GetFinishCountDown() { return m_finishCountDown; }
}
