//UI�̑��쏈��

using UnityEngine;

public class UIOperationBase : MonoBehaviour
{
    private bool m_isSelect = false;    //�A���ړ���h���t���O
    public int m_selectNum = 0;//�I������Ă���ԍ�

    public GameObject m_selectCursor;//���삷��UI
    public GameObject[] m_itemUI;//�I�����ڂ�UI

    private RectTransform m_selectRectTransform;
    private RectTransform[] m_itemRectTransform;

    public void Start()
    {
        //�ϐ��̏�����
        m_isSelect=false;
        m_selectNum = 0;
        //�z��̒����͑I�����ڐ�
        m_itemRectTransform = new RectTransform[m_itemUI.Length];
        m_selectRectTransform = m_selectCursor.GetComponent<RectTransform>();

        for (int UINum = 0; UINum < m_itemUI.Length; UINum++)
        {
            m_itemRectTransform[UINum] = m_itemUI[UINum].GetComponent<RectTransform>();
        }
    }

    //Update�ɌĂяo���֐�
    public void UpdateFunction()
    {
        ItemCursorChange();
        SelectUIPosition();
    }


    /// <summary>
    /// �I�����ڂ̕ύX����
    /// </summary>
    public void ItemCursorChange()
    {
        //�X�e�B�b�N�̓��͒l���i�[
        float LeftStick = Input.GetAxis("Vertical");

        //�J�[�\�������ɓ�����
        if (LeftStick <= -0.5f && !m_isSelect)
        {
            m_isSelect = true;
            m_selectNum++;
            if (m_selectNum > m_itemUI.Length - 1)
            {
                m_selectNum = 0;
            }
        }
        //�J�[�\������ɓ�����
        else if (LeftStick >= 0.5f && !m_isSelect)
        {
            m_isSelect = true;
            m_selectNum--;
            if (m_selectNum < 0)
            {
                m_selectNum = m_itemUI.Length - 1;
            }
        }
        else if (LeftStick >= -0.1f && LeftStick <= 0.1f)
        {
            m_isSelect = false;
        }
    }

    /// <summary>
    /// ���삷��UI�̍��W����
    /// </summary>
    public void SelectUIPosition()
    {
        //m_selectRectTransform.position = m_itemRectTransform[(int)m_selectNum].position;
        m_selectRectTransform.position = new Vector3(m_selectRectTransform.position.x,
            m_itemRectTransform[(int)m_selectNum].position.y, 0);
    }
}
