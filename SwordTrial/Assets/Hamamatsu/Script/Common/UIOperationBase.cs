//UI�̑��쏈��

using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIOperationBase : MonoBehaviour
{
    private bool m_isSelect = false;    //�A���ړ���h���t���O
    public int m_selectNum = 0;//�I������Ă���ԍ�

    public GameObject m_selectCursor;//���삷��UI
    public GameObject[] m_itemUI;//�I�����ڂ�UI

    private RectTransform m_selectRectTransform;
    private RectTransform[] m_itemRectTransform;

    private Image m_selectUIImg;
    private float m_selectCursorPosX;//�J�[�\���̃|�W�V�����擾
    private int m_prevSelectNum;//�O�ɑI�������ԍ�
    private float m_moveCursorSpeed;//�J�[�\���̈ړ����x
    private bool m_isDecision;//��������������ǂ���
    private Vector3[] m_itemDefaultRectTransform;//���Ƃ��Ƃ̉摜�̃T�C�Y�擾
    private float m_scaleChengeSize;//�ύX����傫���̃T�C�Y
    private float m_scaleChengeSpeed;//�X�P�[����ύX���鎞��
    private float m_scaleChengeRestoreSpeed;
    private int m_pressTime;//�������܂܂̎��Ԃ̎擾
    private int m_pressTimeMax;//�������܂܂̎��Ԃ̍ő�l

    public bool _isUIScaleChenge = false;
    protected virtual void Start()
    {
        //�ϐ��̏�����
        m_isSelect=false;
        m_selectNum = 0;
        //�z��̒����͑I�����ڐ�
        m_itemRectTransform = new RectTransform[m_itemUI.Length];
        m_itemDefaultRectTransform = new Vector3[m_itemUI.Length];
        m_selectRectTransform = m_selectCursor.GetComponent<RectTransform>();
        for (int UINum = 0; UINum < m_itemUI.Length; UINum++)
        {
            m_itemRectTransform[UINum] = m_itemUI[UINum].GetComponent<RectTransform>();
            m_itemDefaultRectTransform[UINum] = m_itemRectTransform[UINum].localScale;
        }
        m_selectUIImg = m_selectCursor.GetComponent<Image>();
        m_prevSelectNum = -1;
        m_moveCursorSpeed = 0.2f;
        m_selectCursorPosX = m_selectRectTransform.position.x;
        m_scaleChengeSize = 1.3f;
        m_scaleChengeSpeed = 1.0f;
        m_scaleChengeRestoreSpeed = 0.1f;
        m_pressTime = 0;
        m_pressTimeMax = 20;

        UIScalseChengeLoop();
    }

    //Update�ɌĂяo���֐�
    public void UpdateFunction()
    {
        ItemCursorChange();
        SelectUIPosition();
        UIScaleChengeUpdate();
    }


    /// <summary>
    /// �I�����ڂ̕ύX����
    /// </summary>
    private void ItemCursorChange()
    {
        //����{�^����������Ă�����ړ��ł��Ȃ�����
        if (m_isDecision) { return; }
        //�O�̑I��ł����ԍ��̎擾
        m_prevSelectNum = m_selectNum;

        //�X�e�B�b�N�̓��͒l���i�[
        float LeftStick = Input.GetAxis("Vertical");

        //�J�[�\�������ɓ�����
        if (LeftStick <= -0.5f)
        {
            if(!IsPressButtom() && m_isSelect) return;
            m_isSelect = true;
            m_selectNum++;
            if (m_selectNum > m_itemUI.Length - 1)
            {
                m_selectNum = 0;
            }
        }
        //�J�[�\������ɓ�����
        else if (LeftStick >= 0.5f)
        {
            if (!IsPressButtom() && m_isSelect) return;
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
            m_pressTime = 0;
        }
    }
    /// <summary>
    /// �{�^���������ς̎��̏���
    /// </summary>
    /// <returns>�������ςň�莞�Ԍo�߂������ǂ���</returns>
    private bool IsPressButtom()
    {
        m_pressTime++;
        if(m_pressTime >m_pressTimeMax)
        {
            m_pressTime = 0;
            return true;
        }
        return false;
    }

    /// <summary>
    /// ���삷��UI�̍��W����
    /// </summary>
    private void SelectUIPosition()
    {
        // �O�̃t���[���ƑI��ł������̂��قȂ�Ƃ��̂ݏ������s��
        if (m_selectNum != m_prevSelectNum)
        {
            //�w�肵�����W��m_moveCursorSpeed�b�����Ĉړ�����
            m_selectRectTransform.transform.DOMove(new Vector3(m_selectCursorPosX,
                m_itemRectTransform[(int)m_selectNum].position.y, 0), m_moveCursorSpeed).SetEase(Ease.OutCubic);
        }
    }
    /// <summary>
    /// UI�̉摜�̃X�P�[���̍X�V����
    /// </summary>
    private void UIScaleChengeUpdate()
    {
        // �O�̃t���[���ƑI��ł������̂��قȂ�Ƃ��̂ݏ������s��
        if (m_selectNum != m_prevSelectNum)
        {
            //�O�ɑI�����Ă����摜�̏������~�߂�
            m_itemRectTransform[(int)m_prevSelectNum].DOKill();
            //m_itemRectTransform[(int)m_prevSelectNum].transform.localScale = m_itemDefaultRectTransform[m_prevSelectNum];
            m_itemRectTransform[(int)m_prevSelectNum].DOScale((m_itemDefaultRectTransform[m_prevSelectNum]), m_scaleChengeRestoreSpeed)
                .SetEase(Ease.InOutSine);
            UIScalseChengeLoop();
        }
    }
    /// <summary>
    /// �I��ł���摜���g��k�����鏈��
    /// </summary>
    private void UIScalseChengeLoop()
    {
        if(_isUIScaleChenge) { return; }
        //�w�肵�����W��m_moveCursorSpeed�b�����Ĉړ�����
        m_itemRectTransform[(int)m_selectNum].transform.DOScale(new Vector3(m_scaleChengeSize,
            m_scaleChengeSize, 0), m_scaleChengeSpeed)
            .SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
    }
    /// <summary>
    /// ����������ꂽ�Ƃ��ɐF�̕ύX����
    /// </summary>
    public void SlectUIColorChenge(bool isPress)
    {
        if(isPress && m_selectUIImg.color != Color.red)
        { 
            m_selectUIImg.color = Color.red;
        }
        else if (!isPress && m_selectUIImg.color != Color.white)
        {
            m_selectUIImg.color = Color.white;
        }
    }
    /// <summary>
    /// ��������������ǂ������擾����
    /// </summary>
    /// <param name="decison"></param>
    public void DecisionUpdate(bool decison)
    {
        m_isDecision = decison;
    }
}
