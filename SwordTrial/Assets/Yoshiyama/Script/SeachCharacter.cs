using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeachCharacter : MonoBehaviour
{
    private Enemy moveEnemy;

    // Start is called before the first frame update
    void Start()
    {
        //Enemyの情報を取得する
        moveEnemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player") ;      //プレイヤーキャラクターを発見
        {
            //敵キャラクターの状態を取得　(サーチエリア)に主人公が侵入したか調べるスクリプト
        }
    }
}

