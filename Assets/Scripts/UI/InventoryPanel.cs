using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : Panel<InventoryPanelSettings>
{
    [SerializeField] private TMP_Text _titleTMP;
    [SerializeField] private Transform _parentTransform;
        
    public override void Setup(InventoryPanelSettings settings)
    {
        _titleTMP.text = settings.Title;

        var inventoryElementPrefab = SettingsProvider.Get<PrefabSettings>().InventoryElement;
        
        foreach (var item in settings.Items)
        {
            var inventoryItem = Instantiate(inventoryElementPrefab, _parentTransform);
            inventoryItem.Setup(item);
        }
    }
}

public class InventoryPanelSettings : BasePanelSettings
{
    public string Title;
    public List<Item> Items;
}