using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    public GameObject target;                   //GameObject型を変数targetで宣言します
    public Transform Player;                    //どの座標を基準にするか

    //時間の最大値と最小値の設定
    public int m_minTime = 1;                //時間間隔の最小値
    public int m_maxTime = 4;                //時間間隔の最大値

    private float m_GoTime;                   //敵の攻撃タイミング
    private float m_time;                       //時間
    private bool m_isTrigger;                   //攻撃していいか
    private float m_interval;                   //インターバル


    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        m_GoTime = GetRandomTime();
        m_isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        //時間経過によって攻撃の処理を分ける
        if (m_GoTime == 1 && m_isTrigger == false)
        {
            Debug.Log("攻撃1");
            m_isTrigger = true;
            for(int i = 0; i <= 120; i++)
            {
                m_interval++;
            }
            m_interval = 0;
            m_isTrigger = false;
        }
        if (m_GoTime == 2 && m_isTrigger == false)
        {
            Debug.Log("攻撃2");
            m_isTrigger = true;
            for (int i = 0; i <= 240; i++)
            {
                m_interval++;
            }
            m_interval = 0;
            m_isTrigger = false;
        }
        if (m_GoTime == 3 && m_isTrigger == false)
        {
            Debug.Log("攻撃3");
            m_isTrigger |= true;
            for (int i = 0; i <= 60; i++)
            {
                m_interval++;
            }
            m_interval = 0;
            m_isTrigger = false;
        }
        if(m_GoTime == 4 && m_isTrigger == false)
        {
            Debug.Log("攻撃4");
            m_isTrigger |= true;
            for (int i = 0; i <= 180; i++)
            {
                m_interval++;
            }
            m_interval = 0;
            m_isTrigger = false;
        }
        //次に発生する時間間隔を決定する
        m_GoTime = GetRandomTime();
    }

    //ターゲットが範囲に入った時の関数
    private void OnTriggerStay(Collider other)
    {
        //プレイヤーが指定したサークル内に進入したら追いかける
        if (other.gameObject.name == "Player")
        {
            transform.LookAt(Player);
            transform.Translate(0, 0, 0.01f);
            Debug.Log("見つけた");
        }
    }
    //ランダムな時間を生成する関数
    private float GetRandomTime()
    {
        return Random.Range(m_minTime, m_maxTime);
    }
    
}

