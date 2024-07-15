using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    /*変数*/
    //private string m_walk = "isWalk";
    //private string m_attack = "isAttack";
    //private string m_dash = "isDash";
    //private string m_gard = "isGard";
    //private string m_item = "isItem";
    //private string m_damage = "isDamage";
    //private string m_win = "isWin";
    //private string m_lose = "isLose";

    //アニメーションのトリガー
    private string m_idle = "Idle";
    private string m_attack = "Attack";

    Animator m_anim;
    private bool m_isPushFlag;

    //現在のフレーム数
    private int m_currentFlameNum = 0;
    //待機状態に遷移するタイミング
    private int m_changeFlameNum = 0;


    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
        //ランダム値の値に応じてアニメーションを切り替る
        m_isPushFlag = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Abutton"))
        {
            if (m_isPushFlag)
            {
                m_isPushFlag = false;
            }
            else
            {
                m_isPushFlag = true;
            }
            //m_anim.SetBool(m_dash, m_isPushFlag);
        }
        if (Input.GetButton("Bbutton"))
        {
            if (m_isPushFlag)
            {
                m_isPushFlag = false;
            }
            else
            {
                m_isPushFlag = true;
            }
            //m_anim.SetBool(m_item, m_isPushFlag);
        }
        if (Input.GetButton("Ybutton"))
        {
            if (m_isPushFlag)
            {
                m_isPushFlag = false;
            }
            else
            {
                m_isPushFlag = true;
            }
            //m_anim.SetBool(m_gard, m_isPushFlag);
        }
        //攻撃
        if (Input.GetButtonDown("Xbutton"))
        {
            //if (m_isPushFlag)
            //{
            //    m_isPushFlag = false;
            //}
            //else
            //{
            //    m_isPushFlag = true;
            //}
            //m_anim.SetBool(m_attack, m_isPushFlag);

            m_anim.SetTrigger(m_attack);
            m_currentFlameNum = 0;
            m_changeFlameNum = 60;
        }

        //Debug.Log(m_currentFlameNum);

    }

    private void FixedUpdate()
    {
        m_currentFlameNum++;
        idleChange();
    }

    private void idleChange()
    {
        if(m_currentFlameNum == m_changeFlameNum)
        {
            Debug.Log("通っている");
            m_anim.SetTrigger(m_idle);
            //m_currentFlameNum = 0;
        }
    }
}
