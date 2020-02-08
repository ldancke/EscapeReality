using UnityEngine.Audio;
using UnityEngine;


/**
* A class which provides an array of soundfiles alongside some basic controls.
*
* Its serializable to be shown in Inspector.
*/

[System.Serializable]
public class Sound
{
    //* Name of the soundfile
    public string name;

    //* Soundfile
    public AudioClip clip;

    //* Slider for volume control
    [Range(0f,1f)]
    public float volume;

    //* Slider for pitch control
    [Range(.1f, 3f)]
    public float pitch;

    //* checkbox to loop track
    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
