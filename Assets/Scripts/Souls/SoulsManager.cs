using System;
using UnityEngine;

public class SoulsManager : MonoBehaviour
{
    [Header("SoulsSettings")]
    [SerializeField] int _countForHurt = 3;
    public int CountForHurt { get { return _countForHurt; } }

    public int CountSouls { get; private set; }
    public int CountSoulsCorrupt { get; private set; }
    public int CountSoulsPurify { get; private set; }
    public static SoulsManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Setup();
    }

    public void Setup()
    {
        CountSouls = 0;
        CountSoulsCorrupt = 0;
        CountSoulsPurify = 0;
        foreach (GameObject soul in GameObject.FindGameObjectsWithTag("Soul"))
        {
            CountSouls++;
            soul.GetComponent<Soul>().OnCorrupt += AddSoulsCorrupt;
        }
    }

    void AddSoulsCorrupt()
    {
        CountSoulsCorrupt++;
    }
    public void AddSoulsPurify()
    {
        CountSoulsPurify++;
    }
}
