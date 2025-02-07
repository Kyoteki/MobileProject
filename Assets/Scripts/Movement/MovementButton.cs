using UnityEngine;

public class MovementButton : MonoBehaviour
{
    private MovementPlayer _mouvementPlayer;

    private void Start()
    {
        _mouvementPlayer = GameManager.Instance.MovementPlayer;
        
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

    private void OnDestroy()
    {
        _mouvementPlayer.OnStartMove -= Hide;
        _mouvementPlayer.OnEndMove -= ShowCorrectButton;
    }
}
