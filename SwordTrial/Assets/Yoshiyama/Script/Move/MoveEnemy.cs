using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    public GameObject m_target;                    //GameObject型を変数targetで宣言します
    public Transform m_player;                     //どの座標を基準にするか

    //時間の最大値と最小値の設定
    public int m_minTime = 1;                   //時間間隔の最小値
    public int m_maxTime = 4;                   //時間間隔の最大値

    public int m_hp;                            //EnemyのHP処理

    private float m_GoTime;                     //敵の攻撃タイミング
    private float m_time;                       //時間
    private bool m_isTrigger = false;           //攻撃していいか
    private float m_interval = 0f;              //インターバル

    private string m_tagName = "Player";

    


    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        m_GoTime = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime;
        //時間経過によって攻撃の処理を分ける
        if (m_GoTime == 1 && m_isTrigger == false)
        {
            m_isTrigger = true;
            if (m_time == 2)
            {
                Debug.Log("通常攻撃");
                m_time = 0;
            }
        }
        else if (m_GoTime == 2 && m_isTrigger == false)
        {
            m_isTrigger = true;
            if (m_time == 5)
            {
                Debug.Log("溜め攻撃");
                m_time = 0;
            }
        }
        else if (m_GoTime == 3 && m_isTrigger == false)
        {
            m_isTrigger = true;
            if (m_time == 1)
            {
                Debug.Log("連打攻撃");
                m_time = 0;
            }

        }
        else if (m_GoTime == 4 && m_isTrigger == false)
        {
            m_isTrigger = true;
            if (m_time == 4)
            {
                Debug.Log("ぐるぐる攻撃");
                m_time = 0;
            }
        }
        //trueにしたときの処理 攻撃した後のインターバルの処理
        if (m_isTrigger == true)
        {
            m_time += Time.deltaTime;
            if (m_GoTime == 1)
            {
                if (m_time > 2)
                {
                    m_isTrigger = false;
                    Debug.Log("a");
                    m_time = 0;
                }
            }
            else if (m_GoTime == 2)
            {
                if (m_time > 4)
                {
                    m_isTrigger = false;
                    Debug.Log("b");
                    m_time = 0;
                }
            }
            else if (m_GoTime == 3)
            {
                if (m_time > 1)
                {
                    m_isTrigger = false;
                    Debug.Log("c");
                    m_time = 0;
                }
            }
            else if (m_GoTime == 4)
            {
                if (m_time > 3)
                {
                    m_isTrigger = false;
                    Debug.Log("d");
                    m_time = 0;
                }
            }
            //次に発生する時間間隔を決定する
            m_GoTime = GetRandomTime();
        }
    }

    //ターゲットが範囲に入った時の関数
    private void OnTriggerStay(Collider other)
    {
        //プレイヤーが指定したサークル内に進入したら追いかける
        if (other.gameObject.name == "Player")
        {

            //transform.LookAt(m_player);     

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

