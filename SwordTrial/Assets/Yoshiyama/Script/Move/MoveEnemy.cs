using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    public GameObject target;                   //GameObject�^��ϐ�target�Ő錾���܂�
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        //Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);//�N�I�[�^�j�I���ňړ��̏���
        //lookRotation.z = 0;                                                              //���W�̏����ݒ�
        //lookRotation.x = 0;                                                              //���W�̏����ݒ�
        //transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);    //���W�ړ��̊m�菈��
        //Vector3 speed = new Vector3(0f, 0f, 0.005f);                                     //�^�[�Q�b�g�Ɍ������ĒǐՂ��鏈��
        //transform.Translate(speed);                                                      //�X�s�[�h�̎��s����
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            transform.LookAt(Player);
            transform.Translate(0, 0, 0.1f);
            Debug.Log("������");
        }
    }
}

