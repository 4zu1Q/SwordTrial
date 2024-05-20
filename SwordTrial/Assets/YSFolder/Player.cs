using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Player : MonoBehaviour
{
    /*変数宣言*/
    GameObject target;  
    private float m_velocity;
    private bool m_isMove;  //移動できるかのフラグ

    

    // Start is called before the first frame update
    void Start()
    {
        m_velocity = 0.01f;
        m_isMove = false;   

    }

    // Update is called once per frame
    void Update()
    {
       

        //ダッシュ処理

        //Aボタン
        if (Input.GetButton("Fire1"))
        {
            m_velocity = 0.02f;
            Debug.Log("dash");
        }
        else m_velocity = 0.01f;
        

        //Bボタン
        if (Input.GetButtonDown("Fire2"))
        {

            Debug.Log("item");
        }

        //Xボタン
        if (Input.GetButtonDown("Fire3"))
        {

            Debug.Log("attack");
            m_isMove = true;
        }
        else
        {
            m_isMove = false;
        }

        //Yボタン
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("nanimonasi");
        }


        float inputX = Input.GetAxis("Horizontal") * m_velocity;
        float inputZ = Input.GetAxis("Vertical") * m_velocity;


        if (!m_isMove)
        {
            //移動処理
            transform.position = new Vector3(transform.position.x + inputX, transform.position.y, transform.position.z + inputZ);

        }
    }
}
