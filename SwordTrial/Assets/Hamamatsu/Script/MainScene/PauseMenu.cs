//���j���[��ʏ���

using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //���j���[���J�����ǂ���
    private bool m_openMenu = false;
    //���j���[�I�u�W�F�N�g
    [SerializeField] private GameObject m_menuObject;
    //�v���C���[�̎擾
    [SerializeField] private Player m_player;
    //�G�l�~�[�̎擾
    [SerializeField] private EnemyC m_enemy;

    void Start()
    {
        m_openMenu = false;
        InitMenu();
    }

    void Update()
    {
        MenuFlag();
        DrawMenu();

        //Debug.Log(m_openMenu);
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
            Debug.Log(m_openMenu);

            if (m_openMenu)
            {
                m_openMenu = false;
            }
            else
            {
                m_openMenu = true;
            }
        }
        PauseFlag();
    }
    /// <summary>
    /// �v���C���[�ƃG�l�~�[�̓����̒�~
    /// </summary>
    private void PauseFlag()
    {
        var pause = !m_openMenu;
        m_player.m_isPause = pause;
        m_enemy.m_isPause = pause;
    }

    private void DrawMenu()
    {
        m_menuObject.SetActive(m_openMenu);
    }

    public bool GetMenu() {  return m_openMenu; }

    public void GetPauseFlag(bool isPause) { m_openMenu = isPause; }
}
