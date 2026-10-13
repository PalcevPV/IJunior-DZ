using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BotMover), typeof(BotRotator))]
public class Bot : MonoBehaviour
{
    [SerializeField] private Transform _carryPoint;
    private Coroutine _coroutine;
    private BotMover _mover;
    private BotRotator _rotator;

    public bool IsBusy { get; private set; }
    public event Action<Resource> ResourceDelivered;
    public event Action<Bot> ArrivedToFlag;

    private void Awake()
    {
        _mover = GetComponent<BotMover>();
        _rotator = GetComponent<BotRotator>();
    }

    public void Restart()
    {
        IsBusy = false;
    }

    public void Collect(Resource resource, Transform deliveryPoint)
    {
        IsBusy = true;

        _coroutine = StartCoroutine(DeliviryResource(resource, deliveryPoint));
    }

    public void MoveToFlag(Transform target)
    {
        IsBusy = true;
        StartCoroutine(TravelToFlag(target));
    }

    private IEnumerator TravelToFlag(Transform target)
    {
        yield return MoveTo(target);
        ArrivedToFlag?.Invoke(this);
    }

    private IEnumerator DeliviryResource(Resource target, Transform deliveryPoint)
    {
        yield return MoveTo(target.transform);

        TakeResource(target);

        yield return MoveTo(deliveryPoint);

        StopCoroutine(_coroutine);

        ReleaseResource(target);
        ResourceDelivered?.Invoke(target);
        IsBusy = false;
    }

    private IEnumerator MoveTo(Transform target)
    {
        while (_mover.HasArrived(target.position) == false)
        {
            _rotator.RotateTo(target.position);
            _mover.MoveTo(target.position);
            yield return null;
        }
    }

    private void TakeResource(Resource resource)
    {
        resource.transform.SetParent(_carryPoint);
        resource.transform.localPosition = Vector3.zero;
        resource.transform.localRotation = Quaternion.identity;
    }

    private void ReleaseResource(Resource resource)
    {
        resource.transform.SetParent(null);
    }
}
