using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action EnteredTheHouse;
    public event Action LeftTheHouse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            EnteredTheHouse?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            LeftTheHouse?.Invoke();
        }
    }
}