using System;
using UnityEngine;
using UnityEngine.UI;
namespace SkinSystem
{
public class SkinChangerView : MonoBehaviour
{
    public event Action NextSkinClicked;
    public event Action PreviousSkinClicked;
    public event Action ClearSkinsClicked;
    [SerializeField] private Button nextSkin;
    [SerializeField] private Button previousSkin;
    [SerializeField] private SkinViewer skinViewer;


    void OnEnable()
    {
        nextSkin.onClick.AddListener(OnNextSkinButtonClicked);
        previousSkin.onClick.AddListener(OnPreviousSkinButtonClicked);
    }

    void OnDisable()
    {
        nextSkin.onClick.RemoveListener(OnNextSkinButtonClicked);
        previousSkin.onClick.RemoveListener(OnPreviousSkinButtonClicked);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ClearSkinsClicked?.Invoke();
        }
    }

    private void OnNextSkinButtonClicked()
    {
        NextSkinClicked?.Invoke();
    }

    private void OnPreviousSkinButtonClicked()
    {
        PreviousSkinClicked?.Invoke();
    }

    public void ViewSkin(GameObject cosmicRocket)
    {
        skinViewer.ViewSkin(cosmicRocket);
    }

    public void ClearSkins()
    {
        skinViewer.ClearSkins();
    }
}
}