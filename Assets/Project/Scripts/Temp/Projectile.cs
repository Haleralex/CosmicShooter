using Project.Scripts.Effects;
using UnityEngine;

namespace Project.Scripts.Temp
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private DeathEffect deathEffect;
        [SerializeField] private Collider collider;
        [SerializeField] private MeshRenderer meshRenderer;
        public bool IsDead = false;
        public void Deactivate()
        {
            KillWithoutEffect();
        }
        public void Restart()
        {
            CancelInvoke(nameof(KillWithoutEffect));
            IsDead = false;
            Invoke(nameof(KillWithoutEffect), 2f);
            deathEffect.Deactivate();
            collider.enabled = true;
            meshRenderer.enabled = true;
        }

        public void Kill()
        {
            meshRenderer.enabled = false;
            collider.enabled = false;
            IsDead = true;
            deathEffect.Activate();
        }
        public void KillWithoutEffect()
        {
            meshRenderer.enabled = false;
            collider.enabled = false;
            IsDead = true;
            deathEffect.Deactivate();
        }
    }
}
