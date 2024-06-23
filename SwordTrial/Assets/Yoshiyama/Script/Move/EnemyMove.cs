using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject m_target;                    //GameObject�^��ϐ�target�Ő錾���܂�
    public Transform m_player;                     //�ǂ̍��W����ɂ��邩

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    Vector3 playerPos;
    Vector3 enemyPos;
    public float distance;

    //���Ԃ̍ő�l�ƍŏ��l�̐ݒ�
    public int m_minTime = 1;                   //���ԊԊu�̍ŏ��l
    public int m_maxTime = 4;                   //���ԊԊu�̍ő�l

    public int m_hp;                            //Enemy��HP����

    private float m_GoTime;                     //�G�̍U���^�C�~���O
    private float m_time;                       //����
    private bool m_isTrigger = true;           //�U�����Ă�����
    private float m_interval = 0f;              //�C���^�[�o��
    // Start is called before the first frame update
    void Start()
    {
        //���ԊԊu�����肷��
        m_GoTime = GetRandomTime();
        Vector3 m_EnemyPos = this.transform.position;

        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
        playerPos = player.transform.position;
        enemyPos = enemy.transform.position;
        distance = Vector3.Distance(playerPos, enemyPos);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        enemyPos = enemy.transform.position;
        distance = Vector3.Distance(playerPos, enemyPos);
        if (distance < 5)
        {
            m_time += Time.deltaTime;
            //���Ԍo�߂ɂ���čU���̏����𕪂���
            if (m_GoTime == 1 && m_isTrigger == true)
            {
                if (m_time > 2)
                {
                    m_isTrigger = false;
                    Debug.Log("�ʏ�U��");
                    m_time = 0;
                }
            }
            else if (m_GoTime == 2 && m_isTrigger == true)
            {
                if (m_time > 5)
                {
                    m_isTrigger = false;
                    Debug.Log("���ߍU��");
                    m_time = 0;
                }
            }
            else if (m_GoTime == 3 && m_isTrigger == true)
            {
                if (m_time > 1)
                {
                    m_isTrigger = false;
                    Debug.Log("�A�ōU��");
                    m_time = 0;
                }

            }
            else if (m_GoTime == 4 && m_isTrigger == true)
            {
                if (m_time > 4)
                {
                    m_isTrigger = false;
                    Debug.Log("���邮��U��");
                    m_time = 0;
                }
            }
            //true�ɂ����Ƃ��̏��� �U��������̃C���^�[�o���̏���
            if (m_isTrigger == false)
            {

                if (m_GoTime == 1)
                {
                    if (m_time > 2)
                    {
                        m_isTrigger = true;
                        Debug.Log("a");
                        m_time = 0;
                        //���ɔ������鎞�ԊԊu�����肷��
                        m_GoTime = GetRandomTime();
                    }
                }
                else if (m_GoTime == 2)
                {
                    if (m_time > 4)
                    {
                        m_isTrigger = true;
                        Debug.Log("b");
                        m_time = 0;
                        //���ɔ������鎞�ԊԊu�����肷��
                        m_GoTime = GetRandomTime();
                    }
                }
                else if (m_GoTime == 3)
                {
                    if (m_time > 1)
                    {
                        m_isTrigger = true;
                        Debug.Log("c");
                        m_time = 0;
                        //���ɔ������鎞�ԊԊu�����肷��
                        m_GoTime = GetRandomTime();
                    }
                }
                else if (m_GoTime == 4)
                {
                    if (m_time > 3)
                    {
                        m_isTrigger = true;
                        Debug.Log("d");
                        m_time = 0;
                        //���ɔ������鎞�ԊԊu�����肷��
                        m_GoTime = GetRandomTime();
                    }
                }

            }
            transform.Translate(0, 0, 0);
        }
        else
        {
            // Quaternion(��]�l)���擾
            Quaternion quaternion = Quaternion.LookRotation(playerPos);
            // �Z�o������]�l�����̃Q�[���I�u�W�F�N�g��rotation�ɑ��
            this.transform.rotation = quaternion;
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
