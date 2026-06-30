using UnityEngine;

public class VampirismView : MonoBehaviour
{
    [SerializeField] private TargetFinder _targetFinder;
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private SpriteRenderer _radius;
    [SerializeField] private SmoothBarView _bar;

    private float _radiusToDiameterMultiplier = 2;

    private void Awake()
    {
        HideRadius();
        _radius.transform.localScale = Vector3.one * _targetFinder.Radius * _radiusToDiameterMultiplier;
    }


    private void OnEnable()
    {
        _vampirism.AmountChanged += OnValueChanged;
        _vampirism.AbilityActivated += ShowRadius;
        _vampirism.AbilityDeactivated += HideRadius;
    }

    private void OnDisable()
    {
        _vampirism.AmountChanged -= OnValueChanged;
        _vampirism.AbilityActivated -= ShowRadius;
        _vampirism.AbilityDeactivated -= HideRadius;
    }

    private void OnValueChanged(float value)
    {
        _bar.UpdateView(value);
    }

    private void ShowRadius()
    {
        _radius.enabled = true;
    }

    private void HideRadius()
    {
        _radius.enabled = false;
    }
}