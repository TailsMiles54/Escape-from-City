public class RaidProcessNavigationElementBase : NavigationElementBase 
{
    public RaidProcessNavigationElementBase() 
    {
        ThisNavigationElementType = NavigationElementType.RaidProcess; 
    }
    
    public override bool IsActive() 
    { 
        return false; 
    } 
}