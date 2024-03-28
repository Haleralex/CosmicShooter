using UnityEngine;

namespace Project.Scripts.Effects
{
    public class ShipEnemyEffectsControlller : MonoBehaviour
    {
        [SerializeField] private GameObject model;

        public void Restart()
        {
            model.SetActive(true);
        }
        public void OnDead()
        {
            model.SetActive(false);
        }
    }
}
