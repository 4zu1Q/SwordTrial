using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject m_playerObj;
    private Vector3 m_targetPos;
    private Transform m_transform;

    // Start is called before the first frame update
    void Start()
    {
        m_playerObj = GameObject.Find("Player");
        m_targetPos = m_playerObj.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの移動量分、カメラも移動する
        m_transform.position += m_playerObj.transform.position - m_targetPos;
        m_targetPos = m_playerObj.transform.position - m_targetPos;

        //プレイヤーが移動している間
        if(Input.GetMouseButtonDown(0))
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputZ = Input.GetAxis("Vertical");

            //プレイヤーの位置のY軸を中心に、回転する
            m_transform.RotateAround(m_targetPos, Vector3.up, inputX * Time.deltaTime * 200f);
        }



    }
}
