using Unity.VisualScripting;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    [Header("Managers/Scripts")]
    [Serialize] private GameObject _musicManager;
    [Serialize] private GameObject _soundManager;
    [Serialize] private GameObject _vfxManager;
    [Serialize] private MovementButton _movementButton;
    [Header("Options UI")]
    [Serialize] private GameObject _sliderMusic;
    [Serialize] private GameObject _sliderSound;
    [Serialize] private GameObject _sliderVFX;
    [Serialize] private GameObject _toggleMoveUI;

}
