// ���U���g��ʂ̌��ʂ�\�����鏈��

using UnityEngine;
using UnityEngine.UI;

public class TimerResult : MonoBehaviour
{
    //���Ԃ̌v�����ʂ�\������e�L�X�g
    [SerializeField] private Text m_resultText;

    void Start()
    {

    }

    void Update()
    {
        TimeResultView();
        //Debug.Log(Timer.m_countDownMinutes + "�F" + Timer.m_countIntSeconds);
    }

    /// <summary>
    /// �����������̎��Ԃ�\��
    /// </summary>
    private void TimeResultView()
    {
        Debug.Log(Timer.m_countIntSeconds);
        m_resultText.text = "Time:" + Timer.m_countDownMinutes + ":" + Timer.m_countIntSeconds;
    }
}