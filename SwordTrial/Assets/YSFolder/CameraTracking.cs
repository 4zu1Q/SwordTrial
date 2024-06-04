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

        if(Input.GetButton("Abutton"))
        {
            float inputX = Input.GetAxis("Horizontal2");
            float inputZ = Input.GetAxis("Vertical2");

            transform.RotateAround(m_targetPos, Vector3.up, inputX * Time.deltaTime * 200f);

            transform.RotateAround(m_targetPos, transform.right, inputZ * Time.deltaTime * 200f);
        }



    }
}
