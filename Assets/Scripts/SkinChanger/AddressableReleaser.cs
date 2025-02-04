using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
namespace SkinSystem
{
    public class AddressableReleaser : IAddressableReleaser
    {
        public void Release(AsyncOperationHandle handle)
        {
            Addressables.Release(handle);
        }
    }
}