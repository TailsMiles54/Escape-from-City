public class SkillsNavigationElementBase : NavigationElementBase
{
    public SkillsNavigationElementBase()
    {
        ThisNavigationElementType = NavigationElementType.Skills;
    }

    public override bool IsActive()
    {
        return false;
    }
}