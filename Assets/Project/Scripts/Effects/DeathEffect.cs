using UnityEngine;

namespace Project.Scripts.Effects
{
    public class DeathEffect : MonoBehaviour
    {
        [SerializeField] private GameObject effect;

        public void Activate()
        {
            effect.GetComponent<ParticleSystem>().Play();
        }
        public void Deactivate()
        {
            effect.GetComponent<ParticleSystem>().Stop();
        }
    }
}
