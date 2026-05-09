using UnityEngine;

[RequireComponent (typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private static readonly int Attack = Animator.StringToHash("Attack");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(Attack);
    }
}
