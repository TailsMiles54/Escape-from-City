using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "EscapeFromCity/SettingsProvider", fileName = "SettingsProvider", order = 0)]
public class SettingsProvider : ScriptableObject
{
    private List<ScriptableObject> _settingsList;
    
    private static SettingsProvider _settingsProvider;

    public static T Get<T>() where T : ScriptableObject
    {
        if (_settingsProvider == null)
        {
            _settingsProvider = Resources.Load<SettingsProvider>("SettingsProvider");
        }
        
        return (T)_settingsProvider._settingsList.First(x => x is T);
    }
}

[CreateAssetMenu(menuName = "EscapeFromCity/PrefabSettings", fileName = "PrefabSettings", order = 0)]
public class PrefabSettings : ScriptableObject
{
    [SerializeField] private List<BasePanel> _panels;
    
    public T GetPanel<T>() where T : BasePanel
    {
        return (T)_panels.First(x => x is T);
    }
}