using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public Action EnteredTheHouse;
    public Action LeftTheHouse;

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