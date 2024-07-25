using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObject m_attack;

    private int m_currentFlame = 0;
    private readonly int m_destroyFlame = 20;

    // Start is called before the first frame update
    void Start()
    {
        m_attack = GameObject.Find("AttackBase");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_currentFlame++;

        if(m_currentFlame == m_destroyFlame)
        {
            Destroy(gameObject);
        }

        transform.position = m_attack.transform.position;
    }
}
