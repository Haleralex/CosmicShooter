using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SkinSystem
{
    public class AddressableLoader : IAddressableLoader
    {
        public void LoadAssetAsync<T>(string address, Action<AsyncOperationHandle<T>> onComplete)
        {
            Addressables.LoadAssetAsync<T>(address).Completed += onComplete;
        }
    }
}