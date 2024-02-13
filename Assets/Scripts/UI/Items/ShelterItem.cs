using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShelterItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _infoText;
    [SerializeField] private TMP_Text _progressText;
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private Button _button;
    
    public void Setup(ShelterUpgradeType shelterUpgradeType, int level, ShelterManager shelterManager)
    {
        var upgradeSetting = SettingsProvider.Get<ShelterUpgradesList>().GetSetting(shelterUpgradeType);
        var maxLevel = upgradeSetting.MaxLevel;
        _infoText.SetText(shelterUpgradeType.ToString());
        _progressText.SetText($"Level: {level}/{maxLevel}");

        if (level >= maxLevel)
        {
            _buttonText.SetText("Max Level");
            _button.interactable = false;
        }
        else
        {
            _buttonText.SetText("Upgrade");
            _button.onClick.AddListener(() => {shelterManager.UpgradeShelter(shelterUpgradeType);});
        }
    }

    public void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }
}