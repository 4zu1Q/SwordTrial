using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeachCharacter : MonoBehaviour
{
    private Enemy m_moveEnemy;

    // Start is called before the first frame update
    void Start()
    {
        m_moveEnemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player") ;      //�v���C���[�L�����N�^�[�𔭌�
        {
            //�G�L�����N�^�[�̏�Ԃ��擾�@(�T�[�`�G���A)�Ɏ�l�����N�����������ׂ�X�N���v�g
        }
    }
}

