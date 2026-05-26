using UnityEngine;
using UnityEngine.Audio;

public class VolumeHandler : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    public void SetMasterVolume(float level)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(level) * 20);
    }

    public void SetMusicVolume(float level)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(level) * 20);
    }

    public void SetSFXVolume(float level)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(level) * 20);
    }

    public void ToggleMute(bool isOn)
    {
        mixer.SetFloat("MasterVolume", isOn ? -80f : 0f);
    }
}
