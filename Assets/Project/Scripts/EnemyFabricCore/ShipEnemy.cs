using System;
using Project.Scripts.DamageReceiving;
using Project.Scripts.Effects;
using Project.Scripts.Temp;
using UniRx;
using UnityEngine;

namespace Project.Scripts.EnemyFabricCore
{
    public class ShipEnemy : Enemy
    {
        [SerializeField] private ShipEnemyEffectsControlller effectsController;
        [SerializeField] private ShipEnemyDamageMediator damageMediator;
        [SerializeField] private Rigidbody shipEnemyRigidbody;
        private CharacterCondition CharacterCondition { get; } = new();
        private ShipEnemyDamageReceiver damageReceiver;
        private readonly CompositeDisposable disposable = new();
        public override bool IsHidden { get; set; } = false;

        public override void Initialize()
        {
            damageReceiver = new ShipEnemyDamageReceiver();
            damageMediator.SetDamageReceiver(damageReceiver);
            damageReceiver.DamageReceiving.Subscribe(OnDamageReceiving).AddTo(disposable);
        }

        public override void Hide()
        {
            IsHidden = true;
            gameObject.SetActive(false);
        }

        public override void Relieve()
        {
            IsHidden = false;
            gameObject.SetActive(true);
        }

        public override void SetPositionAndRotation(Vector3 targetPosition, Quaternion rotation)
        {
            transform.SetPositionAndRotation(targetPosition, rotation);
        }

        public override void Move(Vector3 direction, float speed)
        {
            shipEnemyRigidbody.velocity = direction * speed;
        }

        private void OnDamageReceiving(int obj)
        {
            if (CharacterCondition.Health <= 0)
                throw new Exception("ShipEnemy already dead");

            CharacterCondition.Health -= obj;

            if (CharacterCondition.Health <= 0)
            {
                Death();
            }
        }

        private void Death()
        {
            effectsController.OnDead();
        }

        public void Restart()
        {
            effectsController.Restart();
            CharacterCondition.Health = CharacterCondition.DefaultHealth;
        }
    }
}