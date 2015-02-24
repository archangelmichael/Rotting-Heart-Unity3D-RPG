using UnityEngine;
public abstract class Button : MonoBehaviour, IButton
{
    public abstract void OnMouseEnter();

    public abstract void OnMouseExit();

    public abstract void OnMouseDown();
}
