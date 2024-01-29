using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "EscapeFromCity/PrefabSettings", fileName = "PrefabSettings", order = 0)]
public class PrefabSettings : ScriptableObject
{
    [SerializeField] private List<BasePanel> _panels;

    [field: SerializeField] public InventoryElement InventoryElement { get; private set; }
    [field: SerializeField] public Sprite TestImage { get; private set; }
    
    public T GetPanel<T>() where T : BasePanel
    {
        return (T)_panels.First(x => x is T);
    }
}