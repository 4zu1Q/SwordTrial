// ���U���g��ʂ̌��ʂ�\�����鏈��

using UnityEngine;

public class TimerResult : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(Timer.m_countDownMinutes + "�F" + Timer.m_countIntSeconds);
    }
}
