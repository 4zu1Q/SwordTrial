using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUIRotation : MonoBehaviour
{
    void LateUpdate()
    {
        //�J�����Ɠ��������ɕύX
        transform.rotation = Camera.main.transform.rotation;
    }
}
