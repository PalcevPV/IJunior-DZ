using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeHandler : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _parameterName;
    
    private int _dbMultiplier = 20;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDestroy()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);
    }

    public void SetVolume(float level)
    {
        mixer.SetFloat(_parameterName, Mathf.Log10(level) * _dbMultiplier);
    }  
}