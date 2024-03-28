using UnityEngine;

namespace Project.Scripts.EnemyFabricCore
{
    public abstract class AbstractEnemyFactory : MonoBehaviour, IAbstractEnemyFactory
    {
        [SerializeField] private protected Enemy enemyPrefab;
        public abstract IEnemy CreateEnemy();
    }
}
