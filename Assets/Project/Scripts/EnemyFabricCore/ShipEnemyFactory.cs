namespace Project.Scripts.EnemyFabricCore
{
    public class ShipEnemyFactory : AbstractEnemyFactory
    {
        public override IEnemy CreateEnemy()
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.Initialize();
            return enemy;
        }
    }
}
