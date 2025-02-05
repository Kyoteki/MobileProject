using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouvementPlayer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed = 1;
    private static int _nbCaseMouv = 0;
    public static int NbCaseMouv { get => _nbCaseMouv; private set => _nbCaseMouv = value; }
    [SerializeField] private List<Vector3> _pathList = new List<Vector3>();
    public List<Vector3> PathList { get => _pathList; set => _pathList = value; }
    [SerializeField] UnityEvent  _onStartMove = new UnityEvent();
    [SerializeField] UnityEvent  _onEndMove = new UnityEvent();
    [SerializeField] UnityEvent  _onTP = new UnityEvent();
    private bool _isMoving = false;
    public bool IsMoving { get => _isMoving; set => _isMoving = value; }
    private bool _doCountMove = true;
    public bool DoCountMove { get => _doCountMove; set => _doCountMove = value; }
    private Vector3 _nextPos;

    void Update()
    {
        if (_isMoving)
        {
            Mouv();
        }
    }

    void Mouv()
    {
        float deltaTime = Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _nextPos, _speed * deltaTime);
        if (transform.position == _nextPos)
        {
            NextPos(); 
        }
    }

    void NextPos()
    {
        if (_pathList.Count > 0)
        {
            _nextPos = _pathList[0];
            _pathList.RemoveAt(0);
            if (_nextPos.x > transform.position.x)
            {
                _spriteRenderer.flipX = false;
            }
            else if (_nextPos.x < transform.position.x)
            {
                _spriteRenderer.flipX = true;
            }
        }
        else
        {
            _isMoving = false;
            _onEndMove.Invoke();
            return;
        }
        if (_doCountMove)
        {
            _nbCaseMouv++;
        }
    }

    public void AddPos(Vector3 pos)
    {
        _pathList.Add(pos);
    }
    public void AddPos(List<Vector3> pos)
    {
        foreach (Vector3 p in pos)
        {
            _pathList.Add(p);
        }
    }

    public void StartMoving()
    {
        _isMoving = true;
        NextPos();
        _onStartMove.Invoke();
    }

    public void TPAt(Vector3 pos)
    {
        transform.position = pos;
        _onTP.Invoke();
    }
}
