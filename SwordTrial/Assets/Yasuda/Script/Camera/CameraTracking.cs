using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    private GameObject m_target;
    private Vector3 m_targetPos;




    // Start is called before the first frame update
    void Start()
    {
        m_target = GameObject.Find("Player");
        m_targetPos = m_target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += m_target.transform.position - m_targetPos;
        m_targetPos = m_target.transform.position;

        //スティックの入力値を格納
        float input = Input.GetAxis("Horizontal2");

        if (input <= -0.5f)
        {

            transform.RotateAround(m_targetPos, Vector3.up, input * Time.deltaTime * 200f);

            //transform.RotateAround(m_targetPos, transform.right, inputZ * Time.deltaTime * 200f);
        }
        else if (input >= 0.5f)
        {
            transform.RotateAround(m_targetPos, Vector3.up, input * Time.deltaTime * 200f);

        }




    }
}
