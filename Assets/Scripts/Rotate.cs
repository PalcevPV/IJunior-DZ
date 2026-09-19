using DG.Tweening;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 _angle;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;
    [SerializeField] private RotateMode _rotateMode;
    [SerializeField] private LoopType _loopType;
    [SerializeField] private Ease _ease;

    private void Start()
    {
        transform.DORotate(_angle, _duration, _rotateMode).SetLoops(_repeats, _loopType).SetEase(_ease);
    }
}
