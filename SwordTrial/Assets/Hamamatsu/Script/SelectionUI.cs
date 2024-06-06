//�I��UI�̏���.

using UnityEngine;

public class SelectionUI : MonoBehaviour
{
    //�I������ۂ̉��̍���.
    private enum HorizontalSelectItem
    {
        Item1,
        Item2,
        Item3,
        Item4,
        MaxNum
    }

    //�I������ۂ̏c�̍���.
    private enum VerticalSelectItem
    {
        BossSelect,
        ItemSelect
    }


    //���ݑI�����Ă��鉡��̔ԍ�.
    private int m_currentHorizontalSelectionNum = 0;
    private int m_currentVerticalSelectionNum = 0;

    //�I�����Ă���UI�̍��W.
    private RectTransform m_rectTransform;

    //�I�����̍��W.
    [SerializeField] private RectTransform[] m_Items;

    
    void Start()
    {
        m_rectTransform = GetComponent<RectTransform>();
    }

    
    void Update()
    {
        SelectionMove();
    }

    private void FixedUpdate()
    {
        SelectionPosition();
    }

    /// <summary>
    /// �I������UI�̍��W�ړ�.
    /// </summary>
    private void SelectionMove()
    {
        
    }

    /// <summary>
    /// �I�������ۂ̍��W.
    /// </summary>
    private void SelectionPosition()
    {
        if(m_currentVerticalSelectionNum == (int)VerticalSelectItem.BossSelect)
        {
            if (m_currentHorizontalSelectionNum == (int)HorizontalSelectItem.Item1)
            {
                m_rectTransform.position = m_Items[0].position;
            }
            else if (m_currentHorizontalSelectionNum == (int)HorizontalSelectItem.Item2)
            {
                m_rectTransform.position = m_Items[1].position;
            }
            else if (m_currentHorizontalSelectionNum == (int)HorizontalSelectItem.Item2)
            {
                m_rectTransform.position = m_Items[2].position;
            }
        }
        else if(m_currentVerticalSelectionNum== (int)VerticalSelectItem.ItemSelect)
        {
            if (m_currentHorizontalSelectionNum == (int)HorizontalSelectItem.Item1)
            {
                m_rectTransform.position = m_Items[3].position;
            }
            else if (m_currentHorizontalSelectionNum == (int)HorizontalSelectItem.Item2)
            {
                m_rectTransform.position = m_Items[4].position;
            }
            else if (m_currentHorizontalSelectionNum == (int)HorizontalSelectItem.Item3)
            {
                m_rectTransform.position = m_Items[5].position;
            }
            else if (m_currentHorizontalSelectionNum == (int)HorizontalSelectItem.Item4)
            {
                m_rectTransform.position = m_Items[6].position;
            }
        }
    }
}
