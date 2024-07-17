//���C���V�[���̃V�[���J��

using UnityEngine;

public class MainSceneTransition : SceneTransitionBase
{
    //�^�C�}�[���
    private Timer m_timer;
    private PauseUI m_Ui;

    //Player���
    [SerializeField] private Player m_player;
    //Enemy���
    [SerializeField] private EnemyC m_enemyState;

    //LoseScene�ɑJ�ڂ��邩�ǂ���
    private bool m_isLoseScene = false;
    //WinScene�ɑJ�ڂ��邩�ǂ���
    private bool m_isWinScene = false;

    protected override void Start()
    {
        base.Start();
        m_timer = GetComponent<Timer>();
        m_Ui = GetComponent<PauseUI>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        SetBoolScene();
        DebugSceneTransition();
        SceneTransitoinPause();
    }

    /// <summary>
    /// �V�[���J�ڂ��邩�ǂ����𔻒f����
    /// </summary>
    private void SetBoolScene()
    {
        // �s�k�V�[���ɑJ�ڂ��邩�̃t���O
        m_isLoseScene = (m_player.m_hp <= 0) || m_timer.GetFinishCountDown();
        // �����V�[���ɑJ�ڂ��邩�̃t���O
        m_isWinScene = m_enemyState.m_currentHP <= 0;
    }

    /// <summary>
    /// �f�o�b�O�p�V�[���J��
    /// </summary>
    private void DebugSceneTransition()
    {
        // �v���C���[�̗̑͂�0�܂��͎��Ԑ؂�ɂȂ�Ɣs�k��ʂ�
        if(m_isLoseScene)
        {
            m_fade.m_isFading = false;
            GetNextScene((int)SceneKinds.kLoseScene);
        }
        // �G�̗̑͂�0�ȉ��ɂȂ�Ώ�����ʂ�
        else if(m_isWinScene)
        {
            m_fade.m_isFading = false;
            GetNextScene((int)SceneKinds.kWinScene);
        }


    }
    /// <summary>
    /// �|�[�Y�̃V�[���J�ڂ̎���
    /// </summary>
    private void SceneTransitoinPause()
    {
        if (m_Ui.m_pauseNum[(int)PauseUI.SelectNum.kTitleBack])
        {
            m_fade.m_isFading = false;
            GetNextScene((int)SceneKinds.kTitleScene);
        }
    }
}
