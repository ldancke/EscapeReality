
using UnityEngine.Audio;
using System;
using UnityEngine;

/**
* A class which creates an AudioManager instance to play audio and controls the Sounds Array.
*/
public class AudioManager : MonoBehaviour
{
    /**
    * @see Sound
    */
    public Sound[] sounds;

    /**
    * AudioManager instance
    */
    public static AudioManager instance;

    /**
    * Manages the instance and passes on controls.
    */
    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    /**
    * Starts playing the Theme sound/song when the scrips is enabled. 
    * 
    */
    void Start()
    {
        Play("Theme");
    }

    /**
    * Plays a soundfile found in the Sound array. 
    * 
    * @param name Name of the soundfile to play.
    */
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.Play();
    }
}