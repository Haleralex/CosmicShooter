namespace Project.Scripts.DamageReceiving
{
    public interface IDamageDealer
    {
        int Damage { get; set; }
        void OnDamageDealed();
    }
}
