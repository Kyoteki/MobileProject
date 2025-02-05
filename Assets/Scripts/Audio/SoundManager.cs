using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Sound Manager Settings")]
    [SerializeField] private AudioSource _soundSource; 
    [SerializeField] private SoundLibrary _soundLibrary;
    
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
        _soundSource.PlayOneShot(_soundLibrary.GetSoundFromName(soundName));
    }
}
