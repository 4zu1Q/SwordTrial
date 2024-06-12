using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    public Slider enemyHp;  //HPバーの追加処理
    // Start is called before the first frame update
    void Start()
    {
        enemyHp.value = 100; //HPの値の入力現状は100にしているが仕様書が出来次第変更する
    }

    private void OnTriggerExit(Collider col)
    {
        //どのオブジェクトに当たったら以下の処理するかの設定
        if (col.gameObject.tag == "Player")
        {
            enemyHp.value -= 10;
            Debug.Log("プレイヤーの攻撃,10のダメージ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
