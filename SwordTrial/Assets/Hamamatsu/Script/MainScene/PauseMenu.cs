//メニュー画面処理

using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //メニューを開くかどうか
    private bool m_openMenu = false;
    //メニューオブジェクト
    [SerializeField] private GameObject m_menuObject;
    //プレイヤーの取得
    [SerializeField] private Player m_player;
    //エネミーの取得
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
        PauseFlag();
    }
    /// <summary>
    /// プレイヤーとエネミーの動きの停止
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
