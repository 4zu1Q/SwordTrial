using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    GameObject PlayerObj;                    //�v���C���[�̃I�u�W�F�N�g�̎擾����
    private float m_speed = 1.0f;            //�G�̃X�s�[�h��1�ɂ���
    private float m_playerToDis = 10.0f;     //�v���C���[�������Ă����ۂɒǂ������鋗��
    private Vector3 m_startPos;
    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.FindWithTag("Player");   //�v���C���[�̃I�u�W�F�N�g�̎擾
        m_startPos = transform.position;                //���W�̏����ݒ�
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.001f,0,0);

        //�v���C���[�̈ʒu���玩���̈ʒu���������������m�[�}���C�Y����
        Vector3 dir = (PlayerObj.transform.position - this.transform.position).normalized;
        float   mag = (PlayerObj.transform.position - this.transform.position).magnitude;

        //�v���C���[�Ƃ̋������w������Z���Ȃ�����
        if(mag < m_playerToDis)
        {
            //�v���C���[�Ɍ������Ĉړ�����
            //Vector3 nowPos     = transform.position;
            //dir.y              = 0;
            //Vector3 move       = dir.normalized * m_speed;
            //nowPos             = nowPos + move;
            //transform.position = nowPos;
            //���K��
            //Vector3 a = (PlayerObj.transform.position - this.transform.position).normalized;

            ////���̕����Ɏw�肵���X�s�[�h�ʂŐi��
            //float vx = dir.x * speed;
            //float vz = dir.z * speed;

            //�v���C���[�̕�������������
            float rot = Mathf.Atan2(dir.x, dir.z);
            transform.rotation = Quaternion.AngleAxis(rot * Mathf.Rad2Deg, Vector3.up);
        }

    }
}

