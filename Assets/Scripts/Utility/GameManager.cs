using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Player Settings")] 
    //[SerializeField] private int _playerScoreFromPurify = 4;
    //public int PlayerScoreFromPurify { get { return _playerScoreFromPurify; } }
    //[SerializeField] private int _currentPlayerScore = 4;

    private GameObject _player;
    public MovementPlayer MovementPlayer { get { return _player != null ? _player.GetComponent<MovementPlayer>() : null; } }
    public Vector3 PlayerPosition { get { return _player != null ? _player.transform.position : Vector3.zero; } }
    public SoulPlayer SoulPlayer { get { return _player != null ? _player.gameObject.GetComponent<SoulPlayer>() : null; } }


    [Header("Level Settings")]
    private GameObject _level;
    [SerializeField] private GameObject _levelSelected;

    [Header("Score Settings")]
    [SerializeField] private int _scoreOneStar = 60;
    [SerializeField] private int _scoreTwoStar = 80;
    [SerializeField] private int _scoreThreeStar = 100;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //A RETIRER
            Setup();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        loadLevel();
    }

    float _timer = 0f;
    public void StartTimer()
    {
        _timer = 0f;
    }

    void Update()
    {
        _timer += Time.deltaTime;
    }

    void Setup()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        StartTimer();
    }

    private void EndGame()
    {
        int score = SoulsManager.Instance.CountSoulsPurify;
        float time = _timer;
        int stars = 0;
        int scorePercent = SoulsManager.Instance.CountSouls / score * 100;
        if(scorePercent > _scoreOneStar) stars++;
        if(scorePercent > _scoreTwoStar) stars++;
        if(scorePercent > _scoreThreeStar) stars++;
    }

    private void loadLevel()
    {
        if(_level != null) Destroy(_level);
        _level = Instantiate(_levelSelected);
        SoulsManager.Instance.Setup();
        Setup();
    }

    private void restartLevel()
    {
        loadLevel();
    }
}
