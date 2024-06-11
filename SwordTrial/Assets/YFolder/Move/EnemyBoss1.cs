using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss1 : MonoBehaviour
{
    private string targetObjectName;     //目標オブジェクトの名前
    private float  speed = 0.1f;         //スピード
    GameObject     targetObject;         //どのオブジェクトを基準にして動くかの処理

    // Start is called before the first frame update
    void Start()
    {
        targetObjectName = "Player";                        //基準となるターゲットのオブジェクト名の入力処理
        targetObject = GameObject.Find(targetObjectName);   //オブジェクトの名前を入れる
    }

    // Update is called once per frame
    void Update()
    {
        //正規化
        Vector3 dir = (targetObject.transform.position - this.transform.position).normalized;

        //その方向に指定したスピード量で進む
        float vx = dir.x * speed;
        float vz = dir.z * speed;
        //その座標分だけ進む処理
        this.transform.Translate(vx / 50, 0, vz / 50);
    }
}
