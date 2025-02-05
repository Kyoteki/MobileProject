using UnityEngine;

public class Soul : MonoBehaviour
{
    public enum State
    {
        stateOne, stateTwo, stateThree, stateFour, stateFive, stateDie
    }

    [SerializeField] State state = State.stateOne;
    private MovementPlayer _movementPlayer;

    void Start()
    {
        _movementPlayer = GameManager.Instance.MovementPlayer;

        _movementPlayer.OnEndMove += HurtSelf;
    }

    void HurtSelf()
    {
        state = (State)(MovementPlayer.NbCaseMouv / SoulsManager.Instance.CountForHurt);
        if (state == State.stateDie) Destroy(gameObject);
    }
}
