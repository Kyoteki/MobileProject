using System;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public static CollisionManager Instance {  get; private set; }
    [SerializeField] LayerMask _layerInteractable;
    [SerializeField] LayerMask _layerObstacle;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }

    public IInteractable GetInteractableAt(Vector3 position)
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(position, Vector3.forward, 0.1f, _layerInteractable);
        IInteractable result;
        if (raycastHit2D.collider.TryGetComponent<IInteractable>(out result)) return result;
        else throw new ArgumentNullException("Get Interactable Null");
    }
    public bool GetObstacleAt(Vector3 position)
    {
        return Physics2D.Raycast(position, Vector3.forward, 0.1f, _layerObstacle);
    }
    public bool CanInteractAt(Vector3 position)
    {
        return Physics2D.Raycast(position, Vector3.forward, 0.1f, _layerInteractable);
    }
}
