using System.Collections.Generic;
using System.Linq;
using Project.Scripts.EnemyFabricCore;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Scripts.Temp
{
    public class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField] private EnemyFabricsController enemyFabricsController;
        private readonly List<Vector3> spawnPoints = new();
        private List<IEnemy> enemies = new();
        private float curTime = 0;
        public float speed = 4;
        public float period = 1f;

        private void Awake()
        {
            CreateSpawnPoints();
            enemies = enemyFabricsController.CreateRandomEnemies(10);
            foreach (var enemy in enemies)
            {
                enemy.Hide();
                var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
                enemy.SetPositionAndRotation(spawnPoint, quaternion.identity);
            }
        }

        private void CreateSpawnPoints()
        {
            var camera = Camera.main;
            var highestPosCenter = camera.ScreenToWorldPoint(new Vector3(0, 0, camera.transform.position.z));
            var newCenterY = Mathf.Abs(1.3f * highestPosCenter.y);
            var newCenterX = Mathf.Abs(0.75f * highestPosCenter.x);
            for (var i = 0; i < 5; i++)
            {
                var position = new Vector3(
                    Random.Range(-100,100) * 0.01f * newCenterX,
                    newCenterY,
                    0);
                spawnPoints.Add(position);
            }
        }

        private void FixedUpdate()
        {
            foreach (var enemy in enemies.Where(a => !a.IsHidden))
            {
                enemy.Move(Vector3.down, speed);
            }
        }

        private void Update()
        {
            curTime += Time.deltaTime;
        
            if (curTime > period)
            {
                curTime = 0;
                var enemy = enemies.FirstOrDefault(a => a.IsHidden);
                enemy?.Relieve();
            }
        }
    }
}