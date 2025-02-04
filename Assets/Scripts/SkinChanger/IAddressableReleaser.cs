using System;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
namespace SkinSystem
{
    public interface IAddressableReleaser
    {
        void Release(AsyncOperationHandle handle);

    }
}