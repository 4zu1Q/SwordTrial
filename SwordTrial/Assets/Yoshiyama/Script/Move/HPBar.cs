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
        hpSlider.value = m_maxHP; //hpバーの最初の値
        m_currentHP = m_maxHP; //現在のHPを最大HPに設定
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = (float)m_currentHP / (float)m_maxHP; //スライダは0～1.0で表現するため最大HPで割って小数点数字に変換   
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}
