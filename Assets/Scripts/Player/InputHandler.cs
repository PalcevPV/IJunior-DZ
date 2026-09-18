using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private bool _isJump;
    private bool _isAttack;
    private int _attackButton = 0;
    private KeyCode _jumpButton = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(_jumpButton))
        {
            _isJump = true;
        }

        if (Input.GetMouseButtonDown(_attackButton))
        {
            _isAttack = true;
        }
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);
    public bool GetIsAttack() => GetBoolAsTrigger(ref _isAttack);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}