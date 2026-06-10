using UnityEngine;

public abstract class BaseButton : MonoBehaviour
{
    protected int _healthCount = 10;
    
    public abstract void OnClick();
}