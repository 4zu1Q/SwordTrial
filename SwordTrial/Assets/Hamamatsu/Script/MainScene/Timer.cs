//�^�C�}�[����

using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // 1���̒���
    private const float m_oneMinute = 60;

    //�J�E���g�_�E����
    [SerializeField] private int m_countDownMinutes = 3;
    //�J�E���g�_�E���b
    [SerializeField] private float m_countDownSeconds = 0;
    // �J�E���g�_�E���b
    private int m_countIntSeconds = 0;
    //���݂̎��Ԃ�\������e�L�X�g
    private Text m_timerText;

    void Start()
    {
        m_timerText = GameObject.Find("TimerText").GetComponent<Text>();
        //m_countDownSeconds = m_countDownMinutes * 60;
    }

    void Update()
    {
        //�b�����炷
        CountDown();
        
        Debug.Log(m_countDownMinutes + "�F" + m_countDownSeconds);

        m_countIntSeconds = IntConvert(m_countDownSeconds);

        if (m_countDownMinutes <= 0 && m_countDownSeconds <= 0)
        {
            m_timerText.text = string.Format("00�F00");
        }
        else 
        {
            m_timerText.text = string.Format(m_countDownMinutes + "�F" + m_countIntSeconds);
        }
        


        //�^�C�}�[���[���ɂȂ�����
        if (m_countDownSeconds <= 0)
        {
            //�Q�[���I�[�o�[�V�[���Ɉڍs

        }
    }

    /// <summary>
    /// �J�E���g�_�E���̏���
    /// </summary>
    private void CountDown()
    {
        // �^�C���I�[�o�[�ɂȂ�Ə������~�߂�
        //if(m_countDownMinutes < 0 && m_countDownSeconds < 0)
        //{
        //    m_countDownMinutes = 0; 
        //    m_countDownSeconds = 0;
        //    return;
        //}
        //else
        //{
            
        //}

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
}
