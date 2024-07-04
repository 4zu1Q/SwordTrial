using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : EnemyC
{

    public Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        hpSlider.value = m_maxHP; //hp�o�[�̍ŏ��̒l
        m_currentHP = m_maxHP; //���݂�HP���ő�HP�ɐݒ�
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = (float)m_currentHP / (float)m_maxHP; //�X���C�_��0�`1.0�ŕ\�����邽�ߍő�HP�Ŋ����ď����_�����ɕϊ�   
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}
