using Project.Scripts.Helpers;

namespace Project.Scripts.EnemyFabricCore
{
    public interface IEnemy : IMovable, IHideble
    {
        void Initialize();
    }
}
