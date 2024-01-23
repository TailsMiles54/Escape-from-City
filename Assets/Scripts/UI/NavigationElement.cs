using System;
using UnityEngine;
using Zenject;

public class NavigationElement : MonoBehaviour
{
    [field: SerializeField] public NavigationElementType NavigationElementType { get; private set; }

    [Inject] private UIService _uiService;

    public void Transition()
    {
        _uiService.TabTransition(NavigationElementType);
    }
}