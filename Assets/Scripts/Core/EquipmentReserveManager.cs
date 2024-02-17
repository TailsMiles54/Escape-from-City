using System.Collections.Generic;
using Zenject;

public class EquipmentReserveManager : IInitializable
{
    [Inject] private SaveManager _saveManager;
    [Inject] private UIService _uiService;
    public Dictionary<CharacterType, List<Item>> ReservedItems { get; private set; }
    
    public void Initialize()
    {
        
    }

    public void GenerateNewEquipmentForTramp()
    {
        
    }
}