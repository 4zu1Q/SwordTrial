using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float _speed = 0.01f;

    void Update()
    {
        if (Input.anyKey)
        {
            var velocity = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                velocity.z = _speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                velocity.x = -_speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                velocity.z = -_speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                velocity.x = _speed;
            }
            if (velocity.x != 0 || velocity.z != 0)
            {
                transform.position += transform.rotation * velocity;
            }
        }
    }
}
