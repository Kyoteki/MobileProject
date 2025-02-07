using System;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private MovementPlayer _mouvementPlayer;
    private CollisionManager _collisionManager;

    private void Start()
    {
        _mouvementPlayer = GameManager.Instance.MovementPlayer;
        _collisionManager = CollisionManager.Instance;
        
        _mouvementPlayer.OnStop += TryInteract;
    }

    private void OnDestroy()
    {
        _mouvementPlayer.OnStop -= TryInteract;
    }

    private void TryInteract()
    {
        if (_collisionManager.CanInteractAt(_mouvementPlayer.transform.position))
        {
            CollisionManager.Instance.GetInteractableAt(_mouvementPlayer.transform.position).Interact();   
        }
    }
    
}
