public class RaidStartNavigationElementBase : NavigationElementBase 
{
    public RaidStartNavigationElementBase() 
    {
        ThisNavigationElementType = NavigationElementType.RaidStart; 
    } 
    
    public override bool IsActive() 
    { 
        return false; 
    } 
}