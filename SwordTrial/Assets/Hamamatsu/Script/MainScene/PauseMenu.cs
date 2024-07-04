//メニュー画面処理

using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //メニューを開くかどうか
    private bool m_openMenu = false;
    //メニューオブジェクト
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

        //Debug.Log(m_openMenu);
    }

    /// <summary>
    /// メニューの初期化
    /// </summary>
    private void InitMenu()
    {
        m_menuObject.SetActive(m_openMenu);
    }

    /// <summary>
    /// メニューフラグのオンオフ処理
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
    }

    private void DrawMenu()
    {
        m_menuObject.SetActive(m_openMenu);
    }

    public bool GetMenu() {  return m_openMenu; }
}
