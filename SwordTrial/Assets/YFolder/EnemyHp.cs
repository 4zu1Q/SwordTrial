using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    public Slider enemyHp;  //HP�o�[�̒ǉ�����
    // Start is called before the first frame update
    void Start()
    {
        enemyHp.value = 100; //HP�̒l�̓��͌����100�ɂ��Ă��邪�d�l�����o������ύX����
    }

    private void OnTriggerExit(Collider col)
    {
        //�ǂ̃I�u�W�F�N�g�ɓ���������ȉ��̏������邩�̐ݒ�
        if (col.gameObject.tag == "Player")
        {
            enemyHp.value -= 10;
            Debug.Log("�v���C���[�̍U��,10�̃_���[�W");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
