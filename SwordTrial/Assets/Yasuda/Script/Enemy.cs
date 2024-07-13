using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int m_hp = 100;

    private string m_targetObjectName;  //�ڕW�I�u�W�F�N�g�̖��O
    private float speed = 0.1f;         //�X�s�[�h
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


        //���K��
        Vector3 dir = (m_targetObject.transform.position - this.transform.position).normalized;

        //���̕����Ɏw�肵���X�s�[�h�ʂŐi��
        float vx = dir.x * speed;
        float vz = dir.z * speed;

        this.transform.Translate(vx / 50, 0, vz / 50); 

        if(m_hp <= 0)
        {
            Debug.Log("����");

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
