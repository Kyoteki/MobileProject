using UnityEngine;

[System.Serializable]
public struct AtmosphereEffect
{
    public string atmosphereName;
    public AudioClip atmosphereClip;
}

public class AtmosphereLibrary : MonoBehaviour
{
    [Header("Atmosphere Effects")]
    [SerializeField] private AtmosphereEffect[] _atmosphereEffects;

    public AudioClip GetSoundFromName(string soundName)
    {
        foreach (AtmosphereEffect sound in _atmosphereEffects)
        {
            if (sound.atmosphereName == soundName)
            {
                return sound.atmosphereClip;
            }
        }

        return null;
    }
}
