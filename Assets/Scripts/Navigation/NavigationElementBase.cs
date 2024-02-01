using UnityEngine;
using Zenject;

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

    public virtual BasePanel CreatePanel(Transform transformParent, Player player, PopupController popupController)
    {
        return null;
    }

    public virtual BasePanelSettings GetPanelSettings()
    {
        return null;
    }
}