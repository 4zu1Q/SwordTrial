using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // UnityEngine.SceneManagemnt�̋@�\���g�p

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
