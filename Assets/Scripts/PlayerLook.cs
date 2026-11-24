using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _horizontalSensitivity = 2f;
    [SerializeField] private float _verticalSensitivity = 2f;
    [SerializeField] private float _minVerticalAngle = -89f;
    [SerializeField] private float _maxVerticalAngle = 89f;

    private InputHandler _input;
    private float _cameraAngle = 0f;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
        _cameraAngle = _camera.localEulerAngles.x;
    }

    private void Update()
    {
        Vector2 look = _input.Look;

        transform.Rotate(Vector3.up, look.x * _horizontalSensitivity);

        _cameraAngle += look.y * _verticalSensitivity;
        _cameraAngle = Mathf.Clamp(_cameraAngle, _minVerticalAngle, _maxVerticalAngle);
        _camera.localEulerAngles = Vector3.right * -_cameraAngle;
    }
}
