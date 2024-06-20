//�t�F�[�h����

using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image m_image;//�t�F�[�h�̉摜
    //�t�F�[�h�����Ă��邩�ǂ���
    public bool m_isFading = true;
    public bool m_fadeEnd = false;

    //�t�F�[�h�̉摜�̓����x
    private byte m_colorA = 0;
    //�t�F�[�h�C���X�s�[�h
    private byte m_fadeInSpeed = 0;
    //�t�F�[�h�C���I�����̓����x
    private float m_fadeInFinish = 0.01f;
    //�t�F�[�h�A�E�g�X�s�[�h
    private byte m_fadeOutSpeed = 0;
    //�t�F�[�h�A�E�g�I�����̓����x
    private float m_fadeOutFinish = 0.99f;



    void Start()
    {
        m_image = GetComponent<Image>();
        m_isFading = true;
        m_colorA = 255;
    }

    void Update()
    {
        FadeUpdate();
    }

    /// <summary>
    /// �t�F�[�h����
    /// </summary>
    private void FadeUpdate()
    {
        FadeColor();

        // �t�F�[�h�C��.
        if (m_isFading)
        {
            FadeIn();
        }
        // �t�F�[�h�A�E�g.
        else
        {
            FadeOut();
        }
    }

    /// <summary>
    /// �t�F�[�h�C��
    /// </summary>
    private void FadeIn()
    {
        //�����x��0�̎��̓X�L�b�v
        if(m_image.color.a <= m_fadeInFinish)
        {
            m_colorA = 0;

            return;
        }
        m_colorA -= m_fadeInSpeed;
    }

    /// <summary>
    /// �t�F�[�h�A�E�g
    /// </summary>
    private void FadeOut()
    {
        if(m_image.color.a >= m_fadeOutFinish)
        {
            m_colorA = 255;
            m_fadeEnd = true;
            return;
        }
        m_colorA += m_fadeOutSpeed;
    }

    /// <summary>
    /// ���݂̃t�F�[�h��ʂ̐F
    /// </summary>
    private void FadeColor()
    {
        m_image.color = new Color32(0, 0, 0, m_colorA);
    }

}
