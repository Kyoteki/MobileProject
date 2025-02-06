using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Player Settings")]
    [SerializeField] private GameObject _player;
    public MovementPlayer MovementPlayer { get { return _player != null ? _player.GetComponent<MovementPlayer>() : null; } }
    public Vector3 PlayerPosition { get { return _player != null ? _player.transform.position : Vector3.zero; } }
    public SoulPlayer SoulPlayer { get { return _player != null ? _player.gameObject.GetComponent<SoulPlayer>() : null; } }
    
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
