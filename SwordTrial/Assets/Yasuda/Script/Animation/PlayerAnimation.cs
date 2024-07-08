using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    /*変数*/
    private string m_walk = "isWalk";
    private string m_attack = "isAttack";
    private string m_dash = "isDash";
    private string m_gard = "isGard";
    private string m_item = "isItem";
    private string m_damage = "isDamage";
    private string m_win = "isWin";
    private string m_lose = "isLose";

    Animator m_anim;
    private bool m_isPushFlag;

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
            m_anim.SetBool(m_dash, m_isPushFlag);
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
            m_anim.SetBool(m_item, m_isPushFlag);
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
            m_anim.SetBool(m_gard, m_isPushFlag);
        }
        if (Input.GetButton("Xbutton"))
        {
            if (m_isPushFlag)
            {
                m_isPushFlag = false;
            }
            else
            {
                m_isPushFlag = true;
            }
            m_anim.SetBool(m_attack, m_isPushFlag);
        }

    }
}
