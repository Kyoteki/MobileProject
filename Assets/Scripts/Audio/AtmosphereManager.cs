using UnityEngine;

public class AtmosphereManager : MonoBehaviour
{
    public static AtmosphereManager Instance { get; private set; }

    [Header("Atmosphere Manager Settings")]
    [SerializeField] private AudioSource _atmosphereSource; 
    [SerializeField] private AtmosphereLibrary _atmosphereLibrary;
    
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
        _atmosphereSource.PlayOneShot(_atmosphereLibrary.GetSoundFromName(soundName));
    }
}
