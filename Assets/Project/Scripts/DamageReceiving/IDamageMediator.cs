namespace Project.Scripts.DamageReceiving
{
    public interface IDamageMediator
    {
        void DealDamage(IDamageReceiver receiver, int damage);
    }
}
