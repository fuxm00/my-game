﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // kdekoli v kódu zadej: "FindObjectOfType<AudioManager>().play("name");"

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

    private void Start()
    {
        StartPlaylist();
    }

    public void Update()
    {
        ContinuePlaylist();
    }

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

    public void StartPlaylist()
    {
        _currentTrackNumber = UnityEngine.Random.Range(0, _playlist.Length);

        SetValues(_currentTrackNumber);

        _playlistSource.Play();
    }

    private void SetValues(int trackNumber)
    {
        _playlistSource.clip = _playlist[trackNumber]._clip;
        _playlistSource.volume = _playlist[trackNumber]._volume;
        _playlistSource.pitch = _playlist[trackNumber]._pitch;
        _playlistSource.loop = _playlist[trackNumber]._loop;
    }

    public void ContinuePlaylist()
    {
        if (!_playlistSource.isPlaying)
        {
            SkipSong();
        }
    }
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
}
