using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���؂�ւ��̂���

public class TitleSelect : MonoBehaviour
{
    public enum SelectNum
    {
        kStart, //�X�^�[�g
        kOption,//����
        kEnd,   //�I��
    }

    private bool m_isSelect;        //�A��
    private SelectNum m_selectNum;  //�I��

    //������
    void Start()
    {
        //�ϐ�������
        m_isSelect= false;
        m_selectNum = SelectNum.kStart;
    }

    //����
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



        if(input >= 0.5f && !m_isSelect)
        {
            m_isSelect = true;
            m_selectNum = SelectNum.kStart;
            Debug.Log("start");
        }
        else m_isSelect = false;


        //���������������悤
        if(input >= -0.1f && input <= 0.1f)
        {
            m_isSelect = false;
        }



        //A�{�^������������
        if (Input.GetButton("Abutton") && m_selectNum == SelectNum.kStart)
        {
            //�Z���N�g�V�[���Ɉڍs
            SceneManager.LoadScene("SelectScene");
        }
        else if (Input.GetButton("Abutton") && m_selectNum == SelectNum.kOption)
        {
            //�����≹���̒����Ƃ��ł���悤�ȃE�B���h�E��W�J
            Debug.Log("�������J��");

        }
        else if (Input.GetButton("Abutton") && m_selectNum == SelectNum.kEnd)
        {
            //�Q�[���I��
            End();
        }

    }


    void End()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif

    }

}
