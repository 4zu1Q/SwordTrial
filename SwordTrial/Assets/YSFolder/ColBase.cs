using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColBase : MonoBehaviour
{
    public Vector3 m_direction;                 // �����x�N�g��
    public float m_radius;                       // �����蔼�a
    private Quaternion m_qRot;

    // Use this for initialization
    void Start()
    {
        m_direction = new Vector3(0.0f, 0.5f, 0.0f);
        m_direction = m_qRot * m_direction;
        transform.rotation = m_qRot;
        m_radius = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
