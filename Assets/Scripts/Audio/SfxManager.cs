using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager Instance { get; private set; }

    [Header("Sfx Manager Settings")]
    [SerializeField] private AudioSource _sfxSource; 
    [SerializeField] private SfxLibrary _sfxLibrary;
    
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
        _sfxSource.PlayOneShot(_sfxLibrary.GetSoundFromName(soundName));
    }
}