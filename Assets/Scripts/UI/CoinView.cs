using TMPro;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    [SerializeField] private Bag _bag;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private string _caption = "Coins:";

    private void Awake()
    {
        UpdateView(_bag.CoinCount);
    }

    private void OnEnable()
    {
        _bag.CoinsCountChanged += UpdateView;
    }

    private void OnDisable()
    {
        _bag.CoinsCountChanged -= UpdateView;
    }

    private void UpdateView(int coinCount)
    {
        _coinText.text = $"{_caption}{coinCount}";
    }
}
