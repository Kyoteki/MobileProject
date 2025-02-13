using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [Header("Managers/Scripts")]
    [SerializeField] private GameObject _musicManager;
    [SerializeField] private GameObject _soundManager;
    [SerializeField] private GameObject _vfxManager;
    [SerializeField] private MovementButton _movementButton;
    [Header("Options UI")]
    [SerializeField] private GameObject _sliderMusic;
    [SerializeField] private GameObject _sliderSound;
    [SerializeField] private GameObject _sliderVFX;
    [SerializeField] private GameObject _toggleMoveUI;

    void Update()
    {
        if (_musicManager != null)
        {
            _musicManager.GetComponentInChildren<AudioSource>().volume = _sliderMusic.GetComponent<Slider>().value;
        }
        if (_soundManager != null)
        {
            _soundManager.GetComponentInChildren<AudioSource>().volume = _sliderSound.GetComponent<Slider>().value;
        }
        if (_vfxManager != null)
        {
            _vfxManager.GetComponentInChildren<AudioSource>().volume = _sliderVFX.GetComponent<Slider>().value;
        }
        if (_movementButton != null)
        {
            // Hide/Show UI
        }
    }

}
