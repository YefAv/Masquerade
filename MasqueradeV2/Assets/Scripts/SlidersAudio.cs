using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SlidersAudio : MonoBehaviour
{
    [SerializeField] Slider musicVolumeSlider, sfxVolumeSlider;
    [SerializeField] AudioMixer masterMixer;


    void LoadSlider()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SfxVolume", 0f);
    }
    void SaveState()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SfxVolume", sfxVolumeSlider.value);
    }

    public void SetSfxVolume(float sfxVolume) { masterMixer.SetFloat("SfxVolume", sfxVolume); }
    public void MusicVolume(float musicVolume) { masterMixer.SetFloat("MusicVolume", musicVolume); }
}
