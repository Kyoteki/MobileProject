using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MusicSound
{
    public string musicName;
    public AudioClip musicClip;
}

public class MusicLibrary : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private MusicSound[] _musicLibrary;

    public AudioClip GetMusicFromName(string musicName)
    {
        foreach (MusicSound music in _musicLibrary)
        {
            if (music.musicName == musicName)
            {
                return music.musicClip;
            }
        }
        
        return null;
    }
}
