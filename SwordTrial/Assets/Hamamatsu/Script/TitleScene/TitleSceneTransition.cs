// �^�C�g���V�[���ɂ�����V�[���J�ڏ���

public class TitleSceneTransition : SceneTransitionBase
{
    protected override void Start()
    {
        base.Start();
        GetCurrentScene((int)SceneKinds.MainScene);
    }
}
