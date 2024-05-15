using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // UnityEngine.SceneManagemntの機能を使用

public class SceneTransition : MonoBehaviour
{
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
            SceneManager.LoadScene("SelectScene");
        //}
    }
}
