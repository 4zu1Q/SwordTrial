using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUIRotation : MonoBehaviour
{
    void LateUpdate()
    {
        //カメラと同じ向きに変更
        transform.rotation = Camera.main.transform.rotation;
    }
}
