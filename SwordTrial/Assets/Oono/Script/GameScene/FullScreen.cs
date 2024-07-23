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
            // �f�B�X�v���C���[�h�ɐ؂�ւ��܂�
            Screen.fullScreen = false;
            _isFullDisplay = false;
        }
        else
        {
            // �t���X�N���[�����[�h�ɐ؂�ւ��܂�
            Screen.fullScreen = true;
            _isFullDisplay = true;
        }
    }
    // �Q�[�����t���X�N�ɂ��邩�̏���
    private void KeyInput()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("a");
            GameDisplaySizeChenge();
        }
    }

}
