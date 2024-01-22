using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "EscapeFromCity/PrefabSettings", fileName = "PrefabSettings", order = 0)]
public class PrefabSettings : ScriptableObject
{
    [SerializeField] private List<BasePanel> _panels;
    
    public T GetPanel<T>() where T : BasePanel
    {
        return (T)_panels.First(x => x is T);
    }
}