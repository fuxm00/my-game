using UnityEngine.Audio;
using System;
using UnityEngine;

/// <summary>
/// This class manages sounds and playlist.
/// There is an array of sounds which can be played
/// and playlist array of songs to be played in the background.
/// </summary>
public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] _sounds;
    [SerializeField] Sound[] _playlist;

    private AudioSource _playlistSource;
    private int _currentTrackNumber;
    private int _nextTrackNumber;
    
    void Awake()
    {
        foreach (Sound s in _sounds)
        {
            s._source = gameObject.AddComponent<AudioSource>();
            s._source.clip = s._clip;

            s._source.volume = s._volume;
            s._source.pitch = s._pitch;
            s._source.loop = s._loop;
        }

        _playlistSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        StartPlaylist();
    }

    void Update()
    {
        ContinuePlaylist();
    }

    /// <summary>
    /// Plays a sound according to its name.
    /// </summary>
    /// <param name="name">
    /// name of a sound
    /// </param>
    public void Play(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound._name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s._source.Play();
    }

    /// <summary>
    /// Starts playing music.
    /// </summary>
    public void StartPlaylist()
    {
        _currentTrackNumber = UnityEngine.Random.Range(0, _playlist.Length);

        SetValues(_currentTrackNumber);

        _playlistSource.Play();
    }

    /// <summary>
    /// Keeps playlist running.
    /// </summary>
    public void ContinuePlaylist()
    {
        if (!_playlistSource.isPlaying)
        {
            SkipSong();
        }
    }

    /// <summary>
    /// Skips a song in a playlist.
    /// </summary>
    public void SkipSong()
    {
        _nextTrackNumber = UnityEngine.Random.Range(0, _playlist.Length);

        while (_currentTrackNumber == _nextTrackNumber)
        {
            _nextTrackNumber = UnityEngine.Random.Range(0, _playlist.Length);
        }

        SetValues(_nextTrackNumber);
        _playlistSource.Play();
        _currentTrackNumber = _nextTrackNumber;
    }

    private void SetValues(int trackNumber)
    {
        _playlistSource.clip = _playlist[trackNumber]._clip;
        _playlistSource.volume = _playlist[trackNumber]._volume;
        _playlistSource.pitch = _playlist[trackNumber]._pitch;
        _playlistSource.loop = _playlist[trackNumber]._loop;
    }
}
