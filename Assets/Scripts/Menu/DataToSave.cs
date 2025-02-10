using UnityEngine;

[System.Serializable]
public class DataToSaves
{
    private int _nbStars = 0;
    public int NbStars{ get => _nbStars; set => _nbStars = value; }
    private int _bestStep = 0;
    public int BestStep{ get => _bestStep; set => _bestStep = value; }
    private int _highScore = 0;
    public int HighScore{ get => _highScore; set => _highScore = value; }
    [SerializeField] private bool _isCompleted = false;
    public bool IsCompleted{ get => _isCompleted; set => _isCompleted = value; }
    private float _bestTime = 0.0f;
    public float BestTime{ get => _bestTime; set => _bestTime = value; }
}
