//�^�C�}�[����

using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // 1���̒���
    private const float m_oneMinute = 60;

    //�J�E���g�_�E����
    [SerializeField] public static int m_countDownMinutes = 3;
    //�J�E���g�_�E���b(float)
    [SerializeField] private float m_countDownSeconds = 0;
    //�J�E���g�_�E���b(int)
    public static int m_countIntSeconds = 0;
    //���݂̎��Ԃ�\������e�L�X�g
    private Text m_timerText;
    //���j���[�̏���
    private PauseMenu m_menu;

    //�J�E���g�_�E���I���t���O
    private bool m_finishCountDown = false;

    void Start()
    {
        m_countDownMinutes = 3;
        m_timerText = GameObject.Find("TimerText").GetComponent<Text>();
        m_menu = GetComponent<PauseMenu>();
    }

    void Update()
    {
        //�b�����炷
        CountDown();

        m_countIntSeconds = IntConvert(m_countDownSeconds);

        if (m_countDownMinutes <= 0 && m_countDownSeconds <= 0)
        {
            m_timerText.text = string.Format("Time 00�F00");

            //�J�E���g�_�E���I��
            m_finishCountDown = true;
        }
        else 
        {
            m_timerText.text = string.Format("Time " + m_countDownMinutes + ":" + m_countIntSeconds);
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

    public bool GetFinishCountDown() { return m_finishCountDown; }
}
