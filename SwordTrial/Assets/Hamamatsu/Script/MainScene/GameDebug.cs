using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDebug : MonoBehaviour
{
    public enum SelectNum
    {
        kRetry, //�X�^�[�g
        kOption,//����
        kSelect,   //�I��
    }

    private bool m_isSelect;        //�A��
    private SelectNum m_selectNum;  //�I��

    // Start is called before the first frame update
    void Start()
    {
        //�ϐ�������
        m_isSelect = false;
        m_selectNum = SelectNum.kRetry;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{name}");

        //�X�e�B�b�N�̓��͒l���i�[
        float input = Input.GetAxis("Vertical");

        if (input <= -0.5f && !m_isSelect)
        {
            m_isSelect = true;
            m_selectNum = SelectNum.kSelect;
            Debug.Log("Win");
        }
        else m_isSelect = false;



        if (input >= 0.5f && !m_isSelect)
        {
            m_isSelect = true;
            m_selectNum = SelectNum.kRetry;
            Debug.Log("Lose");
        }
        else m_isSelect = false;


        //���������������悤
        if (input >= -0.1f && input <= 0.1f)
        {
            m_isSelect = false;
        }



        //A�{�^������������
        if (Input.GetButton("Abutton") && m_selectNum == SelectNum.kRetry)
        {
            //�Q�[���V�[���Ɉړ�
            SceneManager.LoadScene("WinScene");
        }
        else if (Input.GetButton("Abutton") && m_selectNum == SelectNum.kSelect)
        {
            //�Z���N�g�V�[���Ɉڍs
            SceneManager.LoadScene("LoseScene");
        }
    }
}
