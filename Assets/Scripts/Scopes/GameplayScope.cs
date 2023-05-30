using Core;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class GameplayScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameManager>().AsSelf();
            builder.Register<ScoreController>(Lifetime.Singleton).AsSelf();
        }
    }
}