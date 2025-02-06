using UnityEngine;

public class DataLevel : MonoBehaviour
{
    [SerializeField] private string _levelName;
    public string LevelName => _levelName;
    [SerializeField] private UnityEngine.UI.Image _imagePreview;
    public UnityEngine.UI.Image ImagePreview => _imagePreview;
    [SerializeField] private int _nbStars = 0;
    public int NbStars{ get => _nbStars; set => _nbStars = value; }
    [SerializeField] private bool _isLocked = true;
    public bool IsLocked{ get => _isLocked; set => _isLocked = value; }
    [SerializeField] private bool _isCompleted = false;
    public bool IsCompleted{ get => _isCompleted; set => _isCompleted = value; }
    [SerializeField] private float _bestTime = 0.0f;
    public float BestTime{ get => _bestTime; set => _bestTime = value; }
}
