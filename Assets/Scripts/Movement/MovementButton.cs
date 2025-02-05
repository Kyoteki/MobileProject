using UnityEngine;

public class MovementButton : MonoBehaviour
{
    [SerializeField] private MovementPlayer _mouvementPlayer;

    void Awake()
    {
        _mouvementPlayer.OnStartMove += Hide;
        _mouvementPlayer.OnEndMove += ShowCorrectButton;
    }

    void OnMouseDown()
    {
        _mouvementPlayer.AddPos(transform.position);
        _mouvementPlayer.StartMoving();
    }

    void ShowCorrectButton()
    {
        gameObject.SetActive(!CollisionManager.Instance.GetObstacleAt(transform.position));
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}
