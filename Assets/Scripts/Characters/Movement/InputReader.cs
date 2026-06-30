using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";

    private bool _isJump;
    private bool _isAttack;
    private bool _isAbilityActive;
    private int _attackButton = 0;
    private int _abilityButton = 1;
    private KeyCode _jumpButton = KeyCode.Space;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(_jumpButton))
        {
            _isJump = true;
        }

        if (Input.GetMouseButtonDown(_attackButton))
        {
            _isAttack = true;
        }

        if (Input.GetMouseButton(_abilityButton))
        {
            _isAbilityActive = true;
        }
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);
    public bool GetIsAttack() => GetBoolAsTrigger(ref _isAttack);
    public bool GetIsAbility() => GetBoolAsTrigger(ref _isAbilityActive);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
