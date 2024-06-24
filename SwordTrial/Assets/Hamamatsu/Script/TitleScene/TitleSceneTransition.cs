// タイトルシーンにおけるシーン遷移処理

public class TitleSceneTransition : SceneTransitionBase
{
    protected override void Start()
    {
        base.Start();
        GetCurrentScene((int)SceneKinds.MainScene);
    }
}
