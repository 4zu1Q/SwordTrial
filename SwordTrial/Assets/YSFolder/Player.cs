using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Player : MonoBehaviour
{
    /*変数宣言*/
    GameObject target;  
    private float m_velocity;
    private bool m_isMove;  //移動できるかのフラグ

    private Vector3 m_prevPos;  //前の


    // Start is called before the first frame update
    void Start()
    {
        //Mathf.Sin(Radian);


        m_velocity = 0.01f;
        m_isMove = false;



    }

    // Update is called once per frame
    void Update()
    {
       

        //ダッシュ処理

        //Aボタン
        //押している間はダッシュする
        if (Input.GetButton("Abutton"))
        {
            m_velocity = 0.02f;
            Debug.Log("dash");
        }
        else m_velocity = 0.01f;
        

        //Bボタン
        if (Input.GetButtonDown("Bbutton"))
        {

            Debug.Log("item");
        }

        //Xボタン
        if (Input.GetButtonDown("Xbutton"))
        {

            Debug.Log("attack");
            m_isMove = true;
        }
        else
        {
            m_isMove = false;
        }

        //Yボタン
        if (Input.GetButtonDown("Ybutton"))
        {
            Debug.Log("nanimonasi");
            transform.position = new Vector3 (transform.position.x , transform.position.y + 0.8f, transform.position.z);
        }

        if (Input.GetButtonDown("Pause"))
        {
            Debug.Log("ポーズ");

        }

        if (Input.GetButtonDown("Target"))
        {
            Debug.Log("ターゲット");

        }

        if (Input.GetButtonDown("R1"))
        {
            Debug.Log("R1");

        }

        //if (Input.GetButtonDown("R2"))
        //{

        //}

        //インプット値を取得
        float inputX = Input.GetAxis("Horizontal") * m_velocity;
        float inputZ = Input.GetAxis("Vertical") * m_velocity;


        if (!m_isMove)
        {
            //移動処理
            transform.position = new Vector3(transform.position.x + inputX, transform.position.y, transform.position.z + inputZ);

        }
    }
}
