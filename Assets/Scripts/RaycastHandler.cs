using System;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    [SerializeField] private InputHandler _input;

    public event Action<RaycastHit> HitDetected;

    private void OnEnable()
    {
        _input.Clicked += PerformRaycast;
    }

    private void OnDisable()
    {
        _input.Clicked -= PerformRaycast;
    }

    private void PerformRaycast()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            HitDetected?.Invoke(hit);
        }
    }
}