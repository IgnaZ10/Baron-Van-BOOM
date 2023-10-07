using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider SFXslider;
    [SerializeField] private Slider Musicslider;
    public void SetMusicVolume()
    {
        float volume = Musicslider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume()
    {
        float volume = SFXslider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume)* 20);
    }
}
