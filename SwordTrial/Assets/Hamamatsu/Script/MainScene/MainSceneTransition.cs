//���C���V�[���̃V�[���J��

using UnityEngine;

public class MainSceneTransition : SceneTransitionBase
{
    //�^�C�}�[���
    private Timer m_timer;

    protected override void Start()
    {
        base.Start();
        m_timer = GetComponent<Timer>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        DebugSceneTransition();
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
}
