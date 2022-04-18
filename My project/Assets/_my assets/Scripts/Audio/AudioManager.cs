using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // kdekoli v kódu zadej: "FindObjectOfType<AudioManager>().play("name");"
    // aby se přehrál zvuk s daným jménem

    public Sound[] sounds;
    public Sound[] playlist;
    private AudioSource playlistSource;
    private int currentTrackNumber;
    private int nextTrackNumber;

    
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        playlistSource = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {
        startPlaylist();
    }

    public void Update()
    {
        continuePlaylist();
    }

    public void play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();
    }

    public void startPlaylist()
    {
        currentTrackNumber = UnityEngine.Random.Range(0, playlist.Length);

        setValues(currentTrackNumber);

        playlistSource.Play();
    }

    private void setValues(int trackNumber)
    {
        playlistSource.clip = playlist[trackNumber].clip;
        playlistSource.volume = playlist[trackNumber].volume;
        playlistSource.pitch = playlist[trackNumber].pitch;
        playlistSource.loop = playlist[trackNumber].loop;
    }

    public void continuePlaylist()
    {
        if (!playlistSource.isPlaying)
        {
            skipSong();
        }
    }
    public void skipSong()
    {
        nextTrackNumber = UnityEngine.Random.Range(0, playlist.Length);

        while (currentTrackNumber == nextTrackNumber)
        {
            nextTrackNumber = UnityEngine.Random.Range(0, playlist.Length);
        }

        setValues(nextTrackNumber);
        playlistSource.Play();
        currentTrackNumber = nextTrackNumber;
    }
}
