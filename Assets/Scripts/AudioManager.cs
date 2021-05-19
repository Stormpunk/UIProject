using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource audioSource;
    //with these, we can link the changing volume in the mixer and affect the audio coming from the audiosource
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
        //With luck this should be enough for the audio to be changed without giving me a stroke because it's too loud
        //Why isn't the volume name correct oh god
        //Volume name is fixed but it's not getting quieter why
        // nightmare nightmare nightmare nightmare nightmare
        //Okay I didn't link the audio source to the slider I'm dum
    }
    public void SetMute()
    {
        audioSource.mute = !audioSource.mute;
        //turns audio on and off
        //thank god this worked from the get go holy
    }
}
