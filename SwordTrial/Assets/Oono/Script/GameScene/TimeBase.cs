using UnityEngine;
using UnityEngine.UI;

public class TimeBase : MonoBehaviour
{
    //�J�E���g�_�E����
    [SerializeField] public static int m_countDownMinutes = 3;
    //�J�E���g�_�E���b(float)
    [SerializeField] public float m_countDownSeconds = 0;
    //�J�E���g�_�E���b(int)
    public static int m_countIntSeconds = 0;
    //���Ԃ̌v�����ʂ�\������e�L�X�g
    [SerializeField] private Sprite[] m_timeNum;//�����̉摜�擾
    [SerializeField] private Image[] m_timeImage;//�\�����鎞�Ԃ̉摜�擾
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// �����������̎��Ԃ�\��
    /// </summary>
    public void TimeImgView()
    {
        // �c�莞�Ԃ�10�b��葽�����
        if (m_countIntSeconds >= 10)
        {
            var num1 = m_countIntSeconds / 10;
            var num2 = m_countIntSeconds - num1 * 10;
            // ���Ԃ̉摜�ύX
            TimeImageChenge(num1, num2);
        }
        //����ȊO��������
        else
        {
            // ���Ԃ̉摜�ύX
            TimeImageChenge(0, m_countIntSeconds);
        }
    }
    /// <summary>
    ///  ���Ԃ̉摜�̕ύX����
    /// </summary>
    /// <param name="num1">�b����10�̈ʂ̐��l</param>
    /// <param name="num2">�b����1�̈ʂ̐��l</param>
    private void TimeImageChenge(int num1, int num2)
    {
        m_timeImage[0].sprite = m_timeNum[m_countDownMinutes];
        m_timeImage[1].sprite = m_timeNum[num1];
        m_timeImage[2].sprite = m_timeNum[num2];
    }
}
