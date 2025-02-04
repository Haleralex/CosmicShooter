using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace SkinSystem
{
public class SkinViewer : MonoBehaviour
{
    private readonly Dictionary<string, SkinGameObject> _skins = new();
    [SerializeField] private Transform _parent;

    public void ViewSkin(GameObject skinObject)
    {
        if (skinObject == null)
        {
            Debug.LogError("Skin cannot be null");
            return;
        }

        foreach (var skin in _skins)
        {
            skin.Value.gameObject.SetActive(false);
        }

        if (!_skins.TryGetValue(skinObject.name, out var instantiatedSkin))
        {
            instantiatedSkin = Instantiate(skinObject, _parent).GetComponent<SkinGameObject>();
            _skins[skinObject.name] = instantiatedSkin;
        }

        instantiatedSkin.gameObject.SetActive(true);
    }

    public void ClearSkins()
    {
        foreach (var k in _skins)
        {
            Destroy(k.Value.gameObject);
        }
        _skins.Clear();
    }
}}