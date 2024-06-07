using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    GameObject PlayerObj;                    //プレイヤーのオブジェクトの取得準備
    private float m_speed = 0.005f;            //敵のスピードを1にする
    private float m_playerToDis = 7.0f;     //プレイヤーが入ってきた際に追いかける距離
    private Vector3 m_startPos;
    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.FindWithTag("Player");   //プレイヤーのオブジェクトの取得
        m_startPos = transform.position;                //座標の初期設定
    }

    // Update is called once per frame
    void Update()
    {

        //プレイヤーの位置から自分の位置を引いた数だけノーマライズする
        Vector3 dir = (PlayerObj.transform.position - this.transform.position).normalized;
        float   mag = (PlayerObj.transform.position - this.transform.position).magnitude;

        //プレイヤーとの距離が指定よりも短くなったら
        if(mag < m_playerToDis)
        {
            //プレイヤーに向かって移動する
            Vector3 nowPos = transform.position;
            dir.y = 0;
            Vector3 move = dir.normalized * m_speed;
            nowPos = nowPos + move;
            transform.position = nowPos;

            //プレイヤーの方向を向く処理
            float rot = Mathf.Atan2(dir.x, dir.z);
            transform.rotation = Quaternion.AngleAxis(rot * Mathf.Rad2Deg, Vector3.up);
        }
        else
        {
        }
        

    }
}

