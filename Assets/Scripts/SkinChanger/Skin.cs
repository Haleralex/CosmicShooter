using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SkinSystem
{
    [CreateAssetMenu(fileName = "Skins", menuName = "ScriptableObjects/Skins", order = 1)]
    public class Skin : ScriptableObject
    {
        public string Guid;
        [SerializeField] private AssetReferenceGameObject assetReference;
        public AssetReferenceGameObject AssetReference => assetReference;

        private void OnValidate()
        {
            if (string.IsNullOrEmpty(Guid))
            {
                Debug.LogWarning($"Skin {name} has no GUID assigned!");
            }

            if (assetReference == null)
            {
                Debug.LogError($"Skin {name} has no AssetReference assigned!");
            }
        }
    }
}