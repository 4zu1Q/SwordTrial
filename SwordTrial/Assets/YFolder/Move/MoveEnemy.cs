using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    public GameObject target;                   //GameObject�^��ϐ�target�Ő錾���܂�

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            Quaternion m_lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);

            m_lookRotation.z = 0;
            m_lookRotation.x = 0;

            transform.rotation = Quaternion.Lerp(transform.rotation, m_lookRotation, 0.1f);     //
            Vector3 m_speed = new Vector3(0f, 0f, 0.005f);                                      //�^�[�Q�b�g�Ɍ������ĒǐՂ��鏈��

            transform.Translate(m_speed);
    }
}

