using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerState : MonoBehaviour
{
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        UpdateFunc();
    }

    private void FixedUpdate()
    {
        FixedUpdateFunc();
    }



}