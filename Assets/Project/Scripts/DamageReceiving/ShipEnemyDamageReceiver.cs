using UniRx;

namespace Project.Scripts.DamageReceiving
{
    public class ShipEnemyDamageReceiver : IDamageReceiver
    {
        public ReactiveCommand<int> DamageReceiving = new();
        public void ReceiveDamage(int damage)
        {
            DamageReceiving.Execute(damage);
        }
    }
}
