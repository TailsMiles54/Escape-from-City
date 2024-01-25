public class ShelterElementsNavigationElementBase : NavigationElementBase 
{
    public ShelterElementsNavigationElementBase() 
    {
        ThisNavigationElementType = NavigationElementType.ShelterElements; 
    } 
    
    public override bool IsActive() 
    { 
        return false; 
    } 
}