using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Player Settings")]
    [SerializeField] private GameObject _player;
    
    public MovementPlayer MovementPlayer { get { return _player.GetComponent<MovementPlayer>(); } }
    
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
}
