using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    public GameObject m_target;                    //GameObject�^��ϐ�target�Ő錾���܂�
    public Transform m_player;                     //�ǂ̍��W����ɂ��邩

    //���Ԃ̍ő�l�ƍŏ��l�̐ݒ�
    public int m_minTime = 1;                   //���ԊԊu�̍ŏ��l
    public int m_maxTime = 4;                   //���ԊԊu�̍ő�l

    public int m_hp;                            //Enemy��HP����

    private float m_GoTime;                     //�G�̍U���^�C�~���O
    private float m_time;                       //����
    private bool m_isTrigger = false;           //�U�����Ă�����
    private float m_interval = 0f;              //�C���^�[�o��

    private string m_tagName = "Player";

    


    // Start is called before the first frame update
    void Start()
    {
        //���ԊԊu�����肷��
        m_GoTime = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime;
        //���Ԍo�߂ɂ���čU���̏����𕪂���
        if (m_GoTime == 1 && m_isTrigger == false)
        {
            m_isTrigger = true;
            if (m_time == 2)
            {
                Debug.Log("�ʏ�U��");
                m_time = 0;
            }
        }
        else if (m_GoTime == 2 && m_isTrigger == false)
        {
            m_isTrigger = true;
            if (m_time == 5)
            {
                Debug.Log("���ߍU��");
                m_time = 0;
            }
        }
        else if (m_GoTime == 3 && m_isTrigger == false)
        {
            m_isTrigger = true;
            if (m_time == 1)
            {
                Debug.Log("�A�ōU��");
                m_time = 0;
            }

        }
        else if (m_GoTime == 4 && m_isTrigger == false)
        {
            m_isTrigger = true;
            if (m_time == 4)
            {
                Debug.Log("���邮��U��");
                m_time = 0;
            }
        }
        //true�ɂ����Ƃ��̏��� �U��������̃C���^�[�o���̏���
        if (m_isTrigger == true)
        {
            m_time += Time.deltaTime;
            if (m_GoTime == 1)
            {
                if (m_time > 2)
                {
                    m_isTrigger = false;
                    Debug.Log("a");
                    m_time = 0;
                }
            }
            else if (m_GoTime == 2)
            {
                if (m_time > 4)
                {
                    m_isTrigger = false;
                    Debug.Log("b");
                    m_time = 0;
                }
            }
            else if (m_GoTime == 3)
            {
                if (m_time > 1)
                {
                    m_isTrigger = false;
                    Debug.Log("c");
                    m_time = 0;
                }
            }
            else if (m_GoTime == 4)
            {
                if (m_time > 3)
                {
                    m_isTrigger = false;
                    Debug.Log("d");
                    m_time = 0;
                }
            }
            //���ɔ������鎞�ԊԊu�����肷��
            m_GoTime = GetRandomTime();
        }
    }

    //�^�[�Q�b�g���͈͂ɓ��������̊֐�
    private void OnTriggerStay(Collider other)
    {
        //�v���C���[���w�肵���T�[�N�����ɐi��������ǂ�������
        if (other.gameObject.name == "Player")
        {
            //transform.LookAt(m_prlayer);
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

