using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{
    //このスクリプトで使う変数一覧
    private CharacterController m_charaCon;         //キャラクターコンポーネント用の変数
    private Animator            m_animeCon;         //アニメーションするための変数
    public  float               m_moveSpeed;        //移動速度(public = インスペクタで調整は可能)
    public  float               m_rotationSpeed;    //プレイヤーの回転速度(public = インスペクタでは調整は可能)

    private Vector3 m_movePower = Vector3.zero;     //キャラクターの移動量
    private float   m_jumpPower = 10.0f;            //キャラクターの跳躍力(使用するなら)
    private const float m_gravityPower = 9.8f;      //キャラクター重力(ジャンプ使用するなら)

    public void Hit()                               //ヒット時のアニメーション(現状は何も書いてないベータ？で入れる予定ではある)
    { 
    }

    // Start is called before the first frame update
    //■最初に一回だけ実行するsy鳥
    void Start()
    {
        m_charaCon = GetComponent<CharacterController>();    //キャラクターのコントローラーのコンポーネントを参照する
        m_animeCon = GetComponent<Animator>();               //アニメーターのコンポーネントを参照する
        
    }

    // Update is called once per frame
    //■毎フレーム常に実行する処理
    void Update()
    {
        //▼▼▼移動処理▼▼▼
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) //テンキーや3Dスティックの入力(GetAxis)がゼロの時の動作  ボタンが押されていないとき
        {
            m_animeCon.SetBool("Run", false);                                   //Runモーションを行わない
        }
        else                                                                    //テンキーや3Dスティックの入力(GetAxis)がゼロではないときの処理　ボタンが押されているとき
        {
            var m_CameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;                             //カメラが追従するための操作
            Vector3 m_direction = m_CameraForward * Input.GetAxis("Vertical") + Camera.main.transform.right * Input.GetAxis("Horizotal");    //テンキーや3Dスティックの入力(GetAxis)があるとdirectionに値を返す
            m_animeCon.SetBool("Run", true);                                                                                                 //Runモーションをする

            ChangeDrirection(m_direction);                                                                                                   //向きを返る動作の処理を実行する
            Move(m_direction);                                                                                                               //移動する動作の処理を実行する

            //▼▼▼アクション処理▼▼▼
            m_animeCon.SetBool("Action", Input.GetKey("x") || Input.GetButtonDown("Action1"));                                                //キーorボタンを押したらアクションを実行
            m_animeCon.SetBool("Action2", Input.GetKey("z") || Input.GetButtonDown("Action2"));                                               //キーorボタンを押したらアクション2を実行
            m_animeCon.SetBool("Action3", Input.GetKey("c") || Input.GetButtonDown("Action3"));                                               //キーorボタンを押したらアクション3を実行
            m_animeCon.SetBool("Action4", Input.GetKey("space") || Input.GetButtonDown("Action4"));                                           //キーorボタンを押したらアクションを実行(仮実装)
        }
    }

    //■向きを変える動作の処理
    void ChangeDrirection(Vector3 direction)
    {
        Quaternion q = Quaternion.LookRotation(direction);                                                          //向きたい横行をQuaternion型に直す
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, m_rotationSpeed * Time.deltaTime);     //向きをqに向けて少しずつ変化させる
    }

    //■移動する動作の処理
    void Move(Vector3 moveDistance)
    {
        m_charaCon.Move(moveDistance * Time.deltaTime * m_moveSpeed);   //プレイヤーの移動距離は時間×移動スピードの値
    }
}
