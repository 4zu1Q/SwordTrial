//���C���V�[���̃V�[���J��

using UnityEngine;

public class MainSceneTransition : SceneTransitionBase
{
    //�^�C�}�[���
    private Timer m_timer;
    PauseUI m_Ui;

    protected override void Start()
    {
        base.Start();
        m_timer = GetComponent<Timer>();
        m_Ui = GetComponent<PauseUI>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        //DebugSceneTransition();
        //SceneTransitoinPause();
    }

    /// <summary>
    /// �f�o�b�O�p�V�[���J��
    /// </summary>
    private void DebugSceneTransition()
    {
        //A�{�^������������
        if (Input.GetButton("Abutton"))
        {
            m_fade.m_isFading = false;
            GetNextScene((int)SceneKinds.kWinScene);
        }
        //B�{�^������������A�܂��̓J�E���g�_�E�����I��������V�[���J��
        else if (Input.GetButton("Bbutton") || m_timer.GetFinishCountDown())
        {
            m_fade.m_isFading = false;
            GetNextScene((int)SceneKinds.kLoseScene);
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
