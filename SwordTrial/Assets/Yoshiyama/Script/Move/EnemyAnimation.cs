using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    private string paramaterName = "Attack1";

    Animator m_anim;
    bool m_pushFlag = false;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
        //ランダム値の値に応じてアニメーションを切り替える
        m_pushFlag = false;
    }


    // Update is called once per frame
    void Update()
    {
        

        // 通常攻撃
        if (Input.GetKeyDown("up"))
        {
            Debug.Log("通常攻撃");
            if(m_pushFlag)
            {
                m_pushFlag = false;
            }
            else
            {
                m_pushFlag = true;
            }

            
        }
        //else if (Input.GetKeyDown("down"))
        //{
        //    Debug.Log("溜め攻撃");
        //    m_pushFlag = true;
        //}
        //else if (Input.GetKeyDown("right"))
        //{
        //    Debug.Log("連続攻撃");
        //    m_pushFlag = true;
        //}
        //else if (Input.GetKeyDown("left"))
        //{
        //    Debug.Log("回転攻撃");
        //    m_pushFlag = true;
        //}

        //パラメータの値を変更

        m_anim.SetBool(paramaterName, m_pushFlag);

        Debug.Log(m_pushFlag);
    }
}
