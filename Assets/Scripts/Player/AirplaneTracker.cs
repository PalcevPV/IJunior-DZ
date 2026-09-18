using UnityEngine;

public class AirplaneTracker : MonoBehaviour
{
    [SerializeField] private Airplane _bird;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        var position = transform.position;
        position.x = _bird.transform.position.x + _xOffset;
        transform.position = position;
    }
}
