using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    public GameObject target;                   //GameObject型を変数targetで宣言します
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
        bool isCheck = false;   //攻撃処理を行う時にtrueにして動きを止める処理
        //プレイヤーが指定したサークル内に進入したら追いかける
        if(other.gameObject.name == "Player" && isCheck == false)
        {
            transform.LookAt(Player);
            transform.Translate(0, 0, 0.01f);
            Debug.Log("見つけた");
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
            Debug.Log("攻撃準備");
        }
    }
}

