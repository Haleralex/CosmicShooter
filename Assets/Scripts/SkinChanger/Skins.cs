using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace SkinSystem
{
[CreateAssetMenu(fileName = "CosmicRocketSkins", menuName = "ScriptableObjects/CosmicRocketSkins", order = 1)]
public class Skins : ScriptableObject
{
    [SerializeField] private List<Skin> skins = new();
    public IReadOnlyCollection<Skin> SkinCollection => skins;

    [SerializeField] private Skin defaultSkin;
    public Skin DefaultSkin => defaultSkin;

}
}