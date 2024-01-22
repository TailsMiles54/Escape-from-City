using UnityEngine;

[CreateAssetMenu(menuName = "EscapeFromCity/Items/WeaponSetting", fileName = "WeaponSetting", order = 0)]
public class WeaponSetting : ItemSettings
{
    [field: SerializeField] public Sprite SpriteWithScope { get; private set;}
}