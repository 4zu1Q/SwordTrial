using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���؂�ւ��̂���

public class SelectSelsect : MonoBehaviour
{
    public enum SelectNum
    {
        kStart, //�X�^�[�g
        kOption,//����
        kEnd,   //�I��
    }

    private bool m_isSelect;        //�A��
    private SelectNum m_selectNum;  //�I��

    // Start is called before the first frame update
    void Start()
    {
        //�ϐ�������
        m_isSelect = false;
        m_selectNum = SelectNum.kStart;
    }

    // Update is called once per frame
    void Update()
    {
        //�X�e�B�b�N�̓��͒l���i�[
        float input = Input.GetAxis("Vertical");

        if (input <= -0.5f && !m_isSelect)
        {
            m_isSelect = true;
            m_selectNum = SelectNum.kEnd;
            Debug.Log("end");
        }
        else m_isSelect = false;



        if (input >= 0.5f && !m_isSelect)
        {
            m_isSelect = true;
            m_selectNum = SelectNum.kStart;
            Debug.Log("start");
        }
        else m_isSelect = false;


        //���������������悤
        if (input >= -0.1f && input <= 0.1f)
        {
            m_isSelect = false;
        }

        //B�{�^������������
        if (Input.GetButton("Bbutton"))
        {
            //�O�̃V�[���ɖ߂�
            SceneManager.LoadScene("TitleScene");
        }


        //A�{�^������������
        if (Input.GetButton("Abutton") && m_selectNum == SelectNum.kStart)
        {
            //�Z���N�g�V�[���Ɉڍs
            SceneManager.LoadScene("GameScene");
        }


    }
}
