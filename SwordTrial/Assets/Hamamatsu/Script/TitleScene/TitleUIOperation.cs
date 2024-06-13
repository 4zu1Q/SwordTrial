//�^�C�g����ʂ�UI�̑���

using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIOperation : MonoBehaviour
{
    public enum SelectNum
    {
        kStart, //�X�^�[�g
        kOption,//�I�v�V����
        kEnd,   //�I��
    }

    private bool m_isSelect;        //�A��
    private SelectNum m_selectNum;  //�I��

    [SerializeField] private GameObject m_selectUI;//���삷��UI
    [SerializeField] private GameObject[] m_itemUI;//�I�����ڂ�UI

    private RectTransform m_selectRectTransform;
    private RectTransform[] m_itemRectTransform;

    //������
    void Start()
    {
        //�ϐ�������
        m_isSelect= false;
        m_selectNum = SelectNum.kStart;

        m_itemRectTransform = new RectTransform[m_itemUI.Length];//�z��̒����͑I�����ڐ�

        m_selectRectTransform = m_selectUI.GetComponent<RectTransform>();


        for(int UInum = 0; UInum < m_itemUI.Length; UInum++)
        {
            m_itemRectTransform[UInum] = m_itemUI[UInum].GetComponent<RectTransform>();
        }
    }

    //����
    void Update()
    {
        ItemChange();

        SelectUIPosition();
        



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
            //�Q�[���I��������
            //End();
            Debug.Log("�Q�[���I��");
        }

    }

    /// <summary>
    /// �I�����ڂ̕ύX����
    /// </summary>
    private void ItemChange()
    {
        //�X�e�B�b�N�̓��͒l���i�[
        float LeftStick = Input.GetAxis("Vertical");

#if true

        //�J�[�\�������ɓ�����
        if(LeftStick <= -0.5f && !m_isSelect)
        {
            m_isSelect = true;
            m_selectNum++;
            if(m_selectNum > SelectNum.kEnd) 
            {
                m_selectNum = SelectNum.kStart;
            }
        }
        //�J�[�\������ɓ�����
        else if(LeftStick >= 0.5f && !m_isSelect)
        {
            m_isSelect=true;
            m_selectNum--;
            if(m_selectNum < SelectNum.kStart)
            {
                m_selectNum = SelectNum.kEnd;
            }
        }
        else if(LeftStick >= -0.1f && LeftStick <= 0.1f)
        {
            m_isSelect=false;
        }

#else

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

#endif
    }


    /// <summary>
    /// ���삷��UI�̍��W����
    /// </summary>
    private void SelectUIPosition()
    {
        //m_selectRectTransform.position = m_itemRectTransform[(int)m_selectNum].position;
        m_selectRectTransform.position = new Vector3(m_selectRectTransform.position.x, 
            m_itemRectTransform[(int)m_selectNum].position.y, 0);
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
