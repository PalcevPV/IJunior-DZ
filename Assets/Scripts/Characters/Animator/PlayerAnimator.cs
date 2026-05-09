using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int Attack = Animator.StringToHash("Attack");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void UpdateMovement(float moveInput, bool isGrounded)
    {
        _animator.SetBool(IsMoving, moveInput != 0f && isGrounded);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(Attack);
    }
}
