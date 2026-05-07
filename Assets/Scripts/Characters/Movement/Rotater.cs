using UnityEngine;

public class Rotater : MonoBehaviour
{
    private float _rotationY = 180;
    private bool _facingRight = true;

    public void Flip(float direction)
    {
        if (direction > 0 && _facingRight == false)
        {
            transform.Rotate(0, _rotationY, 0);
            _facingRight = true;
        }
        else if (direction < 0 && _facingRight)
        {
            transform.Rotate(0, _rotationY, 0);
            _facingRight = false;
        }
    }
}