using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ResultImg : MonoBehaviour
{
    [SerializeField] private Image m_img;//�摜�̎擾
    private float m_imgAnimTime;//�摜�̃A�j���[�V�����ɂ����鎞��
    private Vector3 m_defaultScale;//�f�t�H���g�̉摜�̃T�C�Y
    [SerializeField]private Vector3 m_chengeScale;// �摜�̃T�C�Y
    private float m_colorTime;// �F�̃t�F�[�h�ɂ����鎞��
    // Start is called before the first frame update
    void Start()
    {

        ImgAnim();
        ImgColorChenge();
    }
    /// <summary>
    /// �摜�̃T�C�Y�ύX����
    /// </summary>
    private void ImgAnim()
    {
        // �A�j���[�V�����̎��Ԏw��
        m_imgAnimTime = 2.0f;
        // �f�t�H���g�̉摜�̑傫�����擾
        m_defaultScale = m_img.transform.localScale;
        // �摜�̑傫����ύX����
        m_img.transform.localScale = m_chengeScale;
        // �摜���C�[�W���O���g�p���傫����ύX����
        m_img.transform.DOScale((m_defaultScale), m_imgAnimTime).SetEase(Ease.InOutSine);

    }
    /// <summary>
    /// �摜�̐F�Ƀt�F�[�h�������鏈��
    /// </summary>
    private void ImgColorChenge()
    {
        // �A�j���[�V�����̎��Ԏw��
        m_colorTime = 1.5f;
        // �F(�A���t�@�l)��0�ɂ���
        Color color = Color.white;
        color.a = 0;
        m_img.color = color;
        // �摜�̃t�F�[�h����
        m_img.DOFade(1, m_colorTime).SetEase(Ease.InOutQuint);
    }

}
