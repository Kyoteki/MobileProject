using UnityEngine;

[System.Serializable]
public struct SoundEffect
{
    public string soundName;
    public AudioClip soundClip;
}

public class SoundLibrary : MonoBehaviour
{
    [Header("Sound Effects")]
    [SerializeField] private SoundEffect[] _soundEffects;

    public AudioClip GetSoundFromName(string soundName)
    {
        foreach (SoundEffect sound in _soundEffects)
        {
            if (sound.soundName == soundName)
            {
                return sound.soundClip;
            }
        }

        return null;
    }
}
