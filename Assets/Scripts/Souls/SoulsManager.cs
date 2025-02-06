using System;
using UnityEngine;

public class SoulsManager : MonoBehaviour
{
    [Header("SoulsSettings")]
    [SerializeField] Transform _soulHolder;
    [SerializeField] int _countForHurt = 3;
    public int CountForHurt { get { return _countForHurt; } }

    public int CountSoulsAlive { get; private set; }
    public int CountSoulsCorrupt { get; private set; }
    public int CountSoulsPurify { get; private set; }
    public static SoulsManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CountSoulsAlive = 0;
        CountSoulsCorrupt = 0;
        CountSoulsPurify = 0;
        foreach (Transform soul in _soulHolder.transform)
        {
            CountSoulsAlive++;
            soul.GetComponent<Soul>().OnCorrupt += AddSoulsCorrupt;
            soul.GetComponent<Soul>().OnPurify += AddSoulsPurify;
        }
    }

    void AddSoulsCorrupt()
    {
        _countForHurt++;
    }
    void AddSoulsPurify()
    {
        _countForHurt++;
    }
}
