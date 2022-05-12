using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioTracker : MonoBehaviour
{
    
    [SerializeField] AudioClip[] clips = new AudioClip[0];

    public void TurnAudioOff() { this.gameObject.GetComponent<AudioSource>().mute = true; }
    public void TurnAudioOn() { this.gameObject.GetComponent<AudioSource>().mute = false; }
    private void AudioChange(int indexSound)
    {
        this.GetComponent<AudioSource>().clip = clips[indexSound];
    }
}
