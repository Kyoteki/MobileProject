using UnityEngine;

public class Souls : MonoBehaviour, IInteractable
{
    [Header("Soul Settings")]
    [SerializeField] private GameObject _soulParent;
    
    public void Interact()
    {
        Destroy(_soulParent.gameObject);
    }
}
