using UnityEngine;

namespace Project.Scripts.Helpers
{
    public abstract class DefaultPool : MonoBehaviour
    {
        [SerializeField] private PoolObject prototype;
        private const int DEFAULT_AMOUNT_OF_OBJECTS = 10;
        public void CreatePool(int amount = DEFAULT_AMOUNT_OF_OBJECTS)
        {
            for (int i = 0; i < amount; i++)
            {
            
            }
        }
    }
}
