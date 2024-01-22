using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EscapeFromCity/RaritySetting", fileName = "RaritySetting", order = 0)]
public class RaritySetting : ScriptableObject
{
    [field: SerializeField] public List<RarityColor> RarityColors { get; private set;}

    [Serializable]
    public struct RarityColor
    {
        public Rarity Rarity;
        public Color Color;
    }
}