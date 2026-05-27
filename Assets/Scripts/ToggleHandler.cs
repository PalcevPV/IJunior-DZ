using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ToggleHandler : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private string _parameterName;

    private float _mute = -80f;
    private float _unmute = 0f;

    private void Awake()
    {
        _toggle.onValueChanged.AddListener(SetMute);
    }

    private void OnDestroy()
    {
        _toggle.onValueChanged.RemoveListener(SetMute);
    }

    public void SetMute(bool isOn)
    {
        mixer.SetFloat(_parameterName, isOn ? _mute : _unmute);
    }
}
