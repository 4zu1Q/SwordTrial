//選択UIの処理.

using UnityEngine;

public class SelectionUI : MonoBehaviour
{
    //選択する際の横の項目.
    private enum HorizontalSelectItem
    {
        Item1,
        Item2,
        Item3,
        Item4,
        MaxNum
    }

    //選択する際の縦の項目.
    private enum VerticalSelectItem
    {
        BossSelect,
        ItemSelect
    }


    //現在選択している横列の番号.
    private int m_currentHorizontalSelectionNum = 0;
    private int m_currentVerticalSelectionNum = 0;

    //選択しているUIの座標.
    private RectTransform m_rectTransform;

    //選択肢の座標.
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
    /// 選択するUIの座標移動.
    /// </summary>
    private void SelectionMove()
    {
        
    }

    /// <summary>
    /// 選択した際の座標.
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
