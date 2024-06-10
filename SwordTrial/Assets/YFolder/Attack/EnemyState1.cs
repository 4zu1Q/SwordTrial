using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class EnemyState1 : MonoBehaviour
{
    [SerializeField] EnemyData m_enemydata;
    [SerializeField] MonoBehaviour m_Enemykinisetu;

    int m_state;
    bool m_koudou;
    IEnemy m_pEnemyKoudou;

    // Start is called before the first frame update
    void Start()
    {
        //IEnemyの宣言したスクリプトをm_pEnemyKoudouへ代入する
        m_pEnemyKoudou = GetComponent<IEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        //アニメーション関係の処理(現状アニメーションはないためなし)
        //StartCoroutine(Enemytime());

        //値が入ってない場合に備えnullチェック
        if (m_pEnemyKoudou != null)
        {
            //スクリプトのEnemyAIKoudouを呼び出して、返ってきた値をStateに代入する
            m_state = m_pEnemyKoudou.m_enemyAIkoudou();

            m_koudou = true;

            //Switch文でStateの値に応じて条件分岐　
            switch (m_state)
            {
                //m_stateが0なら終了
                case 0:
                    Debug.Log("停止");
                    break;
                //m_stateが1なら攻撃
                case 1:
                    Debug.Log("攻撃");
                    break;
            }

        }

    }

    //IEnumerator Enemytime()
    //{
    //    yield return new WaitForSeconds(m_enemydata.Enemytime);
    //    m_koudou = false;
    //}
}
