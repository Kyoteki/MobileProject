using UnityEngine;

[System.Serializable]
public struct Sfx
{
    public string sfxName;
    public AudioClip sfxClip;
}

public class SfxLibrary : MonoBehaviour
{
    [Header("Sfx")]
    [SerializeField] private Sfx[] _sfxs;

    public AudioClip GetSoundFromName(string soundName)
    {
        foreach (Sfx sound in _sfxs)
        {
            if (sound.sfxName == soundName)
            {
                return sound.sfxClip;
            }
        }

        return null;
    }
}