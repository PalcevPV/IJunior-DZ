using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void UpdateMovement(float moveInput, bool isGrounded)
    {
        _animator.SetBool(IsMoving, moveInput != 0f && isGrounded);
    }
}
