using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class EnemyState1 : MonoBehaviour
{
    [SerializeField] EnemyData m_enemydata;
    [SerializeField] MonoBehaviour m_Enemykinisetu;

    int m_state;
    bool m_koudou;
    IEnemy m_pEnemyKoudou;

    // Start is called before the first frame update
    void Start()
    {
        //IEnemy�̐錾�����X�N���v�g��m_pEnemyKoudou�֑������
        m_pEnemyKoudou = GetComponent<IEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        //�A�j���[�V�����֌W�̏���(����A�j���[�V�����͂Ȃ����߂Ȃ�)
        //StartCoroutine(Enemytime());

        //�l�������ĂȂ��ꍇ�ɔ���null�`�F�b�N
        if (m_pEnemyKoudou != null)
        {
            //�X�N���v�g��EnemyAIKoudou���Ăяo���āA�Ԃ��Ă����l��State�ɑ������
            m_state = m_pEnemyKoudou.m_enemyAIkoudou();

            m_koudou = true;

            //Switch����State�̒l�ɉ����ď�������@
            switch (m_state)
            {
                //m_state��0�Ȃ�I��
                case 0:
                    Debug.Log("��~");
                    break;
                //m_state��1�Ȃ�U��
                case 1:
                    Debug.Log("�U��");
                    break;
            }

        }

    }

    //IEnumerator Enemytime()
    //{
    //    yield return new WaitForSeconds(m_enemydata.Enemytime);
    //    m_koudou = false;
    //}
}
