using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    public GameObject target;                   //GameObject�^��ϐ�target�Ő錾���܂�
    public Transform Player;                    //�ǂ̍��W����ɂ��邩

    //���Ԃ̍ő�l�ƍŏ��l�̐ݒ�
    public int m_minTime = 1;                //���ԊԊu�̍ŏ��l
    public int m_maxTime = 4;                //���ԊԊu�̍ő�l

    private float m_GoTime;                   //�G�̍U���^�C�~���O
    private float m_time;                       //����
    private bool m_isTrigger;                   //�U�����Ă�����
    private float m_interval;                   //�C���^�[�o��


    // Start is called before the first frame update
    void Start()
    {
        //���ԊԊu�����肷��
        m_GoTime = GetRandomTime();
        m_isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԍo�߂ɂ���čU���̏����𕪂���
        if (m_GoTime == 1 && m_isTrigger == false)
        {
            Debug.Log("�U��1");
            m_isTrigger = true;
            for(int i = 0; i <= 120; i++)
            {
                m_interval++;
            }
            m_interval = 0;
            m_isTrigger = false;
        }
        if (m_GoTime == 2 && m_isTrigger == false)
        {
            Debug.Log("�U��2");
            m_isTrigger = true;
            for (int i = 0; i <= 240; i++)
            {
                m_interval++;
            }
            m_interval = 0;
            m_isTrigger = false;
        }
        if (m_GoTime == 3 && m_isTrigger == false)
        {
            Debug.Log("�U��3");
            m_isTrigger |= true;
            for (int i = 0; i <= 60; i++)
            {
                m_interval++;
            }
            m_interval = 0;
            m_isTrigger = false;
        }
        if(m_GoTime == 4 && m_isTrigger == false)
        {
            Debug.Log("�U��4");
            m_isTrigger |= true;
            for (int i = 0; i <= 180; i++)
            {
                m_interval++;
            }
            m_interval = 0;
            m_isTrigger = false;
        }
        //���ɔ������鎞�ԊԊu�����肷��
        m_GoTime = GetRandomTime();
    }

    //�^�[�Q�b�g���͈͂ɓ��������̊֐�
    private void OnTriggerStay(Collider other)
    {
        //�v���C���[���w�肵���T�[�N�����ɐi��������ǂ�������
        if (other.gameObject.name == "Player")
        {
            transform.LookAt(Player);
            transform.Translate(0, 0, 0.01f);
            Debug.Log("������");
        }
    }
    //�����_���Ȏ��Ԃ𐶐�����֐�
    private float GetRandomTime()
    {
        return Random.Range(m_minTime, m_maxTime);
    }
    
}

