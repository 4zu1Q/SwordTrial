//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyHPBar : MonoBehaviour
//{
//    //“G‚ÌMaxHP
//    [SerializeField] private int m_maxHP = 100;

//    private Enemy enemy;

//    //HP•\Ž¦—pUI
//    [SerializeField] private GameObject HPUI;

//    EnemyC m_pEnemy = new EnemyC();
//    public Slider m_slider;
//    private int m_hp;


//    // Start is called before the first frame update
//    void Start()
//    {
//        m_hp = m_pEnemy.ReceiveDamage(m_hp);
//        m_slider.value = m_hp;
//    }

//    // Update is called once per frame
//    void FixedUpdate()
//    {
//        m_hp = m_pEnemy.ReceiveDamage(m_hp);
//        m_slider.value = m_hp;
//    }
//}


