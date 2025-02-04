using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;
namespace SkinSystem
{
    public class SkinChangerModel
    {
        public event Action<GameObject> SkinLoaded;

        private Skin currentSkin;
        private int CurrentIndex = 0;
        private readonly List<Skin> skins;
        private readonly Skin defaultSkin;
        private readonly IAddressableLoader addressableLoader;
        private readonly IAddressableReleaser addressableReleaser;
        private List<AsyncOperationHandle> handles = new();
        private Dictionary<string, GameObject> cachedSkins = new();

        [Inject]
        public SkinChangerModel(Skins skins,
            IAddressableLoader addressableLoader, IAddressableReleaser addressableReleaser)
        {
            this.skins = skins.SkinCollection.ToList();
            defaultSkin = skins.DefaultSkin;
            currentSkin = defaultSkin;
            CurrentIndex = this.skins.IndexOf(currentSkin);
            this.addressableLoader = addressableLoader;
            this.addressableReleaser = addressableReleaser;
        }

        public void SetNextSkin()
        {
            CurrentIndex++;
            CurrentIndex %= skins.Count;
            currentSkin = skins[CurrentIndex];

            SetCurrentSkin();
        }
        public void SetPreviousSkin()
        {
            CurrentIndex--;
            if (CurrentIndex == -1) CurrentIndex = skins.Count - 1;
            CurrentIndex %= skins.Count;
            currentSkin = skins[CurrentIndex];

            SetCurrentSkin();
        }

        public void SetCurrentSkin()
        {
            var assetGUID = currentSkin.AssetReference.AssetGUID;

            if (cachedSkins.TryGetValue(assetGUID, out var cahcedValue))
            {
                SkinLoaded?.Invoke(cahcedValue);
                return;
            }

            addressableLoader.LoadAssetAsync<GameObject>(assetGUID, handle =>
            {
                HandleSkinLoaded(handle, assetGUID);
            });
        }

        private void HandleSkinLoaded(AsyncOperationHandle<GameObject> handle, string assetGUID)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                var objResult = handle.Result;
                cachedSkins[assetGUID] = objResult;
                SkinLoaded?.Invoke(objResult);
                handles.Add(handle);
            }
            else
            {
                Debug.LogError($"Failed to load skin: {currentSkin.Guid}");
            }
        }

        public void ClearSkins()
        {
            cachedSkins.Clear();
            foreach (var handle in handles)
            {
                addressableReleaser.Release(handle);
            }
            handles.Clear();
        }
    }
}