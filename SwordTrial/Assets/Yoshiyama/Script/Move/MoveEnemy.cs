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

       
    }

    private void OnTriggerStay(Collider other)
    {
        bool isCheck = false;   //�U���������s������true�ɂ��ē������~�߂鏈��
        //�v���C���[���w�肵���T�[�N�����ɐi��������ǂ�������
        if(other.gameObject.name == "Player" && isCheck == false)
        {
            transform.LookAt(Player);
            transform.Translate(0, 0, 0.01f);
            Debug.Log("������");
        }
        if(other == Player)
        {
            isCheck = true;
        }
    }
    private void OnTriggerMove(Collider collider)
    {
        if(collider.gameObject.name == "Player")
        {
            transform.LookAt(Player);
            transform.Translate(0, 0, 0); ;
            Debug.Log("�U������");
        }
    }
}

