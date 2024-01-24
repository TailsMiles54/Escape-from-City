public interface INavigationElement
{
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
}