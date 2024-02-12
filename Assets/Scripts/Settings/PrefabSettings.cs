using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "EscapeFromCity/PrefabSettings", fileName = "PrefabSettings", order = 0)]
public class PrefabSettings : ScriptableObject
{
    [SerializeField] private List<BasePanel> _panels;
    [SerializeField] private List<BasePopup> _popups;

    [field: SerializeField] public InventoryElement InventoryElement { get; private set; }
    [field: SerializeField] public Sprite TestImage { get; private set; }
    [field: SerializeField] public Sprite PMCImage { get; private set; }
    [field: SerializeField] public Sprite TrampImage { get; private set; }
    [field: SerializeField] public LocationPanel LocationPanelPrefab { get; private set; }
    [field: SerializeField] public ActionItem ActionItem { get; private set; }
    [field: SerializeField] public ShelterItem ShelterItem { get; private set; }

    public T GetPanel<T>() where T : BasePanel
    {
        return (T)_panels.First(x => x is T);
    }
        
    public T GetPopup<T>() where T : BasePopup
    {
        return (T)_popups.First(x => x is T);
    }
}