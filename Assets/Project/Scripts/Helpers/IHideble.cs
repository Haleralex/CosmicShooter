namespace Project.Scripts.Helpers
{
    public interface IHideble
    {
        bool IsHidden { get; set; }
        void Hide();
        void Relieve();
    }
}