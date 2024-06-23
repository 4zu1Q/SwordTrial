using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject m_target;                    //GameObject型を変数targetで宣言します
    public Transform m_player;                     //どの座標を基準にするか

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    Vector3 playerPos;
    Vector3 enemyPos;
    public float distance;

    //時間の最大値と最小値の設定
    public int m_minTime = 1;                   //時間間隔の最小値
    public int m_maxTime = 4;                   //時間間隔の最大値

    public int m_hp;                            //EnemyのHP処理

    private float m_GoTime;                     //敵の攻撃タイミング
    private float m_time;                       //時間
    private bool m_isTrigger = true;           //攻撃していいか
    private float m_interval = 0f;              //インターバル
    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        m_GoTime = GetRandomTime();
        Vector3 m_EnemyPos = this.transform.position;

        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
        playerPos = player.transform.position;
        enemyPos = enemy.transform.position;
        distance = Vector3.Distance(playerPos, enemyPos);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        enemyPos = enemy.transform.position;
        distance = Vector3.Distance(playerPos, enemyPos);
        if (distance < 5)
        {
            m_time += Time.deltaTime;
            //時間経過によって攻撃の処理を分ける
            if (m_GoTime == 1 && m_isTrigger == true)
            {
                if (m_time > 2)
                {
                    m_isTrigger = false;
                    Debug.Log("通常攻撃");
                    m_time = 0;
                }
            }
            else if (m_GoTime == 2 && m_isTrigger == true)
            {
                if (m_time > 5)
                {
                    m_isTrigger = false;
                    Debug.Log("溜め攻撃");
                    m_time = 0;
                }
            }
            else if (m_GoTime == 3 && m_isTrigger == true)
            {
                if (m_time > 1)
                {
                    m_isTrigger = false;
                    Debug.Log("連打攻撃");
                    m_time = 0;
                }

            }
            else if (m_GoTime == 4 && m_isTrigger == true)
            {
                if (m_time > 4)
                {
                    m_isTrigger = false;
                    Debug.Log("ぐるぐる攻撃");
                    m_time = 0;
                }
            }
            //trueにしたときの処理 攻撃した後のインターバルの処理
            if (m_isTrigger == false)
            {

                if (m_GoTime == 1)
                {
                    if (m_time > 2)
                    {
                        m_isTrigger = true;
                        Debug.Log("a");
                        m_time = 0;
                        //次に発生する時間間隔を決定する
                        m_GoTime = GetRandomTime();
                    }
                }
                else if (m_GoTime == 2)
                {
                    if (m_time > 4)
                    {
                        m_isTrigger = true;
                        Debug.Log("b");
                        m_time = 0;
                        //次に発生する時間間隔を決定する
                        m_GoTime = GetRandomTime();
                    }
                }
                else if (m_GoTime == 3)
                {
                    if (m_time > 1)
                    {
                        m_isTrigger = true;
                        Debug.Log("c");
                        m_time = 0;
                        //次に発生する時間間隔を決定する
                        m_GoTime = GetRandomTime();
                    }
                }
                else if (m_GoTime == 4)
                {
                    if (m_time > 3)
                    {
                        m_isTrigger = true;
                        Debug.Log("d");
                        m_time = 0;
                        //次に発生する時間間隔を決定する
                        m_GoTime = GetRandomTime();
                    }
                }

            }
            transform.Translate(0, 0, 0);
        }
        else
        {
            // Quaternion(回転値)を取得
            Quaternion quaternion = Quaternion.LookRotation(playerPos);
            // 算出した回転値をこのゲームオブジェクトのrotationに代入
            this.transform.rotation = quaternion;
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
