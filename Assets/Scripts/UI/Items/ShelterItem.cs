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
    
    public void Setup(ShelterManager settingsShelterManager, ShelterUpgrade shelterUpgrade)
    {
        _infoText.SetText(shelterUpgrade.ToString());
        _progressText.SetText($"{shelterUpgrade.ToString()} 0/5");
        _buttonText.SetText("Upgrade");
    }
}