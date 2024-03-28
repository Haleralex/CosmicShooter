using UnityEngine;

namespace Project.Scripts.EnemyFabricCore
{
    public abstract class Enemy : MonoBehaviour, IEnemy
    {
        public abstract void Initialize();

        public abstract void SetPositionAndRotation(Vector3 targetPosition, Quaternion rotation);
        public abstract void Move(Vector3 direction, float speed);


        public abstract bool IsHidden { get; set; }
        public abstract void Hide();
        public abstract void Relieve();
    }
}