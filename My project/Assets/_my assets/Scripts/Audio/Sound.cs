using UnityEngine.Audio;
using UnityEngine;

/// <summary>
/// This class represents a sound.
/// Each has it's name, clip to be played, volume, pitch.
/// _loop determines whether the sound should play in a loop.
/// </summary>
[System.Serializable]
public class Sound
{
    public string _name;
    public AudioClip _clip;

    [Range(0f,1f)]
    public float _volume;

    [Range(0.1f, 3f)]
    public float _pitch;

    public bool _loop;

    [HideInInspector]
    public AudioSource _source;
}
