using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class NavigationElement : MonoBehaviour
{
    [field: SerializeField] public NavigationElementType NavigationElementType { get; private set; }
    [SerializeField] private GameObject _inactivePanel;

    [Inject] private UIService _uiService;

    public void Transition()
    {
        _uiService.TabTransition(NavigationElementType);
    }

    public void Activate(bool state)
    {
        var button = GetComponent<Button>();
        _inactivePanel.SetActive(state);
        button.interactable = !state;
    }
}