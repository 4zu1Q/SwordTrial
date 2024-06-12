using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss1 : MonoBehaviour
{
    private string targetObjectName;     //�ڕW�I�u�W�F�N�g�̖��O
    private float  speed = 0.1f;         //�X�s�[�h
    GameObject     targetObject;         //�ǂ̃I�u�W�F�N�g����ɂ��ē������̏���

    // Start is called before the first frame update
    void Start()
    {
        targetObjectName = "Player";                        //��ƂȂ�^�[�Q�b�g�̃I�u�W�F�N�g���̓��͏���
        targetObject = GameObject.Find(targetObjectName);   //�I�u�W�F�N�g�̖��O������
    }

    // Update is called once per frame
    void Update()
    {
        //���K��
        Vector3 dir = (targetObject.transform.position - this.transform.position).normalized;

        //���̕����Ɏw�肵���X�s�[�h�ʂŐi��
        float vx = dir.x * speed;
        float vz = dir.z * speed;
        //���̍��W�������i�ޏ���
        this.transform.Translate(vx / 50, 0, vz / 50);
    }
}
