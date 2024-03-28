using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Scripts.EnemyFabricCore
{
    public class EnemyFabricsController : MonoBehaviour
    {
        [SerializeField] private List<AbstractEnemyFactory> enemyFactories = new();
    

        public List<IEnemy> CreateRandomEnemies(int amount)
        {
            List<IEnemy> enemies = new();
            for (int i = 0; i < amount; i++)
            {
                var randomFactory = enemyFactories[Random.Range(0, enemyFactories.Count)];
                enemies.Add(randomFactory.CreateEnemy());
            }

            return enemies;
        }
    }
}