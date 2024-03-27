using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        base.InstallBindings();
        Container.Bind<GameController>().FromComponentInHierarchy().AsSingle().NonLazy();

    }
}
