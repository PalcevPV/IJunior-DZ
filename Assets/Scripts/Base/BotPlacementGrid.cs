using System.Collections.Generic;
using UnityEngine;

public class BotPlacementGrid : MonoBehaviour
{
    [SerializeField] private Bounds _placementBounds;
    [SerializeField] private float _spacing;
    private List<Vector3> _positions;

    private void Awake()
    {
        _positions = CreateGridPositions();
    }

    public bool TryReserveSlot(out Vector3 position)
    {
        if (_positions.Count == 0)
        {
            position = Vector3.zero;
            return false;
        }

        position = _positions[0];
        _positions.Remove(position);

        return true;
    }

    private List<Vector3> CreateGridPositions()
    {
        List<Vector3> positions = new List<Vector3>();

        Vector3 min = _placementBounds.min;
        Vector3 max = _placementBounds.max;

        float halfSpacing = _spacing / 2f;

        for (float z = min.z + halfSpacing; z < max.z; z += _spacing)
        {
            for (float x = min.x + halfSpacing; x < max.x; x += _spacing)
            {
                Vector3 localPosition = new Vector3(x, _placementBounds.center.y, z);

                positions.Add(transform.TransformPoint(localPosition));
            }
        }

        return positions;
    }
}