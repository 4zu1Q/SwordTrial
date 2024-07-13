using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int m_hp = 100;

    private string m_targetObjectName;  //目標オブジェクトの名前
    private float speed = 0.1f;         //スピード
    GameObject m_targetObject;

    // Start is called before the first frame update
    void Start()
    {
        m_targetObjectName = "Player";
        m_targetObject = GameObject.Find(m_targetObjectName);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_hp);


        //正規化
        Vector3 dir = (m_targetObject.transform.position - this.transform.position).normalized;

        //その方向に指定したスピード量で進む
        float vx = dir.x * speed;
        float vz = dir.z * speed;

        this.transform.Translate(vx / 50, 0, vz / 50); 

        if(m_hp <= 0)
        {
            Debug.Log("勝ち");

        }

    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "PlayerAttack")
        {
            m_hp -= 10;
        }

    }

    internal int ReceiveDamage(int m_hp)
    {
        throw new NotImplementedException();
    }
}
