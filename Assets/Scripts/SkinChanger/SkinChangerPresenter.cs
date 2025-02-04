using System;
using UnityEngine;
using Zenject;
namespace SkinSystem
{
public class SkinChangerPresenter : IDisposable
{
    private readonly SkinChangerView view;
    private readonly SkinChangerModel model;


    [Inject]
    public SkinChangerPresenter(SkinChangerView view,
        SkinChangerModel model)
    {
        this.view = view;
        this.model = model;

        view.NextSkinClicked += HandleNextSkinChange;
        view.PreviousSkinClicked += HandlePreviousSkinChange;
        view.ClearSkinsClicked += ClearSkinsChange;
        model.SkinLoaded += OnSkinLoaded;
    }

    private void ClearSkinsChange()
    {
        model.ClearSkins();
        view.ClearSkins();
    }

    private void OnSkinLoaded(GameObject skin)
    {
        view.ViewSkin(skin);
    }

    public void SetCurrentSkin()
    {
        model.SetCurrentSkin();
    }

    private void HandleNextSkinChange()
    {
        model.SetNextSkin();
    }
    private void HandlePreviousSkinChange()
    {
        model.SetPreviousSkin();
    }
    public void Dispose()
    {
        view.NextSkinClicked -= HandleNextSkinChange;
        view.PreviousSkinClicked -= HandlePreviousSkinChange;
        model.SkinLoaded -= OnSkinLoaded;
        view.ClearSkinsClicked -= ClearSkinsChange;
    }
}
}