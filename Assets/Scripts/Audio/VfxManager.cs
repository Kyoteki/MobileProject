using UnityEngine;

public class VfxManager : MonoBehaviour
{
    public static VfxManager Instance { get; private set; }

    [Header("Vfx Manager Settings")]
    [SerializeField] private AudioSource _vfxSource; 
    [SerializeField] private VfxLibrary _vfxLibrary;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound2D(string soundName)
    {
        _vfxSource.PlayOneShot(_vfxLibrary.GetSoundFromName(soundName));
    }
}