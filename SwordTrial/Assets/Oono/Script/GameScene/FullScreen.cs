using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    private bool _isFullDisplay = false;
    // Start is called before the first frame update
    void Start()
    {
        GameDisplaySizeChenge();
    }
    private void Update()
    {
        KeyInput();
    }
    private void GameDisplaySizeChenge()
    {
        if (_isFullDisplay)
        {
            // ディスプレイモードに切り替えます
            Screen.fullScreen = false;
            _isFullDisplay = false;
        }
        else
        {
            // フルスクリーンモードに切り替えます
            Screen.fullScreen = true;
            _isFullDisplay = true;
        }
    }
    // ゲームをフルスクにするかの処理
    private void KeyInput()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("a");
            GameDisplaySizeChenge();
        }
    }

}
