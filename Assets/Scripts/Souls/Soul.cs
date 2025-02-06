using System;
using UnityEngine;
using UnityEngine.Events;

public class Soul : MonoBehaviour
{
    public enum State
    {
        stateOne, stateTwo, stateThree, stateFour, stateFive, stateDie
    }

    [Header("State")]
    [SerializeField] State _state = State.stateOne;
    [SerializeField] UnityEvent _onHurt;
    [Header("Visual")]
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite[] _sprites;
    private MovementPlayer _movementPlayer;
    public event Action OnCorrupt;
    [SerializeField] UnityEvent _onCorrupt;
    public event Action OnPurify;
    [SerializeField] UnityEvent _onPurify;

    void Start()
    {
        _movementPlayer = GameManager.Instance.MovementPlayer;

        _movementPlayer.OnEndMove += HurtSelf;
    }

    void HurtSelf()
    {
        int stepResult = MovementPlayer.NbCaseMouv / SoulsManager.Instance.CountForHurt;
        if (stepResult != (int)_state)
        {
            _state = (State)(stepResult);
            _onHurt?.Invoke();
            _spriteRenderer.sprite = _sprites[stepResult];
            if (_state == State.stateDie)
            {
                OnCorrupt?.Invoke();
                _onCorrupt?.Invoke();
                Destroy(gameObject);
            }
        }
    }

    public void Purify()
    {
        OnPurify?.Invoke();
        _onPurify?.Invoke();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _movementPlayer.OnEndMove -= HurtSelf;
    }
}
