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

        //Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);//クオータニオンで移動の処理
        //lookRotation.z = 0;                                                              //座標の初期設定
        //lookRotation.x = 0;                                                              //座標の初期設定
        //transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);    //座標移動の確定処理
        //Vector3 speed = new Vector3(0f, 0f, 0.005f);                                     //ターゲットに向かって追跡する処理
        //transform.Translate(speed);                                                      //スピードの実行処理
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            transform.LookAt(Player);
            transform.Translate(0, 0, 0.1f);
            Debug.Log("見つけた");
        }
    }
}

