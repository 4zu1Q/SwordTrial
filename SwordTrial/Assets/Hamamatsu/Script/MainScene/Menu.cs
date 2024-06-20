//���j���[��ʏ���

using UnityEngine;

public class Menu : MonoBehaviour
{
    //���j���[���J�����ǂ���
    private bool m_openMenu = false;
    //���j���[�I�u�W�F�N�g
    [SerializeField] private GameObject m_menuObject;

    void Start()
    {
        m_openMenu = false;
        InitMenu();
    }

    void Update()
    {
        MenuFlag();
        DrawMenu();
    }

    /// <summary>
    /// ���j���[�̏�����
    /// </summary>
    private void InitMenu()
    {
        m_menuObject.SetActive(m_openMenu);
    }

    /// <summary>
    /// ���j���[�t���O�̃I���I�t����
    /// </summary>
    private void MenuFlag()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (m_openMenu)
            {
                m_openMenu = false;
            }
            else
            {
                m_openMenu = true;
            }
        }
    }

    private void DrawMenu()
    {
        m_menuObject.SetActive(m_openMenu);
    }

    public bool GetMenu() {  return m_openMenu; }
}