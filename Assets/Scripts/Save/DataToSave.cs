using UnityEngine;

[System.Serializable]
public class DataToSaves
{
    [SerializeField] private int _percentFinish = 0;
    public int PercentFinish{ get => _percentFinish; set => _percentFinish = value; }
    [SerializeField] private int _bestStep = 0;
    public int BestStep{ get => _bestStep; set => _bestStep = value; }
    [SerializeField] private int _highScore = 0;
    public int HighScore{ get => _highScore; set => _highScore = value; }
    [SerializeField] private bool _isCompleted = false;
    public bool IsCompleted{ get => _isCompleted; set => _isCompleted = value; }
    [SerializeField] private float _bestTime = 0.0f;
    public float BestTime{ get => _bestTime; set => _bestTime = value; }
}
