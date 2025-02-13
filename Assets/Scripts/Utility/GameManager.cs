using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Player Settings")] 
    private GameObject _player;
    public MovementPlayer MovementPlayer { get { return _player != null ? _player.GetComponent<MovementPlayer>() : throw new ArgumentNullException("No player movement"); } }
    public Vector3 PlayerPosition { get { return _player != null ? _player.transform.position : throw new ArgumentNullException("No player position"); } }
    public SoulPlayer SoulPlayer { get { return _player != null ? _player.gameObject.GetComponent<SoulPlayer>() : throw new ArgumentNullException("No soul player"); } }


    [Header("Level Settings")]
    private GameObject _level;
    [SerializeField] DataLevelContainer _levelContainer;

    [Header("Score Settings")]
    [SerializeField] private int _scoreOneStar = 60;
    [SerializeField] private int _scoreTwoStar = 80;
    [SerializeField] private int _scoreThreeStar = 100;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
        EndGame();
    }

    void Setup()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        StartTimer();
    }


    private void EndGame()
    {
        if (!SoulsManager.Instance.AllSoulsMeetEnd) return;
        int score = SoulsManager.Instance.CountSoulsPurify;
        float time = _timer;
        int stars = 0;
        int scorePercent = SoulsManager.Instance.CountSouls / score * 100;
        if(scorePercent >= _scoreOneStar) stars++;
        if(scorePercent >= _scoreTwoStar) stars++;
        if(scorePercent >= _scoreThreeStar) stars++;
        DataToSaves levelData = _levelContainer.GetCurrentLevel().DataToSaves;
        if(levelData.NbStars < stars) levelData.NbStars = stars;
        if(!levelData.IsCompleted || levelData.BestStep > MovementPlayer.NbCaseMouv) levelData.BestStep = MovementPlayer.NbCaseMouv;
        if(!levelData.IsCompleted || levelData.BestTime > time) levelData.BestTime = time;
        if (!levelData.IsCompleted || levelData.HighScore > SoulsManager.Instance.CountSoulsPurify) levelData.HighScore = SoulsManager.Instance.CountSoulsPurify;
        if(stars > 0) levelData.IsCompleted = true;
        SaveManager.Instance.Save();
    }

    private void loadLevel()
    {
        if(_level != null) Destroy(_level);
        if(_levelContainer.SceneToLoad < 0 || _levelContainer.SceneToLoad >= _levelContainer.Levels.Length) throw new ArgumentNullException("No level selected");
        _level = Instantiate(_levelContainer.GetCurrentLevel().Prefab);
        SoulsManager.Instance.Setup();
        Setup();
    }

    public void restartLevel()
    {
        loadLevel();
    }
    public void nextLevel()
    {
        _levelContainer.NextLevel();
        loadLevel();
    }
}
