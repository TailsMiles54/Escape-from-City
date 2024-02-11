using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _secondText;
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private Button _button;
    
    public void Setup(ActionSetting setting)
    {
        _titleText.SetText(setting.ActionType.ToString());
        _buttonText.SetText(TimeSpan.FromSeconds(setting.Seconds).TotalMinutes.ToString());
    }
}
