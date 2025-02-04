using System;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
namespace SkinSystem
{
    public interface IAddressableLoader
    {
        void LoadAssetAsync<T>(string address, Action<AsyncOperationHandle<T>> onComplete);

    }
}