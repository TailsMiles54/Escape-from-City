using UnityEngine;

public class BasePopup : MonoBehaviour
{
    public virtual void Hide()
    {
        Destroy(gameObject);
    }
}