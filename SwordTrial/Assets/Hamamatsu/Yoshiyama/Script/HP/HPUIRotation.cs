using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUIRotation : MonoBehaviour
{
    void LateUpdate()
    {
        //ƒJƒƒ‰‚Æ“¯‚¶Œü‚«‚É•ÏX
        transform.rotation = Camera.main.transform.rotation;
    }
}
