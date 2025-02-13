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

    void Start()
    {
        _movementPlayer = GameManager.Instance.MovementPlayer;

        _movementPlayer.OnEndMove += HurtSelf;
        //A SUPRIMMERR!!!!!!!!!!!!!!!!!!!!!
        switch (_state)
        {
            case State.stateOne:
                _spriteRenderer.color = Color.green;
                break;
            case State.stateTwo:
                _spriteRenderer.color = Color.yellow;
                break;
            case State.stateThree:
                _spriteRenderer.color = Color.red;
                break;
            case State.stateFour:
                _spriteRenderer.color = Color.gray;
                break;
            case State.stateFive:
                _spriteRenderer.color = Color.black;
                break;
        }
    }

    void HurtSelf()
    {
        int stepResult = MovementPlayer.NbCaseMouv / SoulsManager.Instance.CountForHurt;
        if (stepResult != (int)_state)
        {
            _state = (State)(stepResult);
            if (_state == State.stateDie)
            {
                OnCorrupt?.Invoke();
                _onCorrupt?.Invoke();
                Destroy(gameObject);
            }
            else
            {
                _onHurt?.Invoke();
                _spriteRenderer.sprite = _sprites[stepResult];
            }
            //A SUPRIMMERR!!!!!!!!!!!!!!!!!!!!!
            switch (_state)
            {
                case State.stateOne:
                    _spriteRenderer.color = Color.green;
                    break;
                case State.stateTwo:
                    _spriteRenderer.color = Color.yellow;
                    break;
                case State.stateThree:
                    _spriteRenderer.color = Color.red;
                    break;
                case State.stateFour:
                    _spriteRenderer.color = Color.gray;
                    break;
                case State.stateFive:
                    _spriteRenderer.color = Color.black;
                    break;
            }
        }
    }

    private void OnDestroy()
    {
        _movementPlayer.OnEndMove -= HurtSelf;
    }
}
