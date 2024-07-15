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
    [SerializeField] private EnemyState m_enemyState;

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
        m_isLoseScene = (m_player.m_hp == 0) || m_timer.GetFinishCountDown();
        // �����V�[���ɑJ�ڂ��邩�̃t���O
        // TODO
        //m_isWinScene = m_enemyState.
    }

    /// <summary>
    /// �f�o�b�O�p�V�[���J��
    /// </summary>
    private void DebugSceneTransition()
    {
        //A�{�^������������
        //if (Input.GetButton("Abutton"))
        //{
        //    m_fade.m_isFading = false;
        //    GetNextScene((int)SceneKinds.kWinScene);
        //}
        ////B�{�^������������A�܂��̓J�E���g�_�E�����I��������V�[���J��
        //else if (Input.GetButton("Bbutton") || m_timer.GetFinishCountDown())
        //{
        //    m_fade.m_isFading = false;
        //    GetNextScene((int)SceneKinds.kLoseScene);
        //}

        // �v���C���[�̗̑͂�0�܂��͎��Ԑ؂�ɂȂ�Ɣs�k��ʂ�
        if(m_isLoseScene)
        {
            m_fade.m_isFading = false;
            GetNextScene((int)SceneKinds.kLoseScene);
        }
        // �G�̗̑͂�0�ȉ��ɂȂ�Ώ�����ʂ�
        // TODO�F��ɃG�l�~�[�̗̑͂��擾�o�����������ǉ�����
        //else
        //{
        //    m_fade.m_isFading = false;
        //    GetNextScene((int)SceneKinds.kWinScene);
        //}


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
