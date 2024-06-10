using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    public Slider m_enemyHp;
    // Start is called before the first frame update
    void Start()
    {
        m_enemyHp.value = 100;
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            m_enemyHp.value -= 10;
            Debug.Log("プレイヤーの攻撃,10のダメージ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
