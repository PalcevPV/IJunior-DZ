using System;
using UnityEngine;

[RequireComponent(typeof(RaycastHandler))]
public class BaseSelection : MonoBehaviour
{
    private RaycastHandler _raycastHandler;
    private Base _selectedBase;

    public event Action<BaseFlag> FlagPlaced;

    private void Awake()
    {
        _raycastHandler = GetComponent<RaycastHandler>();
    }

    private void OnEnable()
    {
        _raycastHandler.HitDetected += OnHitDetected;
    }

    private void OnDisable()
    {
        _raycastHandler.HitDetected -= OnHitDetected;
    }

    private void OnHitDetected(RaycastHit hit)
    {
        if (hit.collider.gameObject.TryGetComponent(out Base clickedBase))
        {
            _selectedBase = clickedBase;
        }

        if (_selectedBase != null && hit.collider.gameObject.TryGetComponent(out Ground ground))
        {
            BaseFlag flag = _selectedBase.GetComponent<BaseFlag>();
            flag.SetPosition(hit.point);

            FlagPlaced?.Invoke(flag);

            _selectedBase = null;
        }
    }
}
