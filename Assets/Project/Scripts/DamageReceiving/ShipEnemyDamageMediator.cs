using System;
using UnityEngine;

namespace Project.Scripts.DamageReceiving
{
    public class ShipEnemyDamageMediator : MonoBehaviour, IDamageMediator
    {
        private IDamageReceiver _receiver;

        public void SetDamageReceiver(IDamageReceiver damageReceiver)
        {
            if (_receiver != null)
                throw new Exception("Damage receiver is not null");

            _receiver = damageReceiver;
        }
    
        public void DealDamage(IDamageReceiver receiver, int damage)
        {
            receiver.ReceiveDamage(damage);
        }

        public void OnCollisionEnter(Collision collision)
        {
            var dealer = collision.gameObject.GetComponentInChildren<IDamageDealer>();

            if (dealer == null)
                return;

            dealer.OnDamageDealed();
            DealDamage(_receiver, dealer.Damage);
        }
    }
}
