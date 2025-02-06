using System;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    private MovementPlayer _mouvementPlayer;

    void Awake()
    {
        Hide();
        
        _mouvementPlayer = GameManager.Instance.MovementPlayer;
        
        _mouvementPlayer.OnStartMove += Hide;
        _mouvementPlayer.OnEndMove += Show;
    }

    public void ClickButton()
    {
        CollisionManager.Instance.GetInteractableAt(_mouvementPlayer.transform.position).Interact();
        Show();
    }
    
    private void Show()
    {
        gameObject.SetActive(CollisionManager.Instance.InteractableAt(_mouvementPlayer.transform.position));
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
