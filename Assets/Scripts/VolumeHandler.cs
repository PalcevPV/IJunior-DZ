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

    public void SetVolume(float level)
    {
        Debug.Log(_parameterName);

        mixer.SetFloat(_parameterName, Mathf.Log10(level) * _dbMultiplier);
    }  
}