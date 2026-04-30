using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;
    private static readonly int Attack = Animator.StringToHash("Attack");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(Attack);
    }
}
