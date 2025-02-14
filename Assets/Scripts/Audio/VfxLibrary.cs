using UnityEngine;

[System.Serializable]
public struct Vfx
{
    public string vfxName;
    public AudioClip vfxClip;
}

public class VfxLibrary : MonoBehaviour
{
    [Header("Vfx")]
    [SerializeField] private Vfx[] _vfxs;

    public AudioClip GetSoundFromName(string soundName)
    {
        foreach (Vfx sound in _vfxs)
        {
            if (sound.vfxName == soundName)
            {
                return sound.vfxClip;
            }
        }

        return null;
    }
}