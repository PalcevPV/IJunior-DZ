using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private Faction _faction;

    public Faction Faction => _faction;

    public event Action<Bullet> OutOfBounds;

    private void Update()
    {
        CheckOutOfBounds();
    }

    public void SetFaction(Faction faction)
    {
        _faction = faction;
    }

    private void CheckOutOfBounds()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPosition.x < 0 || viewportPosition.x > 1 ||
            viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            OutOfBounds?.Invoke(this);
        }
    }
}
