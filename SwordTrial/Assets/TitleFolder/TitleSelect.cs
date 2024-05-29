using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���؂�ւ��̂���

public class TitleSelect : MonoBehaviour
{
    public enum SelectNum
    {
        kStart, //�X�^�[�g
        kEnd,   //�I��
    }

    private SelectNum m_selectNum;  //�I��

    //������
    void Start()
    {
        m_selectNum = SelectNum.kStart;
    }

    //����
    void Update()
    {


        //A�{�^������������
        if (Input.GetButton("Abutton") && m_selectNum == SelectNum.kStart)
        {
            SceneManager.LoadScene("SelectScene");
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
