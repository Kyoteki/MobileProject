using UnityEditor;
using UnityEngine;

[System.Serializable]
public class DataLevel
{
    private int _id;
    [SerializeField] private string _levelName;
    public string LevelName => _levelName;
    [SerializeField] private GameObject _prefab;
    public GameObject Prefab => _prefab;
    [SerializeField] private Sprite _imagePreviewMini;
    public Sprite ImagePreviewMini => _imagePreviewMini;
    [SerializeField] private Sprite _imagePreview;
    public Sprite ImagePreview => _imagePreview;
    private int _nbStars = 0;
    public int NbStars{ get => _nbStars; set => _nbStars = value; }
    private int _bestStep = 0;
    public int BestStep{ get => _bestStep; set => _bestStep = value; }
    private int _HighScore = 0;
    public int HighScore{ get => _HighScore; set => _HighScore = value; }
    private bool _isCompleted = false;
    public bool IsCompleted{ get => _isCompleted; set => _isCompleted = value; }
    private float _bestTime = 0.0f;
    public float BestTime{ get => _bestTime; set => _bestTime = value; }
}
