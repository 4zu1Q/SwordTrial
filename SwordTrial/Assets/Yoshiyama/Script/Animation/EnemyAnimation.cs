using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    private string m_attack1 = "Attack1";
    private string m_attack2 = "Attack2";
    private string m_attack3 = "Attack3";
    private string m_attack4 = "Attack4";

    Animator m_anim;
    bool m_pushFlag = false;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
        //ƒ‰ƒ“ƒ_ƒ€’l‚Ì’l‚É‰‚¶‚ÄƒAƒjƒ[ƒVƒ‡ƒ“‚ğØ‚è‘Ö‚¦‚é
        m_pushFlag = false;
    }


    // Update is called once per frame
    void Update()
    {
        // ’ÊíUŒ‚
        if (Input.GetKeyDown("up"))
        {
            Debug.Log("’ÊíUŒ‚");
            if (m_pushFlag)
            {
                m_pushFlag = false;
            }
            else
            {
                m_pushFlag = true;
            }
            m_anim.SetBool(m_attack1, m_pushFlag);
        }
        else if (Input.GetKeyDown("down"))
        {
            Debug.Log("—­‚ßUŒ‚");
            if (m_pushFlag)
            {
                m_pushFlag = false;
            }
            else
            {
                m_pushFlag = true;
            }
            m_anim.SetBool(m_attack2, m_pushFlag);
        }
        else if (Input.GetKeyDown("right"))
        {
            Debug.Log("˜A‘±UŒ‚");
            if (m_pushFlag)
            {
                m_pushFlag = false;
            }
            else
            {
                m_pushFlag = true;
            }
            m_anim.SetBool(m_attack3, m_pushFlag);
        }
        else if (Input.GetKeyDown("left"))
        {
            Debug.Log("‰ñ“]UŒ‚");
            if (m_pushFlag)
            {
                m_pushFlag = false;
            }
            else
            {
                m_pushFlag = true;
            }
            m_anim.SetBool(m_attack4, m_pushFlag);
        }
        Debug.Log(m_pushFlag);
    }
}
