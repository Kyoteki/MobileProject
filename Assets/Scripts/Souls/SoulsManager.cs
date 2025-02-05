using UnityEngine;

public class SoulsManager : MonoBehaviour
{
    [SerializeField] Transform _soulHolder;
    [SerializeField] int _countForHurt = 3;
    public int CountForHurt { get { return _countForHurt; } }

    int _count = 0;
    int CountSouls {  get { return _count; } }
    public static SoulsManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _count = _soulHolder.childCount;
    }

    void Update()
    {
        if(_soulHolder.childCount == 0)
        {
            //FIN
            Debug.Log("FIN");
        }
    }
}
