using UnityEngine;

public class NavigationElementBase
{
    public NavigationElementType ThisNavigationElementType;
    
    public virtual bool IsActive()
    {
        return false;
    }

    public virtual bool HasNotification()
    {
        return false;
    }

    public virtual void OnClick()
    {
        
    }

    public virtual BasePanel CreatePanel(Transform transformParent)
    {
        return null;
    }

    public virtual BasePanelSettings GetPanelSettings()
    {
        return null;
    }
}