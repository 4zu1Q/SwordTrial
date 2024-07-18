// ���U���g��ʂ̌��ʂ�\�����鏈��

using UnityEngine;
using UnityEngine.UI;

public class TimerResult : MonoBehaviour
{
    //���Ԃ̌v�����ʂ�\������e�L�X�g
    [SerializeField] private Sprite[] m_timeNum;//�����̉摜�擾
    [SerializeField] private Image[] m_timeImage;//�\�����鎞�Ԃ̉摜�擾

    void Start()
    {

    }

    void Update()
    {
        TimeResultView();
    }

    /// <summary>
    /// �����������̎��Ԃ�\��
    /// </summary>
    private void TimeResultView()
    {
        // �c�莞�Ԃ�10�b��葽�����
        if(Timer.m_countIntSeconds >= 10)
        {
            var num1 = Timer.m_countIntSeconds / 10;
            var num2 = Timer.m_countIntSeconds - num1 * 10;
            // ���Ԃ̉摜�ύX
            TimeImageChenge(num1, num2);
        }
        //����ȊO��������
        else
        {
            // ���Ԃ̉摜�ύX
            TimeImageChenge(0, Timer.m_countIntSeconds);
        }
    }
    /// <summary>
    ///  ���Ԃ̉摜�̕ύX����
    /// </summary>
    /// <param name="num1">�b����10�̈ʂ̐��l</param>
    /// <param name="num2">�b����1�̈ʂ̐��l</param>
    private void TimeImageChenge(int num1, int num2)
    {
        m_timeImage[0].sprite = m_timeNum[Timer.m_countDownMinutes];
        m_timeImage[1].sprite = m_timeNum[num1];
        m_timeImage[2].sprite = m_timeNum[num2];
    }
}