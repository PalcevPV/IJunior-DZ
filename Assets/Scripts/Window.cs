using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _actionButton;
    protected float _maxAlpha = 1f;
    protected float _minAlpha = 0f;

    protected CanvasGroup WindowGroup => _windowGroup;
    protected Button ActionButton => _actionButton;

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Close()
    {
        WindowGroup.alpha = _minAlpha;
        WindowGroup.interactable = false;
        WindowGroup.blocksRaycasts = false;
        ActionButton.interactable = false;
    }

    public void Open()
    {
        WindowGroup.alpha = _maxAlpha;
        WindowGroup.interactable = true;
        WindowGroup.blocksRaycasts = true;
        ActionButton.interactable = true;
    }

    protected abstract void OnButtonClick();
}
