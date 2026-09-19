using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Text _text2;
    [SerializeField] private Text _text3;
    [SerializeField] private float _duration;
    [SerializeField] private string _replaceText;
    [SerializeField] private string _appendText;
    [SerializeField] private string _scrambleText;

    private void Start()
    {
        _text.DOText(_replaceText, _duration);
        _text2.DOText(_appendText, _duration).SetRelative();
        _text3.DOText(_scrambleText, _duration, true, ScrambleMode.All);
    }
    
}
